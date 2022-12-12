using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media.Imaging;

namespace CardReader.UI.Converter
{
    public class SymbolToIconElementConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (targetType == typeof(IconElement))
            {
                return value switch
                {
                    Symbol obj => new SymbolIcon(obj),
                    string obj => new ImageIcon
                    {
                        Source = obj.EndsWith(".svg") ? new SvgImageSource(new Uri(obj)) : new BitmapImage(new Uri(obj))
                    },
                    _ => DependencyProperty.UnsetValue
                };
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
