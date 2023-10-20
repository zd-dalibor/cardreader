#nullable enable
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
            resolver.GetRequiredService<ILocaleService>().Init();
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

        public static T GetRequiredService<T>(this IReadonlyDependencyResolver resolver, string? contract = null)
        {
            return resolver.GetService<T>(contract) ?? throw new NullReferenceException($"Service of type {typeof(T)} cannot be found.");
        }
    }
}
