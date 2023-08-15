namespace CardReader.Core.Service.Globalization
{
    public interface ILocaleService
    {
        void Init();

        void ChangeLocale(string locale);

        string DefaultLocale { get; }

        string GetString(string key, bool forCurrentView = false);
    }
}
