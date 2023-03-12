using CardReader.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace CardReader.UI.ViewModel.MainPage
{
    public partial class MainPageViewModel : ObservableRecipient, IRecipient<PropertyChangedMessage<object>>
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
        private readonly AppState appState;

        public MainPageViewModel(AppState appState, IStringLoader stringLoader, IMessenger messenger) : base(messenger)
        {
            this.stringLoader = stringLoader;
            this.appState = appState;

            IsMainWindowActive = appState.IsMainWindowActive;

            InitStrings();
            InitMenuItems();
        }

        public void Receive(PropertyChangedMessage<object> message)
        {
            if (message.Sender.Equals(appState) && message.PropertyName == nameof(AppState.IsMainWindowActive))
            {
                IsMainWindowActive = (bool) message.NewValue;
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
