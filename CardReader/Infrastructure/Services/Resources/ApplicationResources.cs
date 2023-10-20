#nullable enable
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Windows.ApplicationModel.Resources;
using Windows.ApplicationModel.Resources.Core;
using Windows.Foundation.Collections;
using CardReader.Core.Service.Resources;

namespace CardReader.Infrastructure.Services.Resources
{
    internal class ApplicationResources : IApplicationResources
    {
        private static ResourceLoader ResourceLoaderForCurrentView => ResourceLoader.GetForCurrentView();

        private static ResourceLoader ResourceLoaderForViewIndependentUse => ResourceLoader.GetForViewIndependentUse();

        private readonly Subject<IDictionary<string, string>> subject = new();

        private IDisposable? disposable;

        public string GetString(string resource, bool forCurrentView = false)
        {
            return forCurrentView
                ? ResourceLoaderForCurrentView.GetString(resource)
                : ResourceLoaderForViewIndependentUse.GetString(resource);
        }

        public string GetString(string resource, params object?[] objects)
        {
            return string.Format(GetString(resource), objects);
        }

        public string GetString(string resource, bool forCurrentView, params object?[] objects)
        {
            return string.Format(GetString(resource, forCurrentView), objects);
        }

        public IObservable<IDictionary<string, string>> Observe()
        {
            return subject;
        }

        public void StartObserver()
        {
            disposable?.Dispose();
            var resourceContext = ResourceContext.GetForViewIndependentUse();
            disposable = Observable.FromEvent<MapChangedEventHandler<string, string>, IDictionary<string, string>>(
                handler =>
                {
                    return EventHandler;

                    void EventHandler(IObservableMap<string, string> sender, IMapChangedEventArgs<string> args)
                    {
                        handler(sender);
                    }
                },
                handler => resourceContext.QualifierValues.MapChanged += handler,
                handler => resourceContext.QualifierValues.MapChanged -= handler)
                .Subscribe(subject.OnNext);
        }

        public void StopObserver()
        {
            disposable?.Dispose();
        }
    }
}