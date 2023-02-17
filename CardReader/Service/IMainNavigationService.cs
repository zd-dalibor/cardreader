using Microsoft.UI.Xaml.Media.Animation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardReader.Service
{
    public interface IMainNavigationService
    {
        public MainNavigationServiceDelegate Delegate { get; }

        public void NavigateWithTransition(string tag, NavigationTransitionInfo transitionInfo);

        public void Navigate(string tag);

        public bool TryGoBack();
    }
}
