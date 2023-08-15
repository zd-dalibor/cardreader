namespace CardReader.Core.Service.Resources
{
    public interface IApplicationResources
    {
        string GetString(string resource, bool forCurrentView = false);

        IObservable<IDictionary<string, string>> Observe();
    }
}
