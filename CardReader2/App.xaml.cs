using System;
using System.Linq;
using CardReader.Core.Service.Configuration;
using Microsoft.UI.Xaml;
using CardReader.Infrastructure.DependencyInjection;
using Microsoft.UI;
using Splat;
using UnhandledExceptionEventArgs = Microsoft.UI.Xaml.UnhandledExceptionEventArgs;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CardReader
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            Infrastructure.DependencyInjection.Services.Configure();

            this.InitializeComponent();
            UnhandledException += OnUnhandledException;
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

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                LogHost.Default.Error(e.Exception, e.Message);
            }
            catch (LoggingException) { }
        }

        public ElementTheme GetTheme()
        {
            return ((MainWindow)mWindow).GetTheme();
        }

        public void SetTheme(ElementTheme theme)
        {
            ((MainWindow)mWindow).SetTheme(theme);
        }

        public new static App Current => (App)Application.Current;

        private Window mWindow;
    }
}
