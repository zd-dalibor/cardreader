using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using CardReader.Core.Service.Resources;
using ReactiveUI;
using Splat;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CardReader.UI.IdReader
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class IdReaderPage : IdReaderPageBase
    {
        private readonly IApplicationResources resources;

        public IdReaderPage()
        {
            this.InitializeComponent();
            ViewModel = Locator.Current.GetService<IdReaderViewModel>();
            resources = Locator.Current.GetService<IApplicationResources>();

            LoadStrings();
            this.WhenActivated(disposables =>
            {
                resources.Observe()
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Subscribe(_ => LoadStrings())
                    .DisposeWith(disposables);

                ViewModel.WhenAnyValue(x => x.ReaderData)
                    .Subscribe(_ => UpdateDataVerifiedToolTips())
                    .DisposeWith(disposables);
            });
        }

        private void LoadStrings()
        {
            CardReaderCtl.Header = resources.GetString("CardReaderCtl/Header");
            CardReaderCtl.RefreshTooltip = resources.GetString("CardReaderCtl/RefreshTooltip");
            BeginReadBtn.Content = resources.GetString("BeginReadBtn/Content");
            ClearReaderDataBtn.Content = resources.GetString("ClearReaderDataBtn/Content");
            ReaderDataReportBtnToolTip.Content = resources.GetString("ReaderDataReportBtnToolTip/Content");
            CardTypeCtl.Header = resources.GetString("CardTypeCtl/Header");
            DocRegNoCtl.Header = resources.GetString("DocRegNoCtl/Header");
            DocumentTypeCtl.Header = resources.GetString("DocumentTypeCtl/Header");
            IssuingDateCtl.Header = resources.GetString("IssuingDateCtl/Header");
            ExpiryDateCtl.Header = resources.GetString("ExpiryDateCtl/Header");
            IssuingAuthorityCtl.Header = resources.GetString("IssuingAuthorityCtl/Header");
            DocumentSerialNumberCtl.Header = resources.GetString("DocumentSerialNumberCtl/Header");
            ChipSerialNumberCtl.Header = resources.GetString("ChipSerialNumberCtl/Header");
            PersonalNumberCtl.Header = resources.GetString("PersonalNumberCtl/Header");
            SurnameCtl.Header = resources.GetString("SurnameCtl/Header");
            GivenNameCtl.Header = resources.GetString("GivenNameCtl/Header");
            ParentGivenNameCtl.Header = resources.GetString("ParentGivenNameCtl/Header");
            SexCtl.Header = resources.GetString("SexCtl/Header");
            PlaceOfBirthCtl.Header = resources.GetString("PlaceOfBirthCtl/Header");
            StateOfBirthCtl.Header = resources.GetString("StateOfBirthCtl/Header");
            DateOfBirthCtl.Header = resources.GetString("DateOfBirthCtl/Header");
            CommunityOfBirthCtl.Header = resources.GetString("CommunityOfBirthCtl/Header");
            StatusOfForeignerCtl.Header = resources.GetString("StatusOfForeignerCtl/Header");
            NationalityFullCtl.Header = resources.GetString("NationalityFullCtl/Header");
            StateCtl.Header = resources.GetString("StateCtl/Header");
            CommunityCtl.Header = resources.GetString("CommunityCtl/Header");
            PlaceCtl.Header = resources.GetString("PlaceCtl/Header");
            StreetCtl.Header = resources.GetString("StreetCtl/Header");
            HouseNumberCtl.Header = resources.GetString("HouseNumberCtl/Header");
            HouseLetterCtl.Header = resources.GetString("HouseLetterCtl/Header");
            EntranceCtl.Header = resources.GetString("EntranceCtl/Header");
            FloorCtl.Header = resources.GetString("FloorCtl/Header");
            ApartmentNumberCtl.Header = resources.GetString("ApartmentNumberCtl/Header");
            AddressDateCtl.Header = resources.GetString("AddressDateCtl/Header");
            AddressLabelCtl.Header = resources.GetString("AddressLabelCtl/Header");
            UpdateDataVerifiedToolTips();
        }

        private void UpdateDataVerifiedToolTips()
        {
            SigCardVerifiedTlp.Content = string.Format(
                resources.GetString("SigCardVerifiedTlp/Content"),
                SigVerifyStatusMsg(ViewModel.ReaderData.SigCardVerified));
            SigFixedVerifiedTlp.Content = string.Format(
                resources.GetString("SigFixedVerifiedTlp/Content"),
                SigVerifyStatusMsg(ViewModel.ReaderData.SigFixedVerified));
            SigVariableVerifiedTlp.Content = string.Format(
                resources.GetString("SigVariableVerifiedTlp/Content"),
                SigVerifyStatusMsg(ViewModel.ReaderData.SigVariableVerified));
            SigPortraitVerifiedTlp.Content = string.Format(
                resources.GetString("SigPortraitVerifiedTlp/Content"),
                SigVerifyStatusMsg(ViewModel.ReaderData.SigPortraitVerified));
        }

        private string SigVerifyStatusMsg(bool? status)
        {
            return status switch
            {
                true => resources.GetString("SignatureVerificationSuccess"),
                false => resources.GetString("SignatureVerificationFailed"),
                _ => resources.GetString("SignatureVerificationNone")
            };
        }
    }
}
