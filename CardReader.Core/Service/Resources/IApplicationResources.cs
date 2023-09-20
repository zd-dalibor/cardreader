namespace CardReader.Core.Service.Resources
{
    public interface IApplicationResources
    {
        string GetString(string resource, bool forCurrentView = false);

        string GetString(string resource, params object?[] objects);

        string GetString(string resource, bool forCurrentView, params object?[] objects);

        IObservable<IDictionary<string, string>> Observe();
    }
}
