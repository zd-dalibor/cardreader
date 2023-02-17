using Microsoft.UI.Xaml.Media.Animation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardReader.Service
{
    public class MainNavigationServiceDelegate
    {
        public delegate void NavigateWithTransitionHandler(string tag, NavigationTransitionInfo transitionInfo);

        public delegate void NavigateHandler(string tag);

        public delegate bool TryGoBackHandler();

        public NavigateWithTransitionHandler NavigateWithTransition { get; set; }

        public NavigateHandler Navigate { get; set; }

        public TryGoBackHandler TryGoBack { get; set; }
    }
}
