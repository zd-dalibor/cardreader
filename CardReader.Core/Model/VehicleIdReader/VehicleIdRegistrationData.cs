namespace CardReader.Core.Model.VehicleIdReader
{
    public class VehicleIdRegistrationData
    {
        public byte[]? RegistrationData { get; set; }
        public byte[]? SignatureData { get; set; }
        public byte[]? IssuingAuthority { get; set; }
        public bool? IsValid { get; set; }
        public string? VerificationErrorMsg { get; set; }
        public string? VerificationErrorDetails { get; set; }
    }
}
