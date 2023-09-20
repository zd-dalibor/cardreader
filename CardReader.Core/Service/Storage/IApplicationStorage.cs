namespace CardReader.Core.Service.Storage
{
    public interface IApplicationStorage
    {
        object? GetSettings(string key);

        object GetSettings(string key, object defaultValue);

        void SetSettings(string key, object? value);
    }
}
