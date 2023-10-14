using System;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using CardReader.Core.Service.Configuration;
using CardReader.Core.Service.Globalization;
using CardReader.Core.Service.Resources;
using DynamicData;
using DynamicData.Binding;
using Microsoft.UI.Xaml;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace CardReader.UI.Settings
{
    public class SettingsViewModel : ReactiveObject, IActivatableViewModel
    {
        [Reactive]
        public IObservableCollection<LanguageItem> LanguageItems { get; set; }

        [Reactive]
        public IObservableCollection<ThemeItem> ThemeItems { get; set; }

        [Reactive]
        public LanguageItem CurrentLanguage { get; set; }

        [Reactive]
        public ThemeItem CurrentTheme { get; set; }

        private readonly ISourceCache<LanguageItem, string> languageItemsSource =
            new SourceCache<LanguageItem, string>(t => t.Locale);

        private readonly ISourceCache<ThemeItem, ElementTheme> themesSource = 
            new SourceCache<ThemeItem, ElementTheme>(t => t.Value);


        public ViewModelActivator Activator { get; }

        private readonly ILocaleService localeService;
        private readonly IApplicationSettings settings;
        private readonly IApplicationResources resources;

        public SettingsViewModel(ILocaleService localeService, IApplicationSettings settings, IApplicationResources resources)
        {
            this.localeService = localeService;
            this.settings = settings;
            this.resources = resources;

            Activator = new ViewModelActivator();
            LanguageItems = new ObservableCollectionExtended<LanguageItem>();
            ThemeItems = new ObservableCollectionExtended<ThemeItem>();

            InitLanguageItems();
            InitThemes();

            this.WhenActivated(disposables =>
            {
                languageItemsSource.Connect()
                    .Bind(LanguageItems)
                    .Subscribe()
                    .DisposeWith(disposables);

                themesSource.Connect()
                    .Bind(ThemeItems)
                    .Subscribe()
                    .DisposeWith(disposables);

                this.WhenAnyValue(x => x.CurrentLanguage)
                    .Subscribe(LanguageChanged)
                    .DisposeWith(disposables);

                this.WhenAnyValue(x => x.CurrentTheme)
                    .Subscribe(ThemeChanged)
                    .DisposeWith(disposables);

                resources.Observe()
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Subscribe(_ => LoadStrings())
                    .DisposeWith(disposables);

                UpdateCurrentLanguage();
                UpdateCurrentTheme();
            });
        }

        private void LanguageChanged(LanguageItem languageItem)
        {
            if (languageItem == null) return;

            var currentLocale = settings.CurrentLocale(localeService.DefaultLocale);
            if (!currentLocale.Equals(languageItem.Locale))
            {
                localeService.ChangeLocale(languageItem.Locale);
            }
        }

        private void UpdateCurrentLanguage()
        {
            CurrentLanguage = languageItemsSource.Items.First(x => 
                x.Locale.Equals(settings.CurrentLocale(localeService.DefaultLocale)));
        }

        private void ThemeChanged(ThemeItem themeItem)
        {
            if (themeItem == null) return;

            var currentTheme = App.Current.GetTheme();
            if (currentTheme.Equals(themeItem.Value)) return;

            App.Current.SetTheme(themeItem.Value);
            var themeStr = Enum.GetName(themeItem.Value);
            if (themeStr != null)
            {
                settings.UpdateAppTheme(themeStr);
            }
        }

        private void UpdateCurrentTheme()
        {
            CurrentTheme = themesSource.Items.First(x => x.Value.Equals(App.Current.GetTheme()));
        }

        private void LoadStrings()
        {
            InitThemes();
            UpdateCurrentTheme();
        }

        private void InitLanguageItems()
        {
            languageItemsSource.Edit(t => t.AddOrUpdate(new []
            {
                new LanguageItem
                {
                    Locale = "sr-Latn-RS",
                    Language = "Srpski"
                },
                new LanguageItem
                {
                    Locale = "en-US",
                    Language = "English"
                }
            }));
        }

        private void InitThemes()
        {
            themesSource.Edit(t => t.AddOrUpdate(new []
            {
                new ThemeItem
                {
                    Value = ElementTheme.Light,
                    Name = resources.GetString("ThemeLight")
                },
                new ThemeItem
                {
                    Value = ElementTheme.Dark,
                    Name = resources.GetString("ThemeDark")
                },
                new ThemeItem
                {
                    Value = ElementTheme.Default,
                    Name = resources.GetString("ThemeDefault")
                }
            }));
        }
    }
}
