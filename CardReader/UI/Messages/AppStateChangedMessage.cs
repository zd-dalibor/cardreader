using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace CardReader.UI.Messages
{
    public class AppStateChangedMessage : PropertyChangedMessage<AppState>
    {
        public AppStateChangedMessage(object sender, string propertyName, AppState oldValue, AppState newValue) : base(sender, propertyName, oldValue, newValue)
        {
        }
    }
}
