using AutoMapper;
using CardReader.Model;
using CardReader.UI.ViewModel.DriverLicenseReaderPage;
using CardReader.UI.ViewModel.IdReaderPage;

namespace CardReader.AutoMapper
{
    public class CardReaderProfile : Profile
    {
        public CardReaderProfile()
        {
            CreateMap<IdReaderData, IdReaderDataViewModel>()
                .ForMember(dest => dest.CardType, opt => opt.MapFrom<IdReaderCardTypeResolver>())
                .ForMember(dest => dest.Portrait, opt => opt.MapFrom<IdReaderPortraitImageResolver>());

            CreateMap<DriverLicenseData, DriverLicenseDataViewModel>();
            CreateMap<DriverLicenseRegistrationData, DriverLicenseRegistrationDataViewModel>();
        }
    }
}
