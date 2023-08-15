using System;
using System.Diagnostics;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using CardReader.Core.Redux;
using CardReader.Core.State;
using ReactiveUI;

namespace CardReader.UI.Home
{
    public class HomeViewModel : ReactiveObject, IActivatableViewModel
    {
        public ViewModelActivator Activator { get; }

        public HomeViewModel(IStore<IApplicationState> store)
        {
            Activator = new ViewModelActivator();
            var counter = 0;

            this.WhenActivated(disposables =>
            {
                store.DistinctUntilChanged(x => new {x.IsMainWindowActive}).Subscribe(_ =>
                {
                    counter++;
                    Debug.WriteLine($"Counter is: {counter}");
                }).DisposeWith(disposables);
            });
        }
    }
}
