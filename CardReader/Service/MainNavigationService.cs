using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media.Animation;

namespace CardReader.Service
{
    public class MainNavigationService : IMainNavigationService
    {
        public MainNavigationServiceDelegate Delegate { get; }

        public MainNavigationService()
        {
            Delegate = new MainNavigationServiceDelegate();
        }

        public void Navigate(string tag)
        {
            Delegate.Navigate?.Invoke(tag);
        }

        public void NavigateWithTransition(string tag, NavigationTransitionInfo transitionInfo)
        {
            Delegate.NavigateWithTransition?.Invoke(tag, transitionInfo);
        }

        public bool TryGoBack()
        {
            return Delegate.TryGoBack?.Invoke() ?? false;
        }
    }
}
