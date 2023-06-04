using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CardReader.Model;
using FastReport;
using FastReport.Export.Html;
using iText.Html2pdf;
using iText.Html2pdf.Attach.Impl;
using iText.Html2pdf.Resolver.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace CardReader.Service
{
    public class ReportingService : IReportingService
    {
        public void IdReaderReport(IdReaderData data, CultureInfo locale, bool forDesigner = false)
        {
            const string referenceName = "IdReaderData";
            var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var appDir = AppDomain.CurrentDomain.BaseDirectory;
            var fData = new List<IdReaderData> { data };
            var reportFile = Path.Combine(appDir, forDesigner
                ? $@"Assets\Reports\{referenceName}.frx"
                : $@"Assets\Reports\{locale.Name}\{referenceName}.frx");
            var resultFile = Path.Combine(localAppData, AppDomain.CurrentDomain.FriendlyName, $@"Reports\{referenceName}.pdf");

            var report = new Report();
            if (forDesigner)
            {
                PrepareReport(report, ref fData, referenceName, reportFile);
            }
            else
            {
                CreateReport(report, ref fData, referenceName, reportFile, resultFile);
            }
        }

        public Task IdReaderReportAsync(IdReaderData data, CultureInfo locale, bool forDesigner = false,
            CancellationToken cancellation = default)
        {
            return Task.Factory.StartNew(() => IdReaderReport(data, locale, forDesigner), cancellation);
        }

        public void VehicleIdReport(VehicleIdData data, CultureInfo locale, bool forDesigner = false)
        {
            const string referenceName = "VehicleIdData";
            var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var appDir = AppDomain.CurrentDomain.BaseDirectory;
            var fData = new List<VehicleIdData> { data };
            var reportFile = Path.Combine(appDir, forDesigner
                ? $@"Assets\Reports\{referenceName}.frx"
                : $@"Assets\Reports\{locale.Name}\{referenceName}.frx");
            var resultFile = Path.Combine(localAppData, AppDomain.CurrentDomain.FriendlyName, $@"Reports\{referenceName}.pdf");

            var report = new Report();
            if (forDesigner)
            {
                PrepareReport(report, ref fData, referenceName, reportFile);
            }
            else
            {
                CreateReport(report, ref fData, referenceName, reportFile, resultFile);
            }
        }

        public Task VehicleIdReportAsync(VehicleIdData data, CultureInfo locale, bool forDesigner = false,
            CancellationToken cancellation = default)
        {
            return Task.Factory.StartNew(() => VehicleIdReport(data, locale, forDesigner), cancellation);
        }

        private static void CreateParentDirectory(string filePath)
        {
            var directoryName = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
        }

        private static void PrepareReport<T>(Report report, ref List<T> fData, string referenceName, string reportFile)
        {
            report.Dictionary.RegisterBusinessObject(fData, referenceName, 2, true);
            report.RegisterData(fData, referenceName);

            using var reportMs = new MemoryStream();
            report.Save(reportMs);

            reportMs.Seek(0, SeekOrigin.Begin);
            using var sr = new StreamReader(reportMs);
            var reportStr = sr.ReadToEnd();
            CreateParentDirectory(reportFile);
            File.WriteAllText(reportFile, reportStr);
        }

        private static void CreateReport<T>(Report report, ref List<T> fData, string referenceName, string reportFile,
            string resultFile)
        {
            report.Load(reportFile);
            report.RegisterData(fData, referenceName);
            report.Prepare();

            string reportHtml;
            var htmlExport = new HTMLExport
            {
                Layers = true,
                EmbedPictures = true
            };
            using (var ms = new MemoryStream())
            {
                htmlExport.Export(report, ms);
                ms.Flush();
                reportHtml = Encoding.UTF8.GetString(ms.ToArray());
            }

            CreateParentDirectory(reportFile);

            using var pdfWriter = new PdfWriter(new FileInfo(resultFile));
            var fontProvider = new DefaultFontProvider(true, true, true);
            var converterProviders = new ConverterProperties();
            converterProviders.SetTagWorkerFactory(new CustomTagWorkerFactory());
            converterProviders.SetFontProvider(fontProvider);
            var pdfDocument = new PdfDocument(pdfWriter);
            pdfDocument.SetDefaultPageSize(iText.Kernel.Geom.PageSize.A4);
            var elements = HtmlConverter.ConvertToElements(reportHtml, converterProviders);
            var document = new Document(pdfDocument, iText.Kernel.Geom.PageSize.A4);
            document.SetMargins(0, 0, 0, 0);
            var elementIndex = 0;
            foreach (var element in elements)
            {
                if (element.HasProperty(CustomPageTagWorker.PageDivProperty) && elementIndex > 0)
                {
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                }

                document.Add((IBlockElement)element);
                elementIndex++;
            }
            document.Close();
            Process.Start(new ProcessStartInfo(resultFile) { UseShellExecute = true });
            //var pdfExport = new PDFSimpleExport();
            //pdfExport.OpenAfterExport = true;
            //pdfExport.Export(report, resultFile);
        }
    }
}
