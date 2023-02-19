using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardReader.Service;
using CardReader.UI.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.UI.Xaml;

namespace CardReader.UI
{
    public partial class AppState : ObservableRecipient
    {
        [ObservableProperty]
        private bool isMainWindowActive;

        [ObservableProperty]
        private string idReaderCardReaderId;

        [ObservableProperty]
        private string driverLicenseReaderCardReaderId;

        private readonly IAppSettingsService appSettings;

        public AppState(IMessenger messenger, IAppSettingsService appSettings) : base(messenger)
        {
            this.appSettings = appSettings;

            idReaderCardReaderId = appSettings.GetIdReaderCardReaderId();
            driverLicenseReaderCardReaderId = appSettings.GetDriverLicenseReaderCardReaderId();
        }

        partial void OnIsMainWindowActiveChanged(bool value)
        {
            NotifyPropertyChangedRecipients(nameof(IsMainWindowActive));
        }

        partial void OnIdReaderCardReaderIdChanged(string value)
        {
            appSettings.SaveIdReaderCardReaderId(value);
            NotifyPropertyChangedRecipients(nameof(IdReaderCardReaderId));
        }

        partial void OnDriverLicenseReaderCardReaderIdChanged(string value)
        {
            appSettings.SaveDriverLicenseReaderCardReaderId(value);
            NotifyPropertyChangedRecipients(nameof(DriverLicenseReaderCardReaderId));
        }

        private void NotifyPropertyChangedRecipients(string propertyName)
        {
            Messenger.Send(new AppStateChangedMessage(this, propertyName));
        }
    }
}
