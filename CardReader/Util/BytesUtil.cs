using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardReader.Util
{
    public class BytesUtil
    {
        public static byte[] Copy(byte[] src, int length)
        {
            var dest = new byte[length];
            Array.Copy(src, dest, length);
            return dest;
        }

        public static string Base64(byte[] src)
        {
            return Convert.ToBase64String(src);
        }
    }
}
