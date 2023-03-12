using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardReader.UI.Messages
{
    public class ErrorMessage : ValueChangedMessage<Exception>
    {
        public ErrorMessage(Exception value) : base(value)
        {
        }
    }
}
