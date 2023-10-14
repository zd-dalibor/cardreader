using System;
using System.Reactive.Disposables;
using CardReader.Core.Service.Resources;
using CardReader.Infrastructure.DependencyInjection;
using ReactiveUI;
using Splat;
using System.Reactive.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CardReader.UI.Settings
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage
    {
        private readonly IApplicationResources resources;

        public SettingsPage()
        {
            this.InitializeComponent();
            ViewModel = Locator.Current.GetService<SettingsViewModel>();
            resources = Locator.Current.GetRequiredService<IApplicationResources>();

            LoadStrings();
            this.WhenActivated(disposables =>
            {
                resources.Observe()
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Subscribe(_ => LoadStrings())
                    .DisposeWith(disposables);
            });
        }

        private void LoadStrings()
        {
            SelectLanguageCtl.Header = resources.GetString("SelectLanguageCtl/Header");
            SelectThemeCtl.Header = resources.GetString("SelectThemeCtl/Header");
        }
    }
}
