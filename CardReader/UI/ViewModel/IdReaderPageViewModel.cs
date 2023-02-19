using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardReader.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CardReader.UI.ViewModel
{
    public partial class IdReaderPageViewModel : ObservableObject
    {
        #region strings
        [ObservableProperty]
        private string selectReaderLbl;

        [ObservableProperty]
        private string refreshReaderHlp;
        #endregion

        [ObservableProperty]
        private string cardReaderId;

        [ObservableProperty]
        private string cardReaderName;

        private readonly IStringLoader stringLoader;
        private readonly AppState appState;

        public IdReaderPageViewModel(IStringLoader stringLoader, AppState appState)
        {
            this.stringLoader = stringLoader;
            this.appState = appState;
            
            cardReaderId = appState.IdReaderCardReaderId;

            InitStrings();
        }

        private void InitStrings()
        {
            SelectReaderLbl = stringLoader.GetString("SelectReaderCbx/Header");
            RefreshReaderHlp = stringLoader.GetString("RefreshReaderTlp/Content");
        }

        partial void OnCardReaderIdChanged(string value)
        {
            appState.IdReaderCardReaderId = value;
        }
    }
}
