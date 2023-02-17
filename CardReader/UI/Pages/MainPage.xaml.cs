// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using CardReader.UI.ViewModel.MainPage;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using CardReader.Service;
using Microsoft.UI.Xaml.Media.Animation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CardReader.UI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPageViewModel ViewModel { get; set; }

        private readonly IStringLoader stringLoader;

        public MainPage()
        {
            this.ViewModel = App.Current.Services.GetService<MainPageViewModel>();
            this.stringLoader = App.Current.Services.GetService<IStringLoader>();

            var navigationService = App.Current.Services.GetService<IMainNavigationService>();
            navigationService.Delegate.NavigateWithTransition += this.NavigateWithTransition;
            navigationService.Delegate.Navigate += this.Navigate;
            navigationService.Delegate.TryGoBack += this.TryGoBack;

            this.Loaded += MainPage_Loaded;

            this.InitializeComponent();
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.IsActive = true;
        }

        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            var navigation = (NavigationView)sender;
            var settingsItem = (NavigationViewItem)navigation.SettingsItem;

            settingsItem.Content = stringLoader.GetString("SettingsMenuItem/Text");

            // quick fix for https://github.com/microsoft/microsoft-ui-xaml/issues/6518
            navigation.PaneTitle = " ";
            navigation.PaneTitle = "";

            Navigate(ViewModel.SelectedMenuItem.Tag);
        }

        private void ContentFrame_OnNavigated(object sender, NavigationEventArgs e)
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
                NavigationView.SelectedItem = ViewModel.MenuItems.First(x => x.Tag.Equals(tag));
                NavigationView.Header = ((MenuItemViewModel)NavigationView.SelectedItem)?.Name;
            }
        }

        private void NavigationView_OnBackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            TryGoBack();
        }

        private void Navigate(string tag)
        {
            NavigateWithTransition(tag, new EntranceNavigationTransitionInfo());
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

        private static Type TagToPage(string tag)
        {
            return tag switch
            {
                "home" => typeof(HomePage),
                "id_reader" => typeof(IdReaderPage),
                "driver_license_reader" => typeof(DriverLicenseReaderPage),
                "settings" => typeof(SettingsPage),
                _ => null
            };
        }

        private static string PageToTag(Type page)
        {
            return page switch
            {
                not null when page == typeof(HomePage) => "home",
                not null when page == typeof(IdReaderPage) => "id_reader",
                not null when page == typeof(DriverLicenseReaderPage) => "driver_license_reader",
                not null when page == typeof(SettingsPage) => "settings",
                _ => null
            };
        }

        private void NavigationView_OnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                NavigateWithTransition("settings", args.RecommendedNavigationTransitionInfo);
            }
            else if (args.InvokedItemContainer != null)
            {
                var navItemTag = args.InvokedItemContainer.Tag.ToString();
                NavigateWithTransition(navItemTag, args.RecommendedNavigationTransitionInfo);
            }
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
    }
}
