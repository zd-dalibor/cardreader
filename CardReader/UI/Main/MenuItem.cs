using System.Collections.ObjectModel;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace CardReader.UI.Main
{
    public class MenuItem : ReactiveObject
    {
        [Reactive]
        public string Tag { get; set; }

        [Reactive]
        public object Icon { get; set; }

        [Reactive]
        public string Name { get; set; }

        [Reactive]
        public ObservableCollection<MenuItem> Children { get; set; }
    }
}
