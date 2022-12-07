using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace CardReader.UI.Controls.Shell
{
    public partial class MenuItem : ObservableObject
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string icon;

        [ObservableProperty]
        private string tag;

        [ObservableProperty]
        private ObservableCollection<MenuItem> children;
    }
}
