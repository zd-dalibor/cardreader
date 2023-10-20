using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using CardReader.Core.Service.Resources;
using ReactiveUI;
using Splat;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CardReader.UI.VehicleIdReader
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VehicleIdReaderPage
    {
        private readonly IApplicationResources resources;

        public VehicleIdReaderPage()
        {
            this.InitializeComponent();
            ViewModel = Locator.Current.GetService<VehicleIdReaderViewModel>();
            resources = Locator.Current.GetService<IApplicationResources>();

            LoadStrings();
            this.WhenActivated(disposables =>
            {
                resources.Observe()
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Subscribe(_ => LoadStrings())
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
            StateIssuingCtl.Header = resources.GetString("StateIssuingCtl/Header");
            CompetentAuthorityCtl.Header = resources.GetString("CompetentAuthorityCtl/Header");
            AuthorityIssuingCtl.Header = resources.GetString("AuthorityIssuingCtl/Header");
            UnambiguousNumberCtl.Header = resources.GetString("UnambiguousNumberCtl/Header");
            IssuingDateCtl.Header = resources.GetString("IssuingDateCtl/Header");
            ExpiryDateCtl.Header = resources.GetString("ExpiryDateCtl/Header");
            SerialNumberCtl.Header = resources.GetString("SerialNumberCtl/Header");
            DateOfFirstRegistrationCtl.Header = resources.GetString("DateOfFirstRegistrationCtl/Header");
            YearOfProductionCtl.Header = resources.GetString("YearOfProductionCtl/Header");
            VehicleMakeCtl.Header = resources.GetString("VehicleMakeCtl/Header");
            VehicleTypeCtl.Header = resources.GetString("VehicleTypeCtl/Header");
            CommercialDescriptionCtl.Header = resources.GetString("CommercialDescriptionCtl/Header");
            VehicleIdNumberCtl.Header = resources.GetString("VehicleIdNumberCtl/Header");
            RegistrationNumberOfVehicleCtl.Header = resources.GetString("RegistrationNumberOfVehicleCtl/Header");
            MaximumNetPowerCtl.Header = resources.GetString("MaximumNetPowerCtl/Header");
            EngineCapacityCtl.Header = resources.GetString("EngineCapacityCtl/Header");
            TypeOfFuelCtl.Header = resources.GetString("TypeOfFuelCtl/Header");
            PowerWeightRatioCtl.Header = resources.GetString("PowerWeightRatioCtl/Header");
            VehicleMassCtl.Header = resources.GetString("VehicleMassCtl/Header");
            MaximumPermissibleLadenMassCtl.Header = resources.GetString("MaximumPermissibleLadenMassCtl/Header");
            TypeApprovalNumberCtl.Header = resources.GetString("TypeApprovalNumberCtl/Header");
            NumberOfSeatsCtl.Header = resources.GetString("NumberOfSeatsCtl/Header");
            NumberOfStandingPlacesCtl.Header = resources.GetString("NumberOfStandingPlacesCtl/Header");
            EngineIdNumberCtl.Header = resources.GetString("EngineIdNumberCtl/Header");
            NumberOfAxlesCtl.Header = resources.GetString("NumberOfAxlesCtl/Header");
            VehicleCategoryCtl.Header = resources.GetString("VehicleCategoryCtl/Header");
            ColourOfVehicleCtl.Header = resources.GetString("ColourOfVehicleCtl/Header");
            RestrictionToChangeOwnerCtl.Header = resources.GetString("RestrictionToChangeOwnerCtl/Header");
            VehicleLoadCtl.Header = resources.GetString("VehicleLoadCtl/Header");
            OwnersPersonalNoCtl.Header = resources.GetString("OwnersPersonalNoCtl/Header");
            OwnersSurnameOrBusinessNameCtl.Header = resources.GetString("OwnersSurnameOrBusinessNameCtl/Header");
            OwnerNameCtl.Header = resources.GetString("OwnerNameCtl/Header");
            OwnerAddressCtl.Header = resources.GetString("OwnerAddressCtl/Header");
            UsersPersonalNoCtl.Header = resources.GetString("UsersPersonalNoCtl/Header");
            UsersSurnameOrBusinessNameCtl.Header = resources.GetString("UsersSurnameOrBusinessNameCtl/Header");
            UsersNameCtl.Header = resources.GetString("UsersNameCtl/Header");
            UsersAddressCtl.Header = resources.GetString("UsersAddressCtl/Header");
        }
    }
}
