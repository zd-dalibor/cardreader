using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardReader.Service
{
    public interface IStringLoader
    {
        public string GetString(string key);
    }
}
