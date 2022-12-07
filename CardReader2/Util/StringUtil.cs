using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardReader.Util
{
    public class StringUtil
    {
        public static string BytesToString(byte[] bytes, int length)
        {
            return Encoding.UTF8.GetString(bytes, 0, length);
        }
    }
}
