using CommunityToolkit.Mvvm.ComponentModel;

namespace CardReader.UI.Controls.Shell
{
    public partial class Page : ObservableObject
    {
        [ObservableProperty]
        private string name;
    }
}
