using System;
using System.Threading.Tasks;
using AutoMapper;
using CardReader.Model;
using CardReader.Service;
using CardReader.UI.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml.Controls;

namespace CardReader.UI.ViewModel.VehicleIdReaderPage
{
    public partial class VehicleIdReaderPageViewModel : ObservableRecipient
    {
        #region strings
        [ObservableProperty]
        private string selectReaderLbl;

        [ObservableProperty]
        private string refreshReaderHlp;

        [ObservableProperty]
        private string beginReadLbl;

        [ObservableProperty]
        private string clearReaderDataLbl;

        [ObservableProperty]
        private string stateIssuingLbl;

        [ObservableProperty]
        private string competentAuthorityLbl;

        [ObservableProperty]
        private string authorityIssuingLbl;

        [ObservableProperty]
        private string unambiguousNumberLbl;

        [ObservableProperty]
        private string issuingDateLbl;

        [ObservableProperty]
        private string expiryDateLbl;

        [ObservableProperty]
        private string serialNumberLbl;

        [ObservableProperty]
        private string dateOfFirstRegistrationLbl;

        [ObservableProperty]
        private string yearOfProductionLbl;

        [ObservableProperty]
        private string vehicleMakeLbl;

        [ObservableProperty]
        private string vehicleTypeLbl;

        [ObservableProperty]
        private string commercialDescriptionLbl;

        [ObservableProperty]
        private string vehicleIdNumberLbl;

        [ObservableProperty]
        private string registrationNumberOfVehicleLbl;

        [ObservableProperty]
        private string maximumNetPowerLbl;

        [ObservableProperty]
        private string engineCapacityLbl;

        [ObservableProperty]
        private string typeOfFuelLbl;

        [ObservableProperty]
        private string powerWeightRatioLbl;

        [ObservableProperty]
        private string vehicleMassLbl;

        [ObservableProperty]
        private string maximumPermissibleLadenMassLbl;

        [ObservableProperty]
        private string typeApprovalNumberLbl;

        [ObservableProperty]
        private string numberOfSeatsLbl;

        [ObservableProperty]
        private string numberOfStandingPlacesLbl;

        [ObservableProperty]
        private string engineIdNumberLbl;

        [ObservableProperty]
        private string numberOfAxlesLbl;

        [ObservableProperty]
        private string vehicleCategoryLbl;

        [ObservableProperty]
        private string colourOfVehicleLbl;

        [ObservableProperty]
        private string restrictionToChangeOwnerLbl;

        [ObservableProperty]
        private string vehicleLoadLbl;

        [ObservableProperty]
        private string ownersPersonalNoLbl;

        [ObservableProperty]
        private string ownersSurnameOrBusinessNameLbl;

        [ObservableProperty]
        private string ownerNameLbl;

        [ObservableProperty]
        private string ownerAddressLbl;

        [ObservableProperty]
        private string usersPersonalNoLbl;

        [ObservableProperty]
        private string usersSurnameOrBusinessNameLbl;

        [ObservableProperty]
        private string usersNameLbl;

        [ObservableProperty]
        private string usersAddressLbl;

        [ObservableProperty]
        private string readerDataReportHlp;
        #endregion

        [ObservableProperty]
        private string cardReaderId;

        [ObservableProperty]
        private string cardReaderName;

        [ObservableProperty]
        private bool showMessage;

        [ObservableProperty]
        private InfoBarSeverity messageSeverity;

        [ObservableProperty]
        private string messageTitle;

        [ObservableProperty]
        private string message;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(BeginReadCommand))]
        private bool canRead;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ReaderDataReportCommand))]
        private bool canReport;

        [ObservableProperty]
        private VehicleIdDataViewModel readerData;

        private readonly IStringLoader stringLoader;
        private readonly AppState appState;
        private readonly IVehicleIdReaderService vehicleIdReaderService;
        private readonly ILogger<VehicleIdReaderPageViewModel> logger;
        private readonly IMapper mapper;
        private readonly IReportingService reportingService;

        public VehicleIdReaderPageViewModel(
            IStringLoader stringLoader,
            AppState appState,
            IVehicleIdReaderService vehicleIdReaderService,
            ILogger<VehicleIdReaderPageViewModel> logger,
            IMapper mapper,
            IReportingService reportingService,
            IMessenger messenger) : base(messenger)
        {
            this.stringLoader = stringLoader;
            this.appState = appState;
            this.vehicleIdReaderService = vehicleIdReaderService;
            this.logger = logger;
            this.mapper = mapper;
            this.reportingService = reportingService;

            cardReaderId = appState.VehicleIdReaderCardReaderId;
            UpdateReaderData(appState.LastVehicleIdData);

            InitStrings();
        }

        private void UpdateReaderData(VehicleIdData data)
        {
            appState.LastVehicleIdData = data;
            ReaderData = data != null
                ? mapper.Map<VehicleIdDataViewModel>(data)
                : new VehicleIdDataViewModel();
            // CanReport = data != null;
            CanReport = true;
        }

        private void InitStrings()
        {
            SelectReaderLbl = stringLoader.GetString("CardReaderCtl/Header");
            RefreshReaderHlp = stringLoader.GetString("CardReaderCtl/RefreshTooltip");
            BeginReadLbl = stringLoader.GetString("BeginReadBtn/Content");
            ClearReaderDataLbl = stringLoader.GetString("ClearReaderDataBtn/Content");

            StateIssuingLbl = stringLoader.GetString("StateIssuingCtl/Header");
            CompetentAuthorityLbl = stringLoader.GetString("CompetentAuthorityCtl/Header");
            AuthorityIssuingLbl = stringLoader.GetString("AuthorityIssuingCtl/Header");
            UnambiguousNumberLbl = stringLoader.GetString("UnambiguousNumberCtl/Header");
            IssuingDateLbl = stringLoader.GetString("IssuingDateCtl/Header");
            ExpiryDateLbl = stringLoader.GetString("ExpiryDateCtl/Header");
            SerialNumberLbl = stringLoader.GetString("SerialNumberCtl/Header");

            DateOfFirstRegistrationLbl = stringLoader.GetString("DateOfFirstRegistrationCtl/Header");
            YearOfProductionLbl = stringLoader.GetString("YearOfProductionCtl/Header");
            VehicleMakeLbl = stringLoader.GetString("VehicleMakeCtl/Header");
            VehicleTypeLbl = stringLoader.GetString("VehicleTypeCtl/Header");
            CommercialDescriptionLbl = stringLoader.GetString("CommercialDescriptionCtl/Header");
            VehicleIdNumberLbl = stringLoader.GetString("VehicleIdNumberCtl/Header");
            RegistrationNumberOfVehicleLbl = stringLoader.GetString("RegistrationNumberOfVehicleCtl/Header");
            MaximumNetPowerLbl = stringLoader.GetString("MaximumNetPowerCtl/Header");
            EngineCapacityLbl = stringLoader.GetString("EngineCapacityCtl/Header");
            TypeOfFuelLbl = stringLoader.GetString("TypeOfFuelCtl/Header");
            PowerWeightRatioLbl = stringLoader.GetString("PowerWeightRatioCtl/Header");
            VehicleMassLbl = stringLoader.GetString("VehicleMassCtl/Header");
            MaximumPermissibleLadenMassLbl = stringLoader.GetString("MaximumPermissibleLadenMassCtl/Header");
            TypeApprovalNumberLbl = stringLoader.GetString("TypeApprovalNumberCtl/Header");
            NumberOfSeatsLbl = stringLoader.GetString("NumberOfSeatsCtl/Header");
            NumberOfStandingPlacesLbl = stringLoader.GetString("NumberOfStandingPlacesCtl/Header");
            EngineIdNumberLbl = stringLoader.GetString("EngineIdNumberCtl/Header");
            NumberOfAxlesLbl = stringLoader.GetString("NumberOfAxlesCtl/Header");
            VehicleCategoryLbl = stringLoader.GetString("VehicleCategoryCtl/Header");
            ColourOfVehicleLbl = stringLoader.GetString("ColourOfVehicleCtl/Header");
            RestrictionToChangeOwnerLbl = stringLoader.GetString("RestrictionToChangeOwnerCtl/Header");
            VehicleLoadLbl = stringLoader.GetString("VehicleLoadCtl/Header");

            OwnersPersonalNoLbl = stringLoader.GetString("OwnersPersonalNoCtl/Header");
            OwnersSurnameOrBusinessNameLbl = stringLoader.GetString("OwnersSurnameOrBusinessNameCtl/Header");
            OwnerNameLbl = stringLoader.GetString("OwnerNameCtl/Header");
            OwnerAddressLbl = stringLoader.GetString("OwnerAddressCtl/Header");
            UsersPersonalNoLbl = stringLoader.GetString("UsersPersonalNoCtl/Header");
            UsersSurnameOrBusinessNameLbl = stringLoader.GetString("UsersSurnameOrBusinessNameCtl/Header");
            UsersNameLbl = stringLoader.GetString("UsersNameCtl/Header");
            UsersAddressLbl = stringLoader.GetString("UsersAddressCtl/Header");

            ReaderDataReportHlp = stringLoader.GetString("ReaderDataReportBtnToolTip/Content");
        }

        partial void OnCardReaderIdChanged(string value)
        {
            appState.VehicleIdReaderCardReaderId = value;
        }

        partial void OnCardReaderNameChanged(string value)
        {
            CanRead = !string.IsNullOrWhiteSpace(value);
        }

        [RelayCommand(CanExecute = nameof(CanRead))]
        private async Task BeginReadAsync()
        {
            CanRead = false;
            ShowMessage = false;

            try
            {
                var data = await vehicleIdReaderService.ReadAsync(CardReaderName, appState.VehicleIdReaderApiVersion);
                UpdateReaderData(data);
            }
            catch (VehicleIdReaderServiceException e)
            {
                logger.LogError(e, "Failed to read data from ID card.");
                MessageTitle = stringLoader.GetString("Message/ErrorTitle");
                MessageSeverity = InfoBarSeverity.Error;
                Message = string.Format(stringLoader.GetString("VehicleIdReader/ErrorMessage"), e.Message);
                ShowMessage = true;
            }
            finally
            {
                CanRead = true;
            }
        }

        [RelayCommand]
        private void ClearReaderData()
        {
            ShowMessage = false;
            MessageSeverity = default(InfoBarSeverity);
            Message = null;
            MessageTitle = null;
            UpdateReaderData(null);
        }

        [RelayCommand(CanExecute = nameof(CanReport))]
        private async Task ReaderDataReport()
        {
            CanReport = false;
            var readerDate = appState.LastVehicleIdData ?? new VehicleIdData()
            {
                StateIssuing = "Srbija",
                CompetentAuthority = "Mup Leskovac",
                AuthorityIssuing = "Mup Leskovac"
            };
            var currentLocale = stringLoader.GetCurrentLocale();
            try
            {
                await reportingService.VehicleIdReportAsync(readerDate, currentLocale);
            }
            catch (Exception e)
            {
                logger.LogError(e, "Reader data report error.");
                Messenger.Send(new ErrorMessage(e));
            }
            finally
            {
                CanReport = true;
            }
        }
    }
}
