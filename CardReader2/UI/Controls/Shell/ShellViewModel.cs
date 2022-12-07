using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CardReader.UI.Controls.Shell
{
    public partial class ShellViewModel : ObservableObject
    {
        [ObservableProperty]
        public Page currentPage;

        [ObservableProperty]
        private ObservableCollection<MenuItem> menuItems;

        public ICommand NavigationCommand { get; }

        public void Navigate(Page page)
        {
            CurrentPage = page;
        }
    }
}
