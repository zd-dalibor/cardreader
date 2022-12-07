using CardReader.Model.Data.Eid;
using CardReader.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardReader.Model.Converters
{
    internal class PortraitDataConverer
    {
        public static PortraitData From(IdReaderLib.EID_PORTRAIT data)
        {
            var portrait = BytesUtil.Copy(data.portrait, data.portraitSize);
            var portraitData = new PortraitData
            {
                Portrait = portrait,
                PortraitBase64 = BytesUtil.Base64(portrait)
            };

            return portraitData;
        }
    }
}
