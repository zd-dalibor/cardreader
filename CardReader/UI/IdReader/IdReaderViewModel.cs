#nullable enable
using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CardReader.Core.Service.Configuration;
using CardReader.Core.Service.Globalization;
using CardReader.Core.Service.IdReader;
using CardReader.Core.Service.Reporting;
using CardReader.Core.Service.Resources;
using CardReader.Core.State;
using CardReader.Infrastructure.Events;
using CardReader.Infrastructure.Exceptions;
using Microsoft.UI.Xaml.Controls;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;

namespace CardReader.UI.IdReader
{
    public class IdReaderViewModel : ReactiveObject, IActivatableViewModel
    {
        [Reactive]
        public bool ShowMessage { get; set; }

        [Reactive]
        public InfoBarSeverity MessageSeverity { get; set; }

        [Reactive]
        public string? MessageTitle { get; set; }

        [Reactive]
        public string? Message { get; set; }

        [Reactive]
        public string? CardReaderId { get; set; }

        [Reactive]
        public string? CardReaderName { get; set; }

        [Reactive]
        public IdReaderData ReaderData { get; set; }

        public ReactiveCommand<Unit, Unit> BeginReadCommand { get; }

        public ReactiveCommand<Unit, Unit> ClearReaderDataCommand { get; }

        public ReactiveCommand<Unit, Unit> ReaderDataReportCommand { get; }

        public ViewModelActivator Activator { get; }

        [Reactive]
        private bool CanRead { get; set; }

        [Reactive]
        private bool CanReport { get; set; }

        private readonly Subject<Unit> endReadCommand = new();
        private readonly Subject<Unit> endReportCommand = new();

        private readonly IApplicationState applicationState;
        private readonly IApplicationResources applicationResources;
        private readonly IIdReaderService idReaderService;
        private readonly IReportingService reportingService;
        private readonly ILocaleService localeService;
        private readonly IApplicationSettings settings;
        private readonly IMapper mapper;

        public IdReaderViewModel(
            IApplicationState applicationState,
            IApplicationResources applicationResources,
            IIdReaderService idReaderService,
            IReportingService reportingService,
            ILocaleService localeService,
            IApplicationSettings settings,
            IMapper mapper)
        {
            this.applicationState = applicationState;
            this.applicationResources = applicationResources;
            this.idReaderService = idReaderService;
            this.mapper = mapper;
            this.reportingService = reportingService;
            this.settings = settings;
            this.localeService = localeService;

            Activator = new ViewModelActivator();
            ReaderData = new IdReaderData();

            CardReaderId = applicationState.IdReaderCardReaderId;
            UpdateReaderData(applicationState.LastIdReaderData);

            this.WhenAnyValue(x => x.CardReaderName).Subscribe(CardReaderNameChanged);
            this.WhenAnyValue(x => x.CardReaderId).Subscribe(CardReaderIdChanged);

            var canReadChanged = this.WhenAnyValue(x => x.CanRead);
            BeginReadCommand = ReactiveCommand.CreateFromObservable(() =>
                Observable.StartAsync(BeginReadAsync).TakeUntil(endReadCommand), canReadChanged);

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

        private void CardReaderNameChanged(string? value)
        {
            CanRead = !string.IsNullOrWhiteSpace(value);
        }

        private void CardReaderIdChanged(string? value)
        {
            applicationState.IdReaderCardReaderId = value;
        }

        private void UpdateReaderData(Core.Model.IdReader.IdReaderData? data)
        {
            applicationState.LastIdReaderData = data;
            ReaderData = data != null
                ? mapper.Map<IdReaderData>(applicationState.LastIdReaderData)
                : new IdReaderData();
            CanReport = data != null;
        }

        private async Task BeginReadAsync(CancellationToken ct)
        {
            CanRead = false;
            ShowMessage = false;
            try
            {
                var data = await idReaderService.ReadAsync(CardReaderName, applicationState.IdReaderApiVersion, ct);
                UpdateReaderData(data);
            }
            catch (OperationCanceledException)
            {
                this.Log().Info("Operation has been canceled.");
            }
            catch (IdReaderServiceException e)
            {
                this.Log().Error(e, "Failed to read data from ID card.");
                MessageTitle = applicationResources.GetString("MessageErrorTitle");
                MessageSeverity = InfoBarSeverity.Error;
                Message = applicationResources.GetString("IdReaderErrorMessage", e.Message);
                ShowMessage = true;
            }
            finally
            {
                CanRead = true;
            }
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
            CanReport = false;
            var readerDate = applicationState.LastIdReaderData ?? new Core.Model.IdReader.IdReaderData();
            var currentLocale = settings.CurrentLocale(localeService.DefaultLocale);
            try
            {
                await reportingService.IdReaderReportAsync(readerDate, currentLocale, ct);
            }
            catch (OperationCanceledException)
            {
                this.Log().Info("Operation has been canceled.");
            }
            catch (Exception e)
            {
                this.Log().Error(e, "Reader data report error.");
                MessageBus.Current.SendMessage(new ErrorEventArgs(e));
            }
            finally
            {
                CanReport = true;
            }
        }
    }
}
