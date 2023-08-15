using System;
using CardReader.Core.Service.Globalization;
using CardReader.Core.Service.Resources;
using CardReader.Infrastructure.Services.Resources;
using Splat;

namespace CardReader.Infrastructure.DependencyInjection
{
    internal static class SplatExtensions
    {
        public static IReadonlyDependencyResolver InitLocale(this IReadonlyDependencyResolver resolver)
        {
            resolver.GetService<ILocaleService>().Init();
            return resolver;
        }

        public static IReadonlyDependencyResolver StartResourceObserver(this IReadonlyDependencyResolver resolver)
        {
            var resources = resolver.GetService<IApplicationResources>();
            if (resources is ApplicationResources r)
            {
                r.StartObserver();
            }

            return resolver;
        }

        public static IReadonlyDependencyResolver StopResourceObserver(this IReadonlyDependencyResolver resolver)
        {
            var resources = resolver.GetService<IApplicationResources>();
            if (resources is ApplicationResources r)
            {
                r.StopObserver();
            }

            return resolver;
        }
    }
}
