using System;
using System.Linq;
using System.Reactive.Linq;
using CardReader.Core.Service.Configuration;
using Microsoft.UI.Xaml;
using CardReader.Infrastructure.DependencyInjection;
using CardReader.UI.Helper;
using ReactiveUI;
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
            UpdateTheme();
            ObserveThemeChange();
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

        public ElementTheme UserTheme()
        {
            return mUserTheme == ApplicationTheme.Dark
                ? ElementTheme.Dark : ElementTheme.Light;
        }

        private static ElementTheme CurrentTheme()
        {
            var currentTheme = Locator.Current.GetRequiredService<IApplicationSettings>().AppTheme();
            if (currentTheme == null) return ElementTheme.Default;

            var availableThemes = Enum.GetNames(typeof(ElementTheme));
            var themeStr = availableThemes.FirstOrDefault(x => x.Equals(currentTheme));
            if (themeStr != null && Enum.TryParse(themeStr, out ElementTheme theme))
            {
                return theme;
            }

            return ElementTheme.Default;
        }

        private void UpdateTheme()
        {
            mUserTheme = RequestedTheme;
            var theme = CurrentTheme();
            switch (theme)
            {
                case ElementTheme.Dark:
                    RequestedTheme = ApplicationTheme.Dark;
                    break;
                case ElementTheme.Light:
                    RequestedTheme = ApplicationTheme.Light;
                    break;
                case ElementTheme.Default:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ObserveThemeChange()
        {
            Locator.Current.GetRequiredService<ThemeHelper>().Observe()
                .DistinctUntilChanged()
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(isDarkMode =>
                {
                    mUserTheme = isDarkMode ? ApplicationTheme.Dark : ApplicationTheme.Light;
                    if (mWindow != null && CurrentTheme() == ElementTheme.Default)
                    {
                        SetTheme(UserTheme());
                    }
                });
        }

        public new static App Current => (App)Application.Current;

        private Window mWindow;

        private ApplicationTheme mUserTheme;
    }
}
