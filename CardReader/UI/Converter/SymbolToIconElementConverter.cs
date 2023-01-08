using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Text;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;

namespace CardReader.UI.Converter
{
    public class SymbolToIconElementConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (targetType != typeof(IconElement)) return DependencyProperty.UnsetValue;
            
            return value switch
            {
                Symbol sym => new SymbolIcon(sym),
                string str when str.StartsWith("crr#") => new FontIcon
                {
                    FontFamily = App.Current.Resources["CardReader"] as FontFamily, Glyph = str[4..]
                },
                string str when str.EndsWith(".svg") => new ImageIcon { Source = new SvgImageSource(new Uri(str)) },
                string str => new ImageIcon { Source = new BitmapImage(new Uri(str)) },
                _ => DependencyProperty.UnsetValue
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
