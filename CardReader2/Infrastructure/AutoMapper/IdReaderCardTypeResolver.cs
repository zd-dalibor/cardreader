using AutoMapper;
using CardReader.Core.Model.IdReader;
using CardReader.Core.Service.IdReader;
using CardReader.Core.Service.Resources;

namespace CardReader.Infrastructure.AutoMapper
{
    internal class IdReaderCardTypeResolver : IValueResolver<IdReaderData, object, string>
    {
        private readonly IApplicationResources applicationResources;

        public IdReaderCardTypeResolver(IApplicationResources applicationResources)
        {
            this.applicationResources = applicationResources;
        }

        public string Resolve(IdReaderData source, object destination, string destMember, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            return source.CardType switch
            {
                IIdReaderService.EID_CARD_ID2008 => applicationResources.GetString("IdReaderCardTypeOld"),
                IIdReaderService.EID_CARD_ID2014 => applicationResources.GetString("IdReaderCardTypeNew"),
                IIdReaderService.EID_CARD_IF2020 => applicationResources.GetString("IdReaderCardTypeForeigner"),
                _ => applicationResources.GetString("IdReaderCardTypeUnknown"),
            };
        }
    }
}
