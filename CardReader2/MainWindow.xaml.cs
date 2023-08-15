using Microsoft.UI.Xaml;
using System;
using CardReader.Core.State;
using CardReader.Core.Redux;
using CardReader.Core.Service.Resources;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Windows.Graphics;
using CardReader.Core.Service.Configuration;
using CardReader.Infrastructure.Extensions;
using Splat;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CardReader
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
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

            UpdateWindowSize();
        }

        private void UpdateWindowSize()
        {
            var scale = this.GetDpiForWindow() / 96F;
            var width = settings.WindowWidth((int) (DefaultWindowWidth * scale));
            var height = settings.WindowHeight((int) (DefaultWindowHeight * scale));
            AppWindow.Resize(new SizeInt32(width, height));
        }

        private void MainWindow_SizeChanged(object sender, WindowSizeChangedEventArgs args)
        {
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
            store.Dispatch(new ChangeMainWindowActivationAction
            {
                IsActive = args.WindowActivationState != WindowActivationState.Deactivated
            });
        }
    }
}
