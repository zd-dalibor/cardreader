using Microsoft.UI.Xaml;
using CardReader.Infrastructure.DependencyInjection;
using Splat;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CardReader
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            Infrastructure.DependencyInjection.Services.Configure();

            this.InitializeComponent();

            // App.Current.RequestedTheme = ApplicationTheme.Light;
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            Locator.Current
                .InitLocale()
                .StartResourceObserver();

            mWindow = new MainWindow();
            mWindow.Activate();
        }

        public new static App Current => (App)Application.Current;

        private Window mWindow;
    }
}
