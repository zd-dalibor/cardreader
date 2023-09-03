using CardReader.Core.Redux;
using CardReader.Core.Service.Configuration;
using CardReader.Core.Service.Globalization;
using CardReader.Core.Service.IdReader;
using CardReader.Core.Service.Resources;
using CardReader.Core.Service.Storage;
using CardReader.Core.State;
using CardReader.Infrastructure.Services.Globalization;
using CardReader.Infrastructure.Services.IdReader;
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
using Serilog.Events;
using Serilog;
using Splat;
using Splat.Serilog;
using AutoMapper;
using CardReader.Infrastructure.AutoMapper;

namespace CardReader.Infrastructure.DependencyInjection
{
    internal static class Services
    {
        public static void Configure()
        {
            // logging
            
            Locator.CurrentMutable.UseSerilogFullLogger();
            
            Locator.CurrentMutable
                .RegisterLoggerAnd()
                .RegisterAutoMapperAnd()
                .RegisterServicesAnd()
                .RegisterViewModelsAnd();
        }

        private static IMutableDependencyResolver RegisterLoggerAnd(this IMutableDependencyResolver resolver)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Debug()
                .WriteTo.File("logs.txt", restrictedToMinimumLevel: LogEventLevel.Error, fileSizeLimitBytes: 1_000_000)
                .CreateLogger();
            resolver.UseSerilogFullLogger();
            return resolver;
        }

        private static IMutableDependencyResolver RegisterAutoMapperAnd(this IMutableDependencyResolver resolver)
        {
            var me = new MapperConfigurationExpression();
            me.AddMaps(typeof(Services).Assembly);

            var mc = new MapperConfiguration(me);
            mc.AssertConfigurationIsValid();

            return resolver
                .RegisterConstantAnd(me)
                .RegisterConstantAnd<IConfigurationProvider>(mc)
                .RegisterAnd<IMapper>(() => new Mapper(mc, type => Locator.Current.GetService(type)))
                .RegisterAnd(() => new IdReaderCardTypeResolver(Locator.Current.GetService<IApplicationResources>()))
                .RegisterAnd(() => new IdReaderPortraitImageResolver());
        }

        private static IMutableDependencyResolver RegisterServicesAnd(this IMutableDependencyResolver resolver)
        {
            return resolver
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
                .RegisterLazySingletonAnd<IIdReaderService>(() => new IdReaderService());
        }

        private static IMutableDependencyResolver RegisterViewModelsAnd(this IMutableDependencyResolver resolver)
        {
            return resolver
                .RegisterAnd(() => new MainViewModel(
                    Locator.Current.GetService<IStore<IApplicationState>>(),
                    Locator.Current.GetService<IApplicationResources>()))
                .RegisterAnd(() => new HomeViewModel(
                    Locator.Current.GetService<IStore<IApplicationState>>()))
                .RegisterAnd(() => new IdReaderViewModel(
                    Locator.Current.GetService<IApplicationState>(),
                    Locator.Current.GetService<IApplicationResources>(),
                    Locator.Current.GetService<IIdReaderService>(),
                    Locator.Current.GetService<IMapper>()))
                .RegisterAnd(() => new SettingsViewModel())
                .RegisterAnd(() => new VehicleIdReaderViewModel());
        }
    }
}
