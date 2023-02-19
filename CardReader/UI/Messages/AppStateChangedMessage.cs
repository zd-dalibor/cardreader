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
        public AppStateChangedMessage(AppState sender, string propertyName) : base(sender, propertyName, sender, sender)
        {
        }
    }
}
