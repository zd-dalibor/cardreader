using AutoMapper;
using DynamicData;

namespace CardReader.Infrastructure.AutoMapper
{
    internal class CardReaderProfile : Profile
    {
        public CardReaderProfile()
        {
            CreateMap<Core.Model.IdReader.IdReaderData, UI.IdReader.IdReaderData>()
                .ForMember(dest => dest.CardType, opt => opt.MapFrom<IdReaderCardTypeResolver>())
                .ForMember(dest => dest.Portrait, opt => opt.MapFrom<IdReaderPortraitImageResolver>());

            CreateMap<Core.Model.VehicleIdReader.VehicleIdData, UI.VehicleIdReader.VehicleIdData>();
            CreateMap<Core.Model.VehicleIdReader.VehicleIdRegistrationData, UI.VehicleIdReader.VehicleIdRegistrationData>()
                .ForMember(dest => dest.Tooltip, opt => opt.MapFrom<VehicleIdTooltipResolver>());
        }
    }
}
