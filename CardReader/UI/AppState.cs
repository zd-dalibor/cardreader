using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardReader.Model;
using CardReader.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.UI.Xaml;

namespace CardReader.UI
{
    public partial class AppState : ObservableRecipient
    {
        [ObservableProperty]
        [NotifyPropertyChangedRecipients]
        private bool isMainWindowActive;

        [ObservableProperty]
        [NotifyPropertyChangedRecipients]
        private string idReaderCardReaderId;

        [ObservableProperty]
        private int idReaderApiVersion;

        [ObservableProperty]
        [NotifyPropertyChangedRecipients]
        private string vehicleIdReaderCardReaderId;

        [ObservableProperty]
        private int vehicleIdReaderApiVersion;

        [ObservableProperty]
        private IdReaderData lastIdReaderData;

        [ObservableProperty]
        private VehicleIdData lastVehicleIdData;

        private readonly IAppSettingsService appSettings;

        public AppState(IMessenger messenger, IAppSettingsService appSettings) : base(messenger)
        {
            this.appSettings = appSettings;

            idReaderCardReaderId = appSettings.GetIdReaderCardReaderId();
            idReaderApiVersion = appSettings.GetIdReaderApiVersion();
            vehicleIdReaderCardReaderId = appSettings.GetVehicleIdReaderCardReaderId();
            vehicleIdReaderApiVersion = appSettings.GetVehicleIdReaderApiVersion();
        }

        partial void OnIdReaderCardReaderIdChanged(string value)
        {
            appSettings.SaveIdReaderCardReaderId(value);
        }

        partial void OnVehicleIdReaderCardReaderIdChanged(string value)
        {
            appSettings.SaveVehicleIdReaderCardReaderId(value);
        }

        //private void NotifyPropertyChangedRecipients(string propertyName)
        //{
        //    Messenger.Send(new AppStateChangedMessage(this, propertyName));
        //}
    }
}
