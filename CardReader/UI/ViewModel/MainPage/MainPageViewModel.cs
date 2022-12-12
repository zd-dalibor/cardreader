using CardReader.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardReader.UI.Messages;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.UI.Xaml;

namespace CardReader.UI.ViewModel.MainPage
{
    public partial class MainPageViewModel : ObservableRecipient, IRecipient<AppStateChangedMessage>
    {
        [ObservableProperty]
        private ObservableCollection<MenuItemViewModel> menuItems;

        [ObservableProperty]
        private MenuItemViewModel selectedMenuItem;

        [ObservableProperty]
        private ApplicationTheme currentTheme;

        [ObservableProperty]
        private bool isMainWindowActive;

        #region strings
        [ObservableProperty]
        private string appTitleText;
        #endregion

        private readonly IStringLoader stringLoader;
        private Dictionary<string, MenuItemViewModel> menuItemsDictionary;

        public MainPageViewModel(AppState appState, IStringLoader stringLoader, IMessenger messenger) : base(messenger)
        {
            this.stringLoader = stringLoader;

            CurrentTheme = appState.CurrentTheme;
            IsMainWindowActive = appState.IsMainWindowActive;

            InitStrings();
            InitMenuItems();
        }

        public void Receive(AppStateChangedMessage message)
        {
            switch (message.PropertyName)
            {
                case nameof(AppState.CurrentTheme):
                    CurrentTheme = message.NewValue.CurrentTheme;
                    menuItemsDictionary["id_reader"].Icon = IdReaderMenuItemIcon();
                    break;
                case nameof(AppState.IsMainWindowActive):
                    IsMainWindowActive = message.NewValue.IsMainWindowActive;
                    break;
            }
        }

        private void InitStrings()
        {
            AppTitleText = stringLoader.GetString("AppTitle/Text");
        }

        private void InitMenuItems()
        {
            menuItemsDictionary = new Dictionary<string, MenuItemViewModel>
            {
                {
                    "home", new MenuItemViewModel
                    {
                        Tag = "home",
                        Name = stringLoader.GetString("HomeMenuItem/Text"),
                        Icon = Symbol.Home
                    }
                },
                {
                    "id_reader", new MenuItemViewModel
                    {
                        Tag = "id_reader",
                        Name = stringLoader.GetString("IdReaderItem/Text"),
                        Icon = IdReaderMenuItemIcon()
                    }
                },
                {
                    "driver_license_reader", new MenuItemViewModel
                    {
                        Tag = "driver_license_reader",
                        Name = stringLoader.GetString("DriverLicenseReaderItem/Text"),
                        Icon = Symbol.Folder
                    }
                }
            };

            MenuItems = new ObservableCollection<MenuItemViewModel>(menuItemsDictionary.Values);
            SelectedMenuItem = MenuItems[0];
        }

        private string IdReaderMenuItemIcon()
        {
            return CurrentTheme == ApplicationTheme.Light
                ? "ms-appx:///Assets/Light/badge_FILL0_wght400_GRAD0_opsz48.svg"
                : "ms-appx:///Assets/Dark/badge_FILL0_wght400_GRAD0_opsz48.svg";
        }
    }
}
