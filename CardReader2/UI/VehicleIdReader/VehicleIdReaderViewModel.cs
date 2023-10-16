using System;
using System.Net.NetworkInformation;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using CardReader.Core.Service.Configuration;
using CardReader.Core.Service.Resources;
using CardReader.Core.Service.VehicleIdReader;
using CardReader.Core.State;
using CardReader.Infrastructure.Exceptions;
using Microsoft.UI.Xaml.Controls;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Serilog.Core;
using Splat;

namespace CardReader.UI.VehicleIdReader
{
    public class VehicleIdReaderViewModel : ReactiveObject, IActivatableViewModel, IEnableLogger
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

        private readonly IApplicationState applicationState;
        private readonly IApplicationResources applicationResources;
        private readonly IVehicleIdReaderService vehicleIdReaderService;

        public VehicleIdReaderViewModel(
            IApplicationState applicationState, 
            IApplicationResources applicationResources, 
            IVehicleIdReaderService vehicleIdReaderService)
        {
            this.applicationState = applicationState;
            this.applicationResources = applicationResources;
            this.vehicleIdReaderService = vehicleIdReaderService;
            Activator = new ViewModelActivator();
            ReaderData = new VehicleIdData();

            var canRad = this.WhenAnyValue(x => x.CanRead);
            BeginReadCommand = ReactiveCommand.CreateFromObservable(() =>
                Observable.StartAsync(BeginReadAsync).TakeUntil(endReadCommand), canRad);

            ClearReaderDataCommand = ReactiveCommand.Create(ClearReaderData);

            var canReportChanged = this.WhenAnyValue(x => x.CanReport);
            ReaderDataReportCommand = ReactiveCommand.CreateFromObservable(() =>
                Observable.StartAsync(ReaderDataReportAsync).TakeUntil(endReportCommand), canReportChanged);

            this.WhenAnyValue(x => x.CardReaderId)
                .Subscribe(value => applicationState.VehicleIdReaderCardReaderId = value);

            this.WhenAnyValue(x => x.CardReaderName)
                .Subscribe(value => CanRead = !string.IsNullOrWhiteSpace(value));

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

        private async Task BeginReadAsync(CancellationToken ct)
        {
            CanRead = false;
            ShowMessage = false;

            try
            {
                var data = await vehicleIdReaderService.ReadAsync(CardReaderName, applicationState.VehicleIdReaderApiVersion, ct);
                UpdateReaderData(data);
            }
            catch (OperationCanceledException)
            {
                this.Log().Info("Operation has been canceled.");
            }
            catch (VehicleIdReaderServiceException e)
            {
                this.Log().Error(e, "Failed to read data from ID card.");
                MessageTitle = applicationResources.GetString("MessageErrorTitle");
                MessageSeverity = InfoBarSeverity.Error;
                Message = applicationResources.GetString("VehicleIdReaderErrorMessage", e.Message);
                ShowMessage = true;
            }
            finally
            {
                CanRead = true;
            }
        }

        private void UpdateReaderData(Core.Model.VehicleIdReader.VehicleIdData data)
        {
            
        }

        private void ClearReaderData()
        {
            ShowMessage = false;
            MessageSeverity = InfoBarSeverity.Informational;
            Message = null;
            MessageTitle = null;
            UpdateReaderData(null);
        }

        private async Task ReaderDataReportAsync(CancellationToken ct)
        {

        }
    }
}
