namespace CardReader.Core.Service.Configuration
{
    public interface IApplicationSettings
    {
        string CurrentLocale(string defaultLocale);

        void UpdateCurrentLocale(string? locale);

        string? IdReaderCardReaderId();

        void UpdateIdReaderCardReaderId(string? value);

        int IdReaderApiVersion();

        void UpdateVehicleIdReaderCardReaderId(string? value);

        string? VehicleIdReaderCardReaderId();

        int VehicleIdReaderApiVersion();
        
        void UpdateWindowWidth(int width);
        
        int WindowWidth(int defaultWidth);
        
        void UpdateWindowHeight(int height);
        
        int WindowHeight(int defaultHeight);
    }
}
