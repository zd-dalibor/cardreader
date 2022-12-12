﻿// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using CardReader.Service;
using CardReader.UI;
using CardReader.UI.ViewModel.MainPage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
using CommunityToolkit.Mvvm.Messaging;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CardReader
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            Services = ConfigureServices();

            this.InitializeComponent();

            // App.Current.RequestedTheme = ApplicationTheme.Light;
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            InitLocale();

            Shell = Services.GetService<Shell>();
            Shell.Init();
        }

        private static void InitLocale()
        {
            var cult = "sr-Latn-RS";
            //var cult = "en-US";
            //ApplicationLanguages.PrimaryLanguageOverride = cult;
            CultureInfo culture = new(cult);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.CurrentCulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            //Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().Reset();
            Windows.ApplicationModel.Resources.Core.ResourceContext.SetGlobalQualifierValue("Language", cult);
            Windows.ApplicationModel.Resources.Core.ResourceContext.GetForViewIndependentUse().Reset();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // services
            services.AddSingleton<Shell>();
            services.AddSingleton<AppState>();
            services.AddSingleton<IStringLoader, StringLoader>();
            services.AddSingleton<IMessenger>(_ => WeakReferenceMessenger.Default);

            // view models
            services.AddTransient<MainPageViewModel>();

            return services.BuildServiceProvider();
        }

        public new static App Current => (App)Application.Current;

        public IServiceProvider Services { get; }

        public Shell Shell { get; private set; }
    }
}
