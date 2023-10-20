using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using CardReader.Core.Service.Resources;
using CardReader.UI.Main;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using ReactiveUI;
using Splat;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CardReader.UI.Home
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage
    {
        private readonly IApplicationResources resources;

        private MainPage mainPage;

        public HomePage()
        {
            this.InitializeComponent();
            ViewModel = Locator.Current.GetService<HomeViewModel>();
            resources = Locator.Current.GetService<IApplicationResources>();

            LoadStrings();

            this.WhenActivated(disposables =>
            {
                resources.Observe()
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Subscribe(_ => LoadStrings())
                    .DisposeWith(disposables);
            });

            Loaded += HomePage_Loaded;
            ViewModel.Navigate += ViewModel_Navigate;
        }

        private void ViewModel_Navigate(object sender, string e)
        {
            if (mainPage == null) return;
            mainPage.NavigateWithTransition(e, new EntranceNavigationTransitionInfo());
        }

        private void HomePage_Loaded(object sender, RoutedEventArgs e)
        {
            mainPage = GetMainPage(this);
        }

        private static MainPage GetMainPage(DependencyObject src)
        {
            while (true)
            {
                var parent = VisualTreeHelper.GetParent(src);
                if (parent == null) return null;

                if (parent is MainPage mainPage)
                {
                    return mainPage;
                }

                src = parent;
            }
        }

        private void LoadStrings()
        {
            IdReaderButtonCtl.Content = resources.GetString("IdReaderButtonCtl/Content");
            VehicleIdReaderButtonCtl.Content = resources.GetString("VehicleIdReaderButtonCtl/Content");
            SettingsButtonCtl.Content = resources.GetString("SettingsButtonCtl/Content");
        }
    }
}
