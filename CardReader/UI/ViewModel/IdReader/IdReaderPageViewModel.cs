using System.Threading.Tasks;
using AutoMapper;
using CardReader.Model;
using CardReader.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml.Controls;

namespace CardReader.UI.ViewModel.IdReader
{
    public partial class IdReaderPageViewModel : ObservableObject
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
        private string cardTypeLbl;

        [ObservableProperty]
        private string docRegNoLbl;

        [ObservableProperty] 
        private string documentTypeLbl;

        [ObservableProperty]
        private string issuingDateLbl;

        [ObservableProperty]
        private string expiryDateLbl;

        [ObservableProperty]
        private string issuingAuthorityLbl;

        [ObservableProperty]
        private string documentSerialNumberLbl;

        [ObservableProperty]
        private string chipSerialNumberLbl;

        [ObservableProperty]
        private string personalNumberLbl;

        [ObservableProperty]
        private string surnameLbl;

        [ObservableProperty]
        private string givenNameLbl;

        [ObservableProperty]
        private string parentGivenNameLbl;
        #endregion

        [ObservableProperty]
        private string cardReaderId;

        [ObservableProperty]
        private string cardReaderName;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(BeginReadCommand))]
        private bool canRead;

        [ObservableProperty]
        private bool showMessage;

        [ObservableProperty]
        private InfoBarSeverity messageSeverity;

        [ObservableProperty]
        private string messageTitle;

        [ObservableProperty]
        private string message;

        [ObservableProperty]
        private IdReaderDataViewModel readerData;

        private readonly IStringLoader stringLoader;
        private readonly AppState appState;
        private readonly IIdReaderService idReaderService;
        private readonly ILogger<IdReaderPageViewModel> logger;
        private readonly IMapper mapper;

        public IdReaderPageViewModel(IStringLoader stringLoader, AppState appState, IIdReaderService idReaderService, ILogger<IdReaderPageViewModel> logger, IMapper mapper)
        {
            this.stringLoader = stringLoader;
            this.appState = appState;
            this.idReaderService = idReaderService;
            this.logger = logger;
            this.mapper = mapper;

            cardReaderId = appState.IdReaderCardReaderId;
            readerData = new IdReaderDataViewModel();

            InitStrings();
        }

        private void InitStrings()
        {
            SelectReaderLbl = stringLoader.GetString("CardReaderCtl/Header");
            RefreshReaderHlp = stringLoader.GetString("CardReaderCtl/Content");
            BeginReadLbl = stringLoader.GetString("BeginReadBtn/Content");
            ClearReaderDataLbl = stringLoader.GetString("ClearReaderDataBtn/Content");
            CardTypeLbl = stringLoader.GetString("CardTypeCtl/Header");
            DocRegNoLbl = stringLoader.GetString("DocRegNoCtl/Header");
            DocumentTypeLbl = stringLoader.GetString("DocumentTypeCtl/Header");
            IssuingDateLbl = stringLoader.GetString("IssuingDateCtl/Header");
            ExpiryDateLbl = stringLoader.GetString("ExpiryDateCtl/Header");
            IssuingAuthorityLbl = stringLoader.GetString("IssuingAuthorityCtl/Header");
            DocumentSerialNumberLbl = stringLoader.GetString("DocumentSerialNumberCtl/Header");
            ChipSerialNumberLbl = stringLoader.GetString("ChipSerialNumberCtl/Header");
            PersonalNumberLbl = stringLoader.GetString("PersonalNumberCtl/Header");
            SurnameLbl = stringLoader.GetString("SurnameCtl/Header");
            GivenNameLbl = stringLoader.GetString("GivenNameCtl/Header");
            ParentGivenNameLbl = stringLoader.GetString("ParentGivenNameCtl/Header");
        }

        partial void OnCardReaderIdChanged(string value)
        {
            appState.IdReaderCardReaderId = value;
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
                var data = await idReaderService.ReadAsync(CardReaderName, appState.IdReaderApiVersion);
                ReaderData = mapper.Map<IdReaderDataViewModel>(data);
            }
            catch (IdReaderServiceException e)
            {
                logger.LogError(e, "Failed to read data from ID card.");
                MessageTitle = stringLoader.GetString("Message/ErrorTitle");
                MessageSeverity = InfoBarSeverity.Error;
                Message = string.Format(stringLoader.GetString("IdReader/ErrorMessage"), e.Message);
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
            ReaderData = new IdReaderDataViewModel();
        }
    }
}
