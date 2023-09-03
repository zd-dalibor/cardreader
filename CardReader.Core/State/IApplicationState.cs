using CardReader.Core.Model.IdReader;

namespace CardReader.Core.State
{
    public interface IApplicationState
    {
        bool IsMainWindowActive { get; set; }

        string IdReaderCardReaderId { get; set; }

        int IdReaderApiVersion { get; }

        string VehicleIdReaderCardReaderId { get; set; }

        int VehicleIdReaderApiVersion { get; }

        IdReaderData LastIdReaderData { get; set; }
    }
}
