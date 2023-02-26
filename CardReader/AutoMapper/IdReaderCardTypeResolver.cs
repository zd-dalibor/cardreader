using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CardReader.Model;
using CardReader.Service;

namespace CardReader.AutoMapper
{
    public class IdReaderCardTypeResolver : IValueResolver<IdReaderData, object, string>
    {
        private readonly IStringLoader stringLoader;

        public IdReaderCardTypeResolver(IStringLoader stringLoader)
        {
            this.stringLoader = stringLoader;
        }

        public string Resolve(IdReaderData source, object destination, string destMember, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            return source.CardType switch
            {
                IIdReaderService.EID_CARD_ID2008 => stringLoader.GetString("IdReaderCardType/Old"),
                IIdReaderService.EID_CARD_ID2014 => stringLoader.GetString("IdReaderCardType/New"),
                IIdReaderService.EID_CARD_IF2020 => stringLoader.GetString("IdReaderCardType/Foreigner"),
                _ => stringLoader.GetString("IdReaderCardType/Unknown"),
            };
        }
    }
}
