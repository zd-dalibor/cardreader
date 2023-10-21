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
using CardReader.Core.Service.Reporting;
using CardReader.Core.Service.VehicleIdReader;
using CardReader.Infrastructure.AutoMapper;
using CardReader.Infrastructure.Services.Reporting;
using CardReader.Infrastructure.Services.VehicleIdReader;
using CardReader.UI.Helper;

namespace CardReader.Infrastructure.DependencyInjection
{
    internal static class Services
    {
        public static void Configure()
        {
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
                .RegisterAnd(() => new IdReaderCardTypeResolver(Locator.Current.GetRequiredService<IApplicationResources>()))
                .RegisterAnd(() => new IdReaderPortraitImageResolver())
                .RegisterAnd(() => new VehicleIdTooltipResolver(Locator.Current.GetRequiredService<IApplicationResources>()));
        }

        private static IMutableDependencyResolver RegisterServicesAnd(this IMutableDependencyResolver resolver)
        {
            return resolver
                .RegisterLazySingletonAnd<ILocaleService>(() => new LocaleService(
                    Locator.Current.GetRequiredService<IApplicationSettings>(),
                    Locator.Current.GetRequiredService<IApplicationLanguages>(),
                    Locator.Current.GetRequiredService<IApplicationResources>()))
                .RegisterLazySingletonAnd<IApplicationSettings>(() => new ApplicationSettings(
                    Locator.Current.GetRequiredService<IApplicationStorage>()))
                .RegisterLazySingletonAnd<IApplicationLanguages>(() => new ApplicationLanguages())
                .RegisterLazySingletonAnd<IApplicationStorage>(() => new ApplicationStorage())
                .RegisterLazySingletonAnd<IApplicationResources>(() => new ApplicationResources())
                .RegisterLazySingletonAnd<IApplicationState>(() => new ApplicationState(
                    Locator.Current.GetRequiredService<IApplicationSettings>()))
                .RegisterLazySingletonAnd<IStore<IApplicationState>>(() => new ApplicationStore(
                    Locator.Current.GetRequiredService<IApplicationState>()))
                .RegisterLazySingletonAnd<IIdReaderService>(() => new IdReaderService())
                .RegisterLazySingletonAnd<IReportingService>(() => new ReportingService(
                    Locator.Current.GetRequiredService<IApplicationResources>()))
                .RegisterLazySingletonAnd(() => new ThemeHelper())
                .RegisterLazySingletonAnd<IVehicleIdReaderService>(() => new VehicleIdReaderService());
        }

        private static IMutableDependencyResolver RegisterViewModelsAnd(this IMutableDependencyResolver resolver)
        {
            return resolver
                .RegisterAnd(() => new MainViewModel(
                    Locator.Current.GetRequiredService<IStore<IApplicationState>>(),
                    Locator.Current.GetRequiredService<IApplicationResources>()))
                .RegisterAnd(() => new HomeViewModel())
                .RegisterAnd(() => new IdReaderViewModel(
                    Locator.Current.GetRequiredService<IApplicationState>(),
                    Locator.Current.GetRequiredService<IApplicationResources>(),
                    Locator.Current.GetRequiredService<IIdReaderService>(),
                    Locator.Current.GetRequiredService<IReportingService>(),
                    Locator.Current.GetRequiredService<IMapper>()))
                .RegisterAnd(() => new SettingsViewModel(
                    Locator.Current.GetRequiredService<ILocaleService>(),
                    Locator.Current.GetRequiredService<IApplicationSettings>(),
                    Locator.Current.GetRequiredService<IApplicationResources>()))
                .RegisterAnd(() => new VehicleIdReaderViewModel(
                    Locator.Current.GetRequiredService<IApplicationState>(),
                    Locator.Current.GetRequiredService<IApplicationResources>(),
                    Locator.Current.GetRequiredService<IVehicleIdReaderService>(),
                    Locator.Current.GetRequiredService<IMapper>(),
                    Locator.Current.GetRequiredService<IReportingService>()));
        }
    }
}
