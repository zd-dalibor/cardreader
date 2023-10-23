using Windows.ApplicationModel;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace CardReader.UI.About
{
    public class AboutViewModel : ReactiveObject
    {
        [Reactive]
        public string ApplicationVersion { get; set; }

        public AboutViewModel()
        {
            ApplicationVersion = GetAppVersion();
        }

        private static string GetAppVersion()
        {
            var package = Package.Current;
            var packageId = package.Id;
            var version = packageId.Version;
            return $"{version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }
    }
}
