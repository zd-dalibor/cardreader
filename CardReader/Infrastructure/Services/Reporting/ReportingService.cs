using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;
using CardReader.Core.Model.IdReader;
using CardReader.Core.Model.VehicleIdReader;
using CardReader.Core.Service.Reporting;
using CardReader.Core.Service.Resources;
using CardReader.Reports.VehicleIdReader;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace CardReader.Infrastructure.Services.Reporting
{
    internal class ReportingService : IReportingService
    {
        private static bool _fontLoaded;

        private const string IdReaderReferenceName = "IdReaderData";

        private const string VehicleIdReaderReferenceName = "VehicleIdReaderData";

        private readonly IApplicationResources resources;

        static ReportingService()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }
        
        public ReportingService(IApplicationResources resources)
        {
            this.resources = resources;
        }

        public async Task IdReaderReportAsync(IdReaderData readerDate, CancellationToken ct)
        {
            await LoadFontsAsync();
            IdReaderReport(readerDate, ct);
        }

        public async Task VehicleIdReportAsync(VehicleIdData readerDate, CancellationToken ct)
        {
            await LoadFontsAsync();
            VehicleIdReport(readerDate, ct);
        }

        private static void IdReaderReport(IdReaderData readerDate, CancellationToken ct)
        {
            /*var localAppData = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            var resultFile = Path.Combine(localAppData, $@"Reports\{IdReaderReferenceName}.pdf");
            
            Process.Start(new ProcessStartInfo(resultFile) { UseShellExecute = true });*/
        }
        
        private void VehicleIdReport(VehicleIdData readerDate, CancellationToken ct)
        {
            var document = new VehicleIdReaderDocument(readerDate, resources);
            Report(document, VehicleIdReaderReferenceName, ct);
        }

        private static void Report(IDocument document, string fileName, CancellationToken ct)
        {
            var localAppData = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            var resultFile = Path.Combine(localAppData, $@"Reports\{fileName}.pdf");
            CreateParentDirectory(resultFile);
            document.GeneratePdf(resultFile);
            ct.ThrowIfCancellationRequested();
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

        private static async Task LoadFontsAsync()
        {
            if (_fontLoaded) return;

            _fontLoaded = true;
            var fonts = new []
            {
                "Assets/Fonts/Open_Sans/OpenSans-Italic-VariableFont_wdth,wght.ttf",
                "Assets/Fonts/Open_Sans/OpenSans-VariableFont_wdth,wght.ttf"
            };

            foreach (var font in fonts)
            {
                var uriString = $"ms-appx:///{font}";
                var uri = new Uri(uriString);
                var fontFile = await StorageFile.GetFileFromApplicationUriAsync(uri);
                using var stream = await fontFile.OpenReadAsync();
                FontManager.RegisterFont(stream.AsStream());
            }
        }
    }
}
