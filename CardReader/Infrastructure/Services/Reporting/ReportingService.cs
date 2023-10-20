using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CardReader.Core.Model.IdReader;
using CardReader.Core.Model.VehicleIdReader;
using CardReader.Core.Service.Reporting;

namespace CardReader.Infrastructure.Services.Reporting
{
    internal class ReportingService : IReportingService
    {
        private const string IdReaderReferenceName = "IdReaderData";

        private const string VehicleIdReaderReferenceName = "VehicleIdReaderData";

        public Task IdReaderReportAsync(IdReaderData readerDate, string currentLocale, CancellationToken ct)
        {
            return Task.Factory.StartNew(() => IdReaderReport(readerDate, currentLocale, ct), ct);
        }

        public Task VehicleIdReportAsync(VehicleIdData readerDate, string currentLocale, CancellationToken ct)
        {
            return Task.Factory.StartNew(() => VehicleIdReport(readerDate, currentLocale, ct), ct);
        }

        private static void IdReaderReport(IdReaderData readerDate, string currentLocale, CancellationToken ct)
        {
            /*var localAppData = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            var resultFile = Path.Combine(localAppData, $@"Reports\{IdReaderReferenceName}.pdf");
            
            Process.Start(new ProcessStartInfo(resultFile) { UseShellExecute = true });*/
        }
        
        private static void VehicleIdReport(VehicleIdData readerDate, string currentLocale, CancellationToken ct)
        {
            
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
