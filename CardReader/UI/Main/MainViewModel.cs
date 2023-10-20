using System;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using CardReader.Core.Redux;
using CardReader.Core.Service.Resources;
using CardReader.Core.State;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace CardReader.UI.Main
{
    public class MainViewModel : ReactiveObject, IActivatableViewModel
    {
        public const string HomePageTag = "home";

        public const string IdReaderPageTag = "id_reader";

        public const string VehicleIdReaderPageTag = "vehicle_id_reader";

        public const string SettingsPageTag = "settings";

        [Reactive]
        public bool IsMainWindowActive { get; set; }

        [Reactive]
        public IObservableCollection<MenuItem> MenuItems { get; set; }

        [Reactive]
        public object SelectedMenuItem { get; set; }

        public ViewModelActivator Activator { get; }

        private readonly ISourceCache<MenuItem, string> menuItemsSource = new SourceCache<MenuItem, string>(t => t.Tag);

        private readonly IApplicationResources resources;

        public MainViewModel(IStore<IApplicationState> store, IApplicationResources resources)
        {
            this.resources = resources;
            Activator = new ViewModelActivator();
            MenuItems = new ObservableCollectionExtended<MenuItem>();
            IsMainWindowActive = store.State.IsMainWindowActive;

            InitMenuItems();
            LoadStrings();

            this.WhenActivated(disposables =>
            {
                menuItemsSource.Connect()
                    .Bind(MenuItems)
                    .Subscribe()
                    .DisposeWith(disposables);
                store.DistinctUntilChanged(state => new { state.IsMainWindowActive })
                    .Subscribe(state => IsMainWindowActive = state.IsMainWindowActive)
                    .DisposeWith(disposables);
                resources.Observe()
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Subscribe(_ => LoadStrings())
                    .DisposeWith(disposables);

                SelectedMenuItem = menuItemsSource.Items.First();
            });
        }

        private void LoadStrings()
        {
            menuItemsSource.Edit(t =>
            {
                foreach (var menuItem in t.Items)
                {
                    menuItem.Name = menuItem.Tag switch
                    {
                        HomePageTag => resources.GetString("HomeMenuItemName"),
                        IdReaderPageTag => resources.GetString("IdReaderItemName"),
                        VehicleIdReaderPageTag => resources.GetString("VehicleIdReaderItemName"),
                        _ => menuItem.Name
                    };
                }
            });
        }

        private void InitMenuItems()
        {
            menuItemsSource.Edit(t =>
            {
                t.AddOrUpdate(new []
                {
                    new MenuItem
                    {
                        Tag = HomePageTag,
                        Icon = "crr#\xea02"
                    },
                    new MenuItem
                    {
                        Tag = IdReaderPageTag,
                        Icon = "crr#\xea03"
                    },
                    new MenuItem
                    {
                        Tag = VehicleIdReaderPageTag,
                        Icon = "crr#\xea01"
                    }
                });
            });
        }
    }
}
