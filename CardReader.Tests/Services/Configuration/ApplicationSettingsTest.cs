using CardReader.Core.Service.Storage;
using CardReader.Services.Configuration;

namespace CardReader.Tests.Services.Configuration
{
    public class ApplicationSettingsTest
    {
        private readonly IApplicationStorage storageMock;

        private readonly ApplicationSettings applicationSettings;

        private readonly string defaultLocale;

        public ApplicationSettingsTest()
        {
            defaultLocale = "testLocale";

            storageMock = Substitute.For<IApplicationStorage>();
            applicationSettings = new ApplicationSettings(storageMock);
        }

        [Fact]
        public void CurrentLocale_GivenDefaultLocale_ShouldCheckApplicationSettings()
        {
            storageMock.GetSettings(Arg.Any<string>(), defaultLocale).Returns(defaultLocale);

            var result = applicationSettings.CurrentLocale(defaultLocale);

            storageMock.Received().GetSettings(Arg.Any<string>(), defaultLocale);
            result.Should().Be(defaultLocale);
        }

        [Fact]
        public void UpdateCurrentLocale_GivenLocale_ShouldCheckApplicationSettings()
        {
            applicationSettings.UpdateCurrentLocale(defaultLocale);
            storageMock.Received().SetSettings(Arg.Any<string>(), defaultLocale);
        }
    }
}
