using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardReader.UI.ViewModel.MainPage
{
    public partial class MenuItemViewModel : ObservableObject
    {
        [ObservableProperty]
        private string tag;

        [ObservableProperty]
        private Symbol icon;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private ObservableCollection<MenuItemViewModel> children;
    }
}
