using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public AppState(IMessenger messenger) : base(messenger)
        {
        }

        partial void OnIsMainWindowActiveChanged(bool value)
        {
            NotifyPropertyChangedRecipients(nameof(IsMainWindowActive));
        }

        private void NotifyPropertyChangedRecipients(string propertyName)
        {
            Messenger.Send(new AppStateChangedMessage(this, propertyName, this, this));
        }
    }
}
