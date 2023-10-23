using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using CardReader.Core.Service.Resources;
using ReactiveUI;
using Splat;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CardReader.UI.About
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AboutPage
    {
        private readonly IApplicationResources resources;

        public AboutPage()
        {
            this.InitializeComponent();
            ViewModel = Locator.Current.GetService<AboutViewModel>();
            resources = Locator.Current.GetService<IApplicationResources>();

            LoadStrings();

            this.WhenActivated(disposable =>
            {
                resources.Observe()
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Subscribe(_ => LoadStrings())
                    .DisposeWith(disposable);
            });
        }

        private void LoadStrings()
        {
            ApplicationNameCtl.Text = resources.GetString("ApplicationNameCtl/Text");
            ApplicationVersionLbl.Text = resources.GetString("ApplicationVersionLbl/Text");
            ApplicationAuthorLbl.Text = resources.GetString("ApplicationAuthorLbl/Text");
            ApplicationAuthorCtl.Text = resources.GetString("ApplicationAuthorCtl/Text");
        }
    }
}
