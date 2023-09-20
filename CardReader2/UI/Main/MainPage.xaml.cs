using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using CardReader.Core.Service.Resources;
using CardReader.Infrastructure.Events;
using CardReader.UI.Home;
using CardReader.UI.IdReader;
using CardReader.UI.Settings;
using CardReader.UI.VehicleIdReader;
using Microsoft.UI.Xaml.Media.Animation;
using ReactiveUI;
using Splat;
using CardReader.Infrastructure.DependencyInjection;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CardReader.UI.Main
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        private readonly IApplicationResources resources;

        private NavigationViewItem settingsItem;

        public MainPage()
        {
            InitializeComponent();
            ViewModel = Locator.Current.GetRequiredService<MainViewModel>();
            resources = Locator.Current.GetRequiredService<IApplicationResources>();
            
            LoadStrings();
            this.WhenActivated(disposables =>
            {
                resources.Observe()
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Subscribe(_ => LoadStrings())
                    .DisposeWith(disposables);

                MessageBus.Current.Listen<ErrorEventArgs>()
                    .Select(args => Observable.FromAsync(async () => await OnError(args)))
                    .Concat()
                    .Subscribe()
                    .DisposeWith(disposables);
            });


            NavigationView.Loaded += NavigationView_Loaded;
            NavigationView.ItemInvoked += NavigationView_ItemInvoked;
            NavigationView.BackRequested += NavigationView_BackRequested;
            ContentFrame.Navigated += ContentFrame_Navigated;
        }

        private async Task OnError(ErrorEventArgs obj)
        {
            var dialog = new ContentDialog
            {
                Title = resources.GetString("ErrorDialogTitle"),
                Content = resources.GetString(("ErrorDialogContent"), obj.Error.Message),
                CloseButtonText = resources.GetString("ErrorDialogCloseText"),
                XamlRoot = Content.XamlRoot
            };
            await dialog.ShowAsync();
        }

        private void LoadStrings()
        {
            AppTitleBar.Text = resources.GetString("AppTitleBar/Text");
            SettingsItemContent();

            var selectedItem = NavigationView.SelectedItem;
            NavigationView.Header = selectedItem switch
            {
                MenuItem menuItem => menuItem.Name,
                NavigationViewItem viewItem => viewItem.Content,
                _ => NavigationView.Header
            };
        }

        private void SettingsItemContent()
        {
            if (settingsItem != null)
            {
                settingsItem.Content = resources.GetString("SettingsMenuItemName");
            }
        }

        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            var navigation = (NavigationView)sender;
            settingsItem = (NavigationViewItem)navigation.SettingsItem;

            SettingsItemContent();

            // quick fix for https://github.com/microsoft/microsoft-ui-xaml/issues/6518
            navigation.PaneTitle = " ";
            navigation.PaneTitle = "";

            Navigate(ViewModel!.SelectedMenuItem);
        }

        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            NavigationView.IsBackEnabled = ContentFrame.CanGoBack;

            if (ContentFrame.SourcePageType == typeof(SettingsPage))
            {
                NavigationView.SelectedItem = (NavigationViewItem)NavigationView.SettingsItem;
                NavigationView.Header = ((NavigationViewItem)NavigationView.SettingsItem).Content;
            }
            else if (ContentFrame.SourcePageType != null)
            {
                var tag = PageToTag(ContentFrame.SourcePageType);
                NavigationView.SelectedItem = ViewModel!.MenuItems.First(x => x.Tag.Equals(tag));
                NavigationView.Header = ((MenuItem)NavigationView.SelectedItem)?.Name;
            }
        }

        private void NavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            TryGoBack();
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                NavigateWithTransition(MainViewModel.SettingsPageTag, args.RecommendedNavigationTransitionInfo);
            }
            else if (args.InvokedItemContainer != null)
            {
                var navItemTag = args.InvokedItemContainer.Tag.ToString();
                NavigateWithTransition(navItemTag, args.RecommendedNavigationTransitionInfo);
            }
        }

        private void Navigate(object item)
        {
            var tag = item switch
            {
                MenuItem t => t.Tag,
                NavigationViewItem t => t.Tag as string,
                _ => null
            };
            NavigateWithTransition(tag, new EntranceNavigationTransitionInfo());
        }

        private bool TryGoBack()
        {
            if (!ContentFrame.CanGoBack)
                return false;

            // Don't go back if the nav pane is overlayed.
            if (NavigationView.IsPaneOpen &&
                NavigationView.DisplayMode is NavigationViewDisplayMode.Compact or NavigationViewDisplayMode.Minimal)
                return false;

            ContentFrame.GoBack();
            return true;
        }

        private void NavigateWithTransition(string tag, NavigationTransitionInfo transitionInfo)
        {
            var page = TagToPage(tag);
            var currentPage = ContentFrame.CurrentSourcePageType;

            if (page is not null && currentPage != page)
            {
                ContentFrame.Navigate(page, null, transitionInfo);
            }
        }

        private static string PageToTag(Type page)
        {
            return page switch
            {
                not null when page == typeof(HomePage) => MainViewModel.HomePageTag,
                not null when page == typeof(IdReaderPage) => MainViewModel.IdReaderPageTag,
                not null when page == typeof(VehicleIdReaderPage) => MainViewModel.VehicleIdReaderPageTag,
                not null when page == typeof(SettingsPage) => MainViewModel.SettingsPageTag,
                _ => null
            };
        }

        private static Type TagToPage(string tag)
        {
            return tag switch
            {
                MainViewModel.HomePageTag => typeof(HomePage),
                MainViewModel.IdReaderPageTag => typeof(IdReaderPage),
                MainViewModel.VehicleIdReaderPageTag => typeof(VehicleIdReaderPage),
                MainViewModel.SettingsPageTag => typeof(SettingsPage),
                _ => null
            };
        }
    }
}
