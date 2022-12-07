using CardReader.Service;
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
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<MenuItemViewModel> menuItems;

        #region strings
        [ObservableProperty]
        private string appTitleText;
        #endregion

        private readonly IStringLoader stringLoader;

        public MainPageViewModel(IStringLoader stringLoader)
        {
            this.stringLoader = stringLoader;

            InitStrings();
            InitMenuItems();
        }

        private void InitStrings()
        {
            AppTitleText = stringLoader.GetString("AppTitle/Text");
        }

        private void InitMenuItems()
        {
            MenuItems = new ObservableCollection<MenuItemViewModel>
            {
                new MenuItemViewModel
                {
                    Tag = "home",
                    Name = stringLoader.GetString("HomeMenuItem/Text"),
                    Icon = Symbol.Home
                }
            };
        }
    }
}
