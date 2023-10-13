using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace CardReader.UI.VehicleIdReader
{
    public class VehicleIdRegistrationData : ReactiveObject
    {
        [Reactive]
        public bool? IsValid { get; set; }

        [Reactive]
        public string VerificationErrorMsg { get; set; }

        [Reactive]
        public string VerificationErrorDetails { get; set; }
    }
}
