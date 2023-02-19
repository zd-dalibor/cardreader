﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardReader.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;

namespace CardReader.UI.ViewModel
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

        private readonly IStringLoader stringLoader;
        private readonly AppState appState;
        private readonly IIdReaderService idReaderService;

        public IdReaderPageViewModel(IStringLoader stringLoader, AppState appState, IIdReaderService idReaderService)
        {
            this.stringLoader = stringLoader;
            this.appState = appState;
            this.idReaderService = idReaderService;

            cardReaderId = appState.IdReaderCardReaderId;

            InitStrings();
        }

        private void InitStrings()
        {
            SelectReaderLbl = stringLoader.GetString("CardReaderCtl/Header");
            RefreshReaderHlp = stringLoader.GetString("CardReaderCtl/Content");
            BeginReadLbl = stringLoader.GetString("BeginReadBtn/Content");
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
        private void BeginRead()
        {
            CanRead = false;
            try
            {
                idReaderService.Read(CardReaderName);
            }
            catch (IdReaderServiceException e)
            {
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
    }
}
