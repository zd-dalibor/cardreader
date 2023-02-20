// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using CardReader.UI.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using IdReaderPageViewModel = CardReader.UI.ViewModel.IdReader.IdReaderPageViewModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CardReader.UI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class IdReaderPage : Page
    {
        public IdReaderPageViewModel ViewModel { get; set; }

        public IdReaderPage()
        {
            ViewModel = App.Current.Services.GetService<IdReaderPageViewModel>();

            this.InitializeComponent();
        }
    }
}
