using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardReader.Model;
using IdReaderLib;

namespace CardReader.Service
{
    public class IdReaderService : IIdReaderService
    {
        public IdReaderData Read(string cardReaderName)
        {
            var reader = new MainReader();
            var result = SetOption(reader, IIdReaderService.EID_O_KEEP_CARD_CLOSED, 0);
            if (result != IIdReaderService.EID_OK)
            {
                throw new IdReaderServiceException(result);
            }

            return null;
        }

        private static int SetOption(IMainReader reader, int optionId, ulong optionValue)
        {
            return reader.EidSetOption(optionId, optionValue);
        }
    }
}
