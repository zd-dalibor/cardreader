using CardReader.Core.Service.Configuration;
using CardReader.Core.Service.Globalization;
using CardReader.Core.Service.Resources;
using CardReader.Services.Globalization;

namespace CardReader.Tests.Services.Globalization
{
    public class LocaleServiceTest
    {
        private readonly IApplicationSettings settings;

        private readonly IApplicationLanguages languages;

        private readonly IApplicationResources resources;

        private readonly LocaleService locale;

        private readonly string defaultLocale;

        public LocaleServiceTest()
        {
            defaultLocale = "testLocale";
            settings = Substitute.For<IApplicationSettings>();
            languages = Substitute.For<IApplicationLanguages>();
            resources = Substitute.For<IApplicationResources>();
            locale = new LocaleService(settings, languages, resources);
        }

        [Fact]
        public void Init_ShouldChangeLanguageToDefaultLocale()
        {
            settings.CurrentLocale(Arg.Any<string>()).Returns(defaultLocale);

            locale.Init();
            languages.Received().ChangeLanguage(defaultLocale);
        }

        [Fact]
        public void ChangeLocale_GivenLocale_ShouldUpdateCurrentLocaleAndChangeLanguage()
        {
            locale.ChangeLocale(defaultLocale);
            settings.Received().UpdateCurrentLocale(defaultLocale);
            languages.Received().ChangeLanguage(defaultLocale);
        }

        [Fact]
        public void GetString_GivenKey_ShouldReturnStringResource()
        {
            const string resourceKey = "key";
            const string resourceValue = "value";

            resources.GetString(resourceKey).Returns(resourceValue);

            var result = locale.GetString(resourceKey);
            result.Should().Be(resourceValue);
        }
    }
}
