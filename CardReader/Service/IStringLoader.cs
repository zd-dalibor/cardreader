using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardReader.Service
{
    public interface IStringLoader
    {
        public string GetString(string key);

        public string GetString(string key, params object[] subs);

        public CultureInfo GetCurrentLocale();
    }
}
