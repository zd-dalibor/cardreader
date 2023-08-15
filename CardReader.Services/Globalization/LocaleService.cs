using CardReader.Core.Service.Configuration;
using CardReader.Core.Service.Globalization;
using CardReader.Core.Service.Resources;

namespace CardReader.Services.Globalization
{
    public class LocaleService : ILocaleService
    {
        public string DefaultLocale => "sr-Latn-RS"; // "en-US"

        private readonly IApplicationSettings settings;

        private readonly IApplicationLanguages languages;

        private readonly IApplicationResources resources;

        public LocaleService(IApplicationSettings settings, IApplicationLanguages languages,
            IApplicationResources resources)
        {
            this.settings = settings;
            this.languages = languages;
            this.resources = resources;
        }

        public void Init()
        {
            languages.ChangeLanguage(settings.CurrentLocale(DefaultLocale));
        }

        public void ChangeLocale(string locale)
        {
            settings.UpdateCurrentLocale(locale);
            languages.ChangeLanguage(locale);
        }

        public string GetString(string key, bool forCurrentView = false)
        {
            return resources.GetString(key, forCurrentView);
        }
    }
}
