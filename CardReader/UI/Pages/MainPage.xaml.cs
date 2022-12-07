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
            this.InitializeComponent();
            this.ViewModel = App.Current.Services.GetService<MainPageViewModel>();
            this.stringLoader = App.Current.Services.GetService<IStringLoader>();
        }

        private void NavigationView_DisplayModeChanged(NavigationView sender, NavigationViewDisplayModeChangedEventArgs args)
        {
            var titleBarMargin = new Thickness(0, 0, 126, 0);
            switch (args.DisplayMode)
            {
                case NavigationViewDisplayMode.Expanded:
                case NavigationViewDisplayMode.Compact:
                    titleBarMargin.Left = sender.IsBackButtonVisible switch
                    {
                        NavigationViewBackButtonVisible.Auto or NavigationViewBackButtonVisible.Visible => 48,
                        _ => 0
                    };
                    break;
                case NavigationViewDisplayMode.Minimal:
                    titleBarMargin.Left = sender.IsBackButtonVisible switch
                    {
                        NavigationViewBackButtonVisible.Auto or NavigationViewBackButtonVisible.Visible => 84,
                        _ => 0
                    };
                    break;
            }

            AppTitleBar.Margin = titleBarMargin;
        }

        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            ((NavigationViewItem)((NavigationView)sender).SettingsItem).Content = stringLoader.GetString("SettingsMenuItem/Text");
        }
    }
}
