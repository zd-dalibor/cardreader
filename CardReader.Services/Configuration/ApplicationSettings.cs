using CardReader.Core.Service.Configuration;
using CardReader.Core.Service.Storage;

namespace CardReader.Services.Configuration
{
    public class ApplicationSettings : IApplicationSettings
    {
        private const string CurrentLocaleKey = "CurrentLocale";

        private const string IdReaderCardReaderIdKey = "IdReaderCardReaderId";

        private const string IdReaderApiVersionKey = "IdReaderApiVersion";

        private const string VehicleIdReaderCardReaderIdKye = "VehicleIdReaderCardReaderId";

        private const string VehicleIdReaderApiVersionKye = "VehicleIdReaderApiVersion";

        private const string WindowWidthKey = "WindowWidth";

        private const string WindowHeightKey = "WindowHeight";

        private const int DefaultIdReaderApiVersion = 3;

        private const int DefaultVehicleIdReaderApiVersion = 0;

        private readonly IApplicationStorage storage;

        public ApplicationSettings(IApplicationStorage storage)
        {
            this.storage = storage;
        }

        public string CurrentLocale(string defaultLocale)
        {
            return (string) storage.GetSettings(CurrentLocaleKey, defaultLocale);
        }

        public void UpdateCurrentLocale(string locale)
        {
            storage.SetSettings(CurrentLocaleKey, locale);
        }

        public string IdReaderCardReaderId()
        {
            return (string) storage.GetSettings(IdReaderCardReaderIdKey);
        }

        public void UpdateIdReaderCardReaderId(string value)
        {
            storage.SetSettings(IdReaderCardReaderIdKey, value);
        }

        public int IdReaderApiVersion()
        {
            return (int) storage.GetSettings(IdReaderApiVersionKey, DefaultIdReaderApiVersion);
        }

        public void UpdateVehicleIdReaderCardReaderId(string value)
        {
            storage.SetSettings(VehicleIdReaderCardReaderIdKye, value);
        }

        public string VehicleIdReaderCardReaderId()
        {
            return (string) storage.GetSettings(VehicleIdReaderCardReaderIdKye);
        }

        public int VehicleIdReaderApiVersion()
        {
            return (int) storage.GetSettings(VehicleIdReaderApiVersionKye, DefaultVehicleIdReaderApiVersion);
        }

        public void UpdateWindowWidth(int width)
        {
            storage.SetSettings(WindowWidthKey, width);
        }

        public int WindowWidth(int defaultWidth)
        {
            return (int) storage.GetSettings(WindowWidthKey, defaultWidth);
        }

        public void UpdateWindowHeight(int height)
        { 
            storage.SetSettings(WindowHeightKey, height);
        }

        public int WindowHeight(int defaultHeight)
        {
            return (int) storage.GetSettings(WindowHeightKey, defaultHeight);
        }
    }
}
