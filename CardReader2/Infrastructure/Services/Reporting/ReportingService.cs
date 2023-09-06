using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CardReader.Core.Model.IdReader;
using CardReader.Core.Service.Reporting;
using Fluid;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

namespace CardReader.Infrastructure.Services.Reporting
{
    internal class ReportingService : IReportingService
    {
        private const string IdReaderReferenceName = "IdReaderData";

        public Task IdReaderReportAsync(IdReaderData readerDate, string currentLocale, CancellationToken ct)
        {
            return Task.Factory.StartNew(() => IdReaderReport(readerDate, currentLocale, ct), ct);
        }

        private static void IdReaderReport(IdReaderData readerDate, string currentLocale, CancellationToken ct)
        {
            var localAppData = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            var resultFile = Path.Combine(localAppData, $@"Reports\{IdReaderReferenceName}.pdf");
            var appDir = AppDomain.CurrentDomain.BaseDirectory;

            var htmlConverter = new HtmlToPdfConverter
            {
                ConverterSettings =
                {
                    PdfPageSize = PdfPageSize.A4,
                    Margin = new PdfMargins { All = 10 }
                }
            };

            var parser = new FluidParser();
            var model = new { Message = "Hello World" };
            const string htmlTemplate = "<html><body><p>{{ Message }}</p></body></html>";
            if (parser.TryParse(htmlTemplate, out var template, out var error))
            {
                var context = new TemplateContext(model);
                var htmlText = template.Render(context);

                var document = htmlConverter.Convert(htmlText, appDir);

                if (ct.IsCancellationRequested)
                {
                    ct.ThrowIfCancellationRequested();
                }
            
                CreateParentDirectory(resultFile);

                using var fileStream = new FileStream(resultFile, FileMode.Create, FileAccess.ReadWrite);
                document.Save(fileStream);
                document.Close(true);
            }
            else
            {
                throw new InvalidOperationException(error);
            }
            
            Process.Start(new ProcessStartInfo(resultFile) { UseShellExecute = true });
        }

        private static void CreateParentDirectory(string filePath)
        {
            var directoryName = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
        }
    }
}
