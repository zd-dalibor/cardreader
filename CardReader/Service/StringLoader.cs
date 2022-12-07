using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace CardReader.Service
{
    public class StringLoader : IStringLoader
    {
        private readonly ResourceLoader resourceLoader;

        public StringLoader()
        {
            resourceLoader = ResourceLoader.GetForViewIndependentUse();
        }

        public string GetString(string key)
        {
            return resourceLoader.GetString(key);
        }
    }
}
