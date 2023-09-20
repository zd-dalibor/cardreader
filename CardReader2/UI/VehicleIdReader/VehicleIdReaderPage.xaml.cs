using Splat;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CardReader.UI.VehicleIdReader
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VehicleIdReaderPage
    {
        public VehicleIdReaderPage()
        {
            ViewModel = Locator.Current.GetService<VehicleIdReaderViewModel>();
            this.InitializeComponent();
        }
    }
}
