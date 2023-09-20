#nullable enable
using Windows.Storage;
using CardReader.Core.Service.Storage;

namespace CardReader.Infrastructure.Services.Storage
{
    internal class ApplicationStorage : IApplicationStorage
    {
        private static ApplicationDataContainer LocalSettings => ApplicationData.Current.LocalSettings;

        public object? GetSettings(string key)
        {
            return LocalSettings.Values[key];
        }

        public object GetSettings(string key, object defaultValue)
        {
            return LocalSettings.Values[key] ?? defaultValue;
        }

        public void SetSettings(string key, object? value)
        {
            LocalSettings.Values[key] = value;
        }
    }
}
