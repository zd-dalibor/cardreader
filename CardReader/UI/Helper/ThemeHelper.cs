using System;
using System.Reactive.Subjects;
using Windows.UI;
using Windows.UI.ViewManagement;

namespace CardReader.UI.Helper
{
    internal class ThemeHelper
    {
        private readonly UISettings settings = new();

        private readonly Subject<bool> subject = new();

        public ThemeHelper()
        {
            Init();
        }

        private static bool IsColorLight(Color clr)
        {
            return (((5 * clr.G) + (2 * clr.R) + clr.B) > (8 * 128));
        }

        private bool IsDarkMode()
        {
            var foreground = settings.GetColorValue(UIColorType.Foreground);
            return IsColorLight(foreground);
        }

        private void Init()
        {
            settings.ColorValuesChanged += (sender, args) =>
            {
                subject.OnNext(IsDarkMode());
            };
        }

        public IObservable<bool> Observe()
        {
            return subject;
        }
    }
}
