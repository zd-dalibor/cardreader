using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using CardReader.Core.Service.Configuration;
using CardReader.Core.Service.Globalization;
using CardReader.Services.Globalization;
using Splat;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CardReader.UI.Settings
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        private readonly SettingsViewModel viewModel;

        private readonly ILocaleService localeService;

        private readonly IApplicationSettings settings;

        public SettingsPage()
        {
            this.InitializeComponent();

            localeService = Locator.Current.GetService<ILocaleService>();
            settings = Locator.Current.GetService<IApplicationSettings>();

            viewModel = Locator.Current.GetService<SettingsViewModel>();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var currentLocale = settings.CurrentLocale(localeService.DefaultLocale);
            localeService.ChangeLocale("en-US".Equals(currentLocale) ? "sr-Latn-RS" : "en-US");
        }
    }
}
