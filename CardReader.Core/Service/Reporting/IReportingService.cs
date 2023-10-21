using CardReader.Core.Model.IdReader;
using CardReader.Core.Model.VehicleIdReader;

namespace CardReader.Core.Service.Reporting
{
    public interface IReportingService
    {
        Task IdReaderReportAsync(IdReaderData readerDate, CancellationToken ct);

        Task VehicleIdReportAsync(VehicleIdData readerDate, CancellationToken ct);
    }
}
