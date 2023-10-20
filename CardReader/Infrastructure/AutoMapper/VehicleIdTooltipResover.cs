using AutoMapper;
using CardReader.Core.Model.VehicleIdReader;
using CardReader.Core.Service.Resources;

namespace CardReader.Infrastructure.AutoMapper
{
    internal class VehicleIdTooltipResolver : IValueResolver<VehicleIdRegistrationData, object, string>
    {
        private readonly IApplicationResources applicationResources;

        public VehicleIdTooltipResolver(IApplicationResources applicationResources)
        {
            this.applicationResources = applicationResources;
        }

        public string Resolve(VehicleIdRegistrationData source, object destination, string destMember, ResolutionContext context)
        {
            if (source == null) return null;

            if (source.IsValid == null)
            {
                return applicationResources.GetString("VehicleIdRegistrationDataEmpty", source.Index);
            }
            
            if (source.IsValid.Value)
            {
                return applicationResources.GetString("VehicleIdRegistrationDataValid", source.Index);
            }

            return applicationResources.GetString("VehicleIdRegistrationDataInvalid", source.Index,
                source.VerificationErrorMsg, source.VerificationErrorDetails);
        }
    }
}
