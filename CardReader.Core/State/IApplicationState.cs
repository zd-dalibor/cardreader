using CardReader.Core.Model.IdReader;
using CardReader.Core.Model.VehicleIdReader;

namespace CardReader.Core.State
{
    public interface IApplicationState
    {
        bool IsMainWindowActive { get; set; }

        string? IdReaderCardReaderId { get; set; }

        int IdReaderApiVersion { get; }

        string? VehicleIdReaderCardReaderId { get; set; }

        int VehicleIdReaderApiVersion { get; }

        IdReaderData? LastIdReaderData { get; set; }

        VehicleIdData? LastVehicleIdReaderData { get; set; }
    }
}
