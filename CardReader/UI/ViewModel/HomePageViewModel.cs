using CardReader.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CardReader.UI.ViewModel
{
    public partial class HomePageViewModel : ObservableObject
    {
        #region strings
        [ObservableProperty]
        private string idReaderButtonText;

        [ObservableProperty]
        private string vehicleIdReaderButtonText;

        [ObservableProperty]
        private string settingsButtonText;
        #endregion

        private readonly IStringLoader stringLoader;
        private readonly IMainNavigationService mainNavigationService;

        public HomePageViewModel(IStringLoader stringLoader, IMainNavigationService mainNavigationService)
        {
            this.stringLoader = stringLoader;
            this.mainNavigationService = mainNavigationService;

            InitStrings();
        }

        private void InitStrings()
        {
            IdReaderButtonText = stringLoader.GetString("IdReaderItem/Text");
            VehicleIdReaderButtonText = stringLoader.GetString("VehicleIdReaderItem/Text");
            SettingsButtonText = stringLoader.GetString("SettingsMenuItem/Text");
        }

        [RelayCommand]
        private void NavigateToIdReader()
        {
            mainNavigationService.Navigate("id_reader");
        }

        [RelayCommand]
        private void NavigateToVehicleIdReader()
        {
            mainNavigationService.Navigate("vehicle_id_reader");
        }

        [RelayCommand]
        private void NavigateToSettings()
        {
            mainNavigationService.Navigate("settings");
        }
    }
}
