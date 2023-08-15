using System;
using CardReader.Core.Redux;
using CardReader.Core.Service.Configuration;
using CardReader.Core.Service.Globalization;
using CardReader.Core.Service.Resources;
using CardReader.Core.Service.Storage;
using CardReader.Core.State;
using CardReader.Infrastructure.Services.Globalization;
using CardReader.Infrastructure.Services.Resources;
using CardReader.Infrastructure.Services.Storage;
using CardReader.Infrastructure.State;
using CardReader.Services.Configuration;
using CardReader.Services.Globalization;
using CardReader.UI.Home;
using CardReader.UI.IdReader;
using CardReader.UI.Main;
using CardReader.UI.Settings;
using CardReader.UI.VehicleIdReader;
using Splat;

namespace CardReader.Infrastructure.DependencyInjection
{
    internal static class Services
    {
        public static void Configure()
        {
            Locator.CurrentMutable
                // services
                .RegisterLazySingletonAnd<ILocaleService>(() => new LocaleService(
                    Locator.Current.GetService<IApplicationSettings>(),
                    Locator.Current.GetService<IApplicationLanguages>(),
                    Locator.Current.GetService<IApplicationResources>()))
                .RegisterLazySingletonAnd<IApplicationSettings>(() => new ApplicationSettings(
                    Locator.Current.GetService<IApplicationStorage>()))
                .RegisterLazySingletonAnd<IApplicationLanguages>(() => new ApplicationLanguages())
                .RegisterLazySingletonAnd<IApplicationStorage>(() => new ApplicationStorage())
                .RegisterLazySingletonAnd<IApplicationResources>(() => new ApplicationResources())
                .RegisterLazySingletonAnd<IApplicationState>(() => new ApplicationState(
                    Locator.Current.GetService<IApplicationSettings>()))
                .RegisterLazySingletonAnd<IStore<IApplicationState>>(() => new ApplicationStore(
                    Locator.Current.GetService<IApplicationState>()))
                // view models
                .RegisterAnd(() => new MainViewModel(
                    Locator.Current.GetService<IStore<IApplicationState>>(),
                    Locator.Current.GetService<IApplicationResources>()))
                .RegisterAnd(() => new HomeViewModel(
                    Locator.Current.GetService<IStore<IApplicationState>>()))
                .RegisterAnd(() => new IdReaderViewModel())
                .RegisterAnd(() => new SettingsViewModel())
                .RegisterAnd(() => new VehicleIdReaderViewModel())
            ;
        }
    }
}
