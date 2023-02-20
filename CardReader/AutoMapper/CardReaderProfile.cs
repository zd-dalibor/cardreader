using AutoMapper;
using CardReader.Model;
using CardReader.UI.ViewModel.IdReader;

namespace CardReader.AutoMapper
{
    public class CardReaderProfile : Profile
    {
        public CardReaderProfile()
        {
            CreateMap<IdReaderData, IdReaderDataViewModel>()
                .ForMember(dest => dest.CardType, opt => opt.MapFrom<IdReaderCardTypeResolver>())
                .ForMember(dest => dest.Portrait, opt => opt.MapFrom<IdReaderPortraitImageResolver>());
        }
    }
}
