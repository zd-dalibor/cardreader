using System;
using System.Reactive;
using CardReader.UI.Main;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace CardReader.UI.Home
{
    public class HomeViewModel : ReactiveObject
    {
        public event EventHandler<string> Navigate;

        [Reactive]
        public ReactiveCommand<Unit, Unit> NavigateToIdReaderCommand { get; set; }

        [Reactive]
        public ReactiveCommand<Unit, Unit> NavigateToVehicleIdReaderCommand { get; set; }

        [Reactive]
        public ReactiveCommand<Unit, Unit> NavigateToSettingsCommand { get; set; }

        public HomeViewModel()
        {
            NavigateToIdReaderCommand = ReactiveCommand.Create(NavigateToIdReader);
            NavigateToVehicleIdReaderCommand = ReactiveCommand.Create(NavigateToVehicleIdReader);
            NavigateToSettingsCommand = ReactiveCommand.Create(NavigateToSettings);
        }

        private void NavigateToIdReader()
        {
            Navigate?.Invoke(this, MainViewModel.IdReaderPageTag);
        }

        private void NavigateToVehicleIdReader()
        {
            Navigate?.Invoke(this, MainViewModel.VehicleIdReaderPageTag);
        }

        private void NavigateToSettings()
        {
            Navigate?.Invoke(this, MainViewModel.SettingsPageTag);
        }
    }
}
