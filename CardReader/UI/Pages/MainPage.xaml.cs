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
            this.ViewModel = App.Current.Services.GetService<MainPageViewModel>();
            this.stringLoader = App.Current.Services.GetService<IStringLoader>();

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
        }
    }
}
