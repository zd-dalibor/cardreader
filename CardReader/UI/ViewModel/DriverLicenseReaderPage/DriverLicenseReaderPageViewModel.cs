using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardReader.Model;
using CardReader.Service;
using CardReader.UI.ViewModel.IdReaderPage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml.Controls;
using static ABI.System.Windows.Input.ICommand_Delegates;

namespace CardReader.UI.ViewModel.DriverLicenseReaderPage
{
    public partial class DriverLicenseReaderPageViewModel : ObservableObject
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

        private readonly IStringLoader stringLoader;
        private readonly AppState appState;
        private readonly IDriverLicenseReaderService driverLicenseReaderService;
        private readonly ILogger<DriverLicenseReaderPageViewModel> logger;

        public DriverLicenseReaderPageViewModel(IStringLoader stringLoader, AppState appState, IDriverLicenseReaderService driverLicenseReaderService, ILogger<DriverLicenseReaderPageViewModel> logger)
        {
            this.stringLoader = stringLoader;
            this.appState = appState;
            this.driverLicenseReaderService = driverLicenseReaderService;
            this.logger = logger;

            cardReaderId = appState.DriverLicenseReaderCardReaderId;

            InitStrings();
        }

        private void InitStrings()
        {
            SelectReaderLbl = stringLoader.GetString("CardReaderCtl/Header");
            RefreshReaderHlp = stringLoader.GetString("CardReaderCtl/Content");
            BeginReadLbl = stringLoader.GetString("BeginReadBtn/Content");
            ClearReaderDataLbl = stringLoader.GetString("ClearReaderDataBtn/Content");
        }

        partial void OnCardReaderIdChanged(string value)
        {
            appState.DriverLicenseReaderCardReaderId = value;
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
                appState.LastDriverLicenseData =
                    await driverLicenseReaderService.ReadAsync(cardReaderName, appState.DriverLicenseReaderApiVersion);
            }
            catch (DriverLicenseReaderServiceException e)
            {
                logger.LogError(e, "Failed to read data from ID card.");
                MessageTitle = stringLoader.GetString("Message/ErrorTitle");
                MessageSeverity = InfoBarSeverity.Error;
                Message = string.Format(stringLoader.GetString("DriverLicenseReader/ErrorMessage"), e.Message);
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
            appState.LastDriverLicenseData = null;
        }
    }
}
