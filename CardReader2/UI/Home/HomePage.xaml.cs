using System;
using System.Diagnostics;
using System.Reactive.Disposables;
using CardReader.Core.Service.Resources;
using ReactiveUI;
using Splat;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CardReader.UI.Home
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : HomePageBase
    {
        public HomePage()
        {
            this.InitializeComponent();
            ViewModel = Locator.Current.GetService<HomeViewModel>();
            var resources = Locator.Current.GetService<IApplicationResources>();

            this.WhenActivated(disposables =>
            {
                resources.Observe()
                    .Subscribe(_ => Debug.WriteLine("Language changed!!!"))
                    .DisposeWith(disposables);
            });
        }
    }
}
