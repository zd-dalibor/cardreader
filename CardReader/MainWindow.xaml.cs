using Microsoft.UI.Xaml;
using System;
using System.Diagnostics;
using CardReader.Core.State;
using CardReader.Core.Redux;
using CardReader.Core.Service.Resources;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Windows.Graphics;
using CardReader.Core.Service.Configuration;
using CardReader.Infrastructure.Extensions;
using Microsoft.UI;
using Splat;
using System.Linq;
using Windows.UI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CardReader
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow
    {
        private const int DefaultWindowWidth = 1200;

        private const int DefaultWindowHeight = 800;

        private readonly IStore<IApplicationState> store;

        private readonly IApplicationResources resources;

        private readonly IApplicationSettings settings;

        private readonly CompositeDisposable disposables = new();

        public MainWindow()
        {
            InitializeComponent();
            resources = Locator.Current.GetService<IApplicationResources>();
            store = Locator.Current.GetService<IStore<IApplicationState>>();
            settings = Locator.Current.GetService<IApplicationSettings>();

            LoadStrings();
            resources.Observe()
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(_ => LoadStrings())
                .DisposeWith(disposables);

            ExtendsContentIntoTitleBar = true;
            SetTitleBar(MainPage.AppTitleBar);

            SizeChanged += MainWindow_SizeChanged;
            Activated += MainWindow_Activated;
            Closed += MainWindow_Closed;

            UpdateTheme();
            UpdateWindowSize();
        }

        

        public ElementTheme GetTheme()
        {
            return MainPage.RequestedTheme;
        }

        public void SetTheme(ElementTheme theme)
        {
            MainPage.RequestedTheme = theme;
            UpdateTitleBar(theme);
        }

        private void UpdateTitleBar(ElementTheme? theme = default)
        {
            Color color;
            if (theme is null or ElementTheme.Default)
            {
                color = App.Current.UserTheme() == ElementTheme.Dark ? Colors.White : Colors.Black;
            }
            else
            {
                color = theme == ElementTheme.Dark ? Colors.White : Colors.Black;
            }
            var res = App.Current.Resources;
            res["WindowCaptionForeground"] = color;
            AppWindow.TitleBar.ButtonForegroundColor = color;
        }

        private void UpdateTheme()
        {
            var appTheme = settings.AppTheme();
            var availableThemes = Enum.GetNames(typeof(ElementTheme));
            var themeStr = availableThemes.FirstOrDefault(x => x.Equals(appTheme));
            if (themeStr != null && Enum.TryParse(themeStr, out ElementTheme theme))
            {
                SetTheme(theme);
            }
            else
            {
                UpdateTitleBar();
            }
        }

        private void UpdateWindowSize()
        {
            var windowMaximized = settings.IsWindowMaximized();
            var scale = this.GetDpiForWindow() / 96F;
            var width = settings.WindowWidth((int) (DefaultWindowWidth * scale));
            var height = settings.WindowHeight((int) (DefaultWindowHeight * scale));
            AppWindow.Resize(new SizeInt32(width, height));

            if (windowMaximized)
            {
                this.MaximizeWindow();
            }
        }

        private void MainWindow_SizeChanged(object sender, WindowSizeChangedEventArgs args)
        {
            var windowMaximized = this.IsWindowMaximized();
            settings.UpdateWindowMaximized(windowMaximized);

            if (windowMaximized) return;
            var size = AppWindow.Size;
            settings.UpdateWindowWidth(size.Width);
            settings.UpdateWindowHeight(size.Height);
        }

        private void MainWindow_Closed(object sender, WindowEventArgs args)
        {
            disposables.Dispose();
        }

        private void LoadStrings()
        {
            Title = resources.GetString("AppDisplayName");
        }

        private void MainWindow_Activated(object sender, WindowActivatedEventArgs args)
        {
            Debug.WriteLine("MainWindow_Activated, IsWindowMaximized: " + this.IsWindowMaximized());
            store.Dispatch(new ChangeMainWindowActivationAction
            {
                IsActive = args.WindowActivationState != WindowActivationState.Deactivated
            });
        }
    }
}
