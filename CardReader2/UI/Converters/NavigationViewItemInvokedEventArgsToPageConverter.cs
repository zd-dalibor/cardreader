using CardReader.ViewModel.MainWindow;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardReader.UI.Converters
{
    public class NavigationViewItemInvokedEventArgsToPageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is NavigationViewItemInvokedEventArgs args)
            {
                var page = new ViewModel.MainWindow.Page();
                if (args.IsSettingsInvoked)
                {
                    page.Name = "settings";
                }
                else
                {
                    page.Name = args.InvokedItemContainer.Tag.ToString();
                }
                return page;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
