using CardReader.UI.Pages;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardReader.UI
{
    public class Shell
    {
        public Window Window { get; private set; }

        public MainPage MainPage { get; private set; }

        public void Init()
        {
            this.MainPage = new MainPage();

            this.Window = new Window();
            this.Window.Activated += Window_Activated;

            this.Window.Content = this.MainPage;
            this.Window.ExtendsContentIntoTitleBar = true;
            this.Window.SetTitleBar(this.MainPage.AppTitleBar);

            this.Window.Activate();
        }

        private void Window_Activated(object sender, WindowActivatedEventArgs args)
        {
            if (args.WindowActivationState == WindowActivationState.Deactivated)
            {
                this.MainPage.AppTitleTextBlock.Foreground =
                    (SolidColorBrush)App.Current.Resources["WindowCaptionForegroundDisabled"];
            }
            else
            {
                this.MainPage.AppTitleTextBlock.Foreground =
                    (SolidColorBrush)App.Current.Resources["WindowCaptionForeground"];
            }
        }
    }
}
