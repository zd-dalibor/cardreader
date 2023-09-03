using CardReader.Core.Model.IdReader;
using CardReader.Core.Service.Configuration;
using CardReader.Core.State;

namespace CardReader.Infrastructure.State
{
    internal class ApplicationState : IApplicationState
    {
        public bool IsMainWindowActive { get; set; }

        public string IdReaderCardReaderId
        {
            get => settings.IdReaderCardReaderId(); 
            set => settings.UpdateIdReaderCardReaderId(value);
        }

        public int IdReaderApiVersion => settings.IdReaderApiVersion();

        public string VehicleIdReaderCardReaderId
        {
            get => settings.VehicleIdReaderCardReaderId(); 
            set => settings.UpdateVehicleIdReaderCardReaderId(value);
        }

        public int VehicleIdReaderApiVersion => settings.VehicleIdReaderApiVersion();

        public IdReaderData LastIdReaderData { get; set; }

        private readonly IApplicationSettings settings;

        public ApplicationState(IApplicationSettings settings)
        {
            this.settings = settings;
        }
    }
}
