using CardReader.Core.Model.IdReader;

namespace CardReader.Core.Service.Reporting
{
    public interface IReportingService
    {
        Task IdReaderReportAsync(IdReaderData readerDate, string currentLocale, CancellationToken ct);
    }
}
