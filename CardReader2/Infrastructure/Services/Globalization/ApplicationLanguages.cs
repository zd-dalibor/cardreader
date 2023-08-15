using System;
using System.Linq;
using CardReader.Core.Service.Globalization;

namespace CardReader.Infrastructure.Services.Globalization
{
    internal class ApplicationLanguages : IApplicationLanguages
    {
        public void ChangeLanguage(string language)
        {
            var languages = Windows.Globalization.ApplicationLanguages.Languages;
            if (!languages.FirstOrDefault(language).Equals(language, StringComparison.OrdinalIgnoreCase))
            {
                Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = language;
            }
        }
    }
}
