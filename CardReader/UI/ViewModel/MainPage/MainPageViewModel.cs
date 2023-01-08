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

            IsMainWindowActive = appState.IsMainWindowActive;

            InitStrings();
            InitMenuItems();
        }

        public void Receive(AppStateChangedMessage message)
        {
            IsMainWindowActive = message.PropertyName switch
            {
                nameof(AppState.IsMainWindowActive) => message.NewValue.IsMainWindowActive,
                _ => IsMainWindowActive
            };
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
                        Icon = "crr#\xea02"
                    }
                },
                {
                    "id_reader", new MenuItemViewModel
                    {
                        Tag = "id_reader",
                        Name = stringLoader.GetString("IdReaderItem/Text"),
                        Icon = "crr#\xea03"
                    }
                },
                {
                    "driver_license_reader", new MenuItemViewModel
                    {
                        Tag = "driver_license_reader",
                        Name = stringLoader.GetString("DriverLicenseReaderItem/Text"),
                        Icon = "crr#\xea01"
                    }
                }
            };

            MenuItems = new ObservableCollection<MenuItemViewModel>(menuItemsDictionary.Values);
            SelectedMenuItem = MenuItems[0];
        }
    }
}
