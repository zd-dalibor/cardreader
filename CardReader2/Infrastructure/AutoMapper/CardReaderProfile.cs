using AutoMapper;

namespace CardReader.Infrastructure.AutoMapper
{
    internal class CardReaderProfile : Profile
    {
        public CardReaderProfile()
        {
            CreateMap<Core.Model.IdReader.IdReaderData, UI.IdReader.IdReaderData>()
                .ForMember(dest => dest.CardType, opt => opt.MapFrom<IdReaderCardTypeResolver>())
                .ForMember(dest => dest.Portrait, opt => opt.MapFrom<IdReaderPortraitImageResolver>());

            //CreateMap<VehicleIdData, VehicleIdDataViewModel>();
            //CreateMap<VehicleIdRegistrationData, VehicleIdRegistrationDataViewModel>();
        }
    }
}
