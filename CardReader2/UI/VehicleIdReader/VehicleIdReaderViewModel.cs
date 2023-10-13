using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace CardReader.UI.VehicleIdReader
{
    public class VehicleIdReaderViewModel : ReactiveObject, IActivatableViewModel
    {
        [Reactive]
        public bool ShowMessage { get; set; }

        [Reactive]
        public InfoBarSeverity MessageSeverity { get; set; }

        [Reactive]
        public string MessageTitle { get; set; }

        [Reactive]
        public string Message { get; set; }

        [Reactive]
        public string CardReaderId { get; set; }

        [Reactive]
        public string CardReaderName { get; set; }

        [Reactive]
        public VehicleIdData ReaderData { get; set; }

        [Reactive]
        private bool CanRead { get; set; }

        [Reactive]
        private bool CanReport { get; set; }


        public ReactiveCommand<Unit, Unit> BeginReadCommand { get; }

        public ReactiveCommand<Unit, Unit> ClearReaderDataCommand { get; }

        public ReactiveCommand<Unit, Unit> ReaderDataReportCommand { get; }

        public ViewModelActivator Activator { get; }
        

        private readonly Subject<Unit> endReadCommand = new();
        private readonly Subject<Unit> endReportCommand = new();

        public VehicleIdReaderViewModel()
        {
            Activator = new ViewModelActivator();
            ReaderData = new VehicleIdData();

            var canRad = this.WhenAnyValue(x => x.CanRead);
            BeginReadCommand = ReactiveCommand.CreateFromTask(BeginReadAsync, canRad);

            ClearReaderDataCommand = ReactiveCommand.Create(ClearReaderData);

            var canReportChanged = this.WhenAnyValue(x => x.CanReport);
            ReaderDataReportCommand = ReactiveCommand.CreateFromObservable(() =>
                Observable.StartAsync(ReaderDataReportAsync).TakeUntil(endReportCommand), canReportChanged);

            this.WhenActivated(disposables =>
            {
                Disposable.Create(() =>
                    {
                        endReadCommand.OnNext(Unit.Default);
                        endReportCommand.OnNext(Unit.Default);
                    })
                    .DisposeWith(disposables);
            });
        }

        private async Task BeginReadAsync()
        {

        }

        private void ClearReaderData()
        {

        }

        private async Task ReaderDataReportAsync(CancellationToken ct)
        {

        }
    }
}
