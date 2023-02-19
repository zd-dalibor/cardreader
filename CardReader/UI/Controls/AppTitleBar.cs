// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CardReader.UI.Controls
{
    public sealed class AppTitleBar : Control
    {
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            nameof(Icon),
            typeof(ImageSource),
            typeof(AppTitleBar),
            new PropertyMetadata(null));

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            nameof(Text),
            typeof(string),
            typeof(AppTitleBar),
            new PropertyMetadata(null));

        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register(
            nameof(IsActive),
            typeof(bool),
            typeof(AppTitleBar),
            new PropertyMetadata(true, IsActiveChangedCallback));

        public static readonly DependencyProperty IsBackButtonVisibleProperty = DependencyProperty.Register(
            nameof(IsBackButtonVisible),
            typeof(NavigationViewBackButtonVisible),
            typeof(AppTitleBar),
            new PropertyMetadata(NavigationViewBackButtonVisible.Collapsed, IsBackButtonVisibleChangedCallback));

        public static readonly DependencyProperty DisplayModeProperty = DependencyProperty.Register(
            nameof(DisplayMode),
            typeof(NavigationViewDisplayMode),
            typeof(AppTitleBar),
            new PropertyMetadata(NavigationViewDisplayMode.Minimal, NavigationViewDisplayModeChangedCallback));

        public static readonly DependencyProperty PaneDisplayModeProperty = DependencyProperty.Register(
            nameof(DisplayMode),
            typeof(NavigationViewPaneDisplayMode),
            typeof(AppTitleBar),
            new PropertyMetadata(NavigationViewPaneDisplayMode.Auto, PaneDisplayModeChangedCallback));

        private static void IsActiveChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctl = (AppTitleBar)d;
            ctl.UpdateStates(true);
        }

        private static void IsBackButtonVisibleChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctl = (AppTitleBar)d;
            ctl.UpdateStates(true);
        }

        private static void NavigationViewDisplayModeChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctl = (AppTitleBar)d;
            ctl.UpdateStates(true);
        }

        private static void PaneDisplayModeChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctl = (AppTitleBar)d;
            ctl.UpdateStates(true);
        }

        public ImageSource Icon
        {
            get => (ImageSource)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public bool IsActive
        {
            get => (bool)GetValue(IsActiveProperty);
            set => SetValue(IsActiveProperty, value);
        }

        public NavigationViewBackButtonVisible IsBackButtonVisible
        {
            get => (NavigationViewBackButtonVisible)GetValue(IsBackButtonVisibleProperty);
            set => SetValue(IsBackButtonVisibleProperty, value);
        }

        public NavigationViewDisplayMode DisplayMode
        {
            get => (NavigationViewDisplayMode)GetValue(DisplayModeProperty);
            set => SetValue(DisplayModeProperty, value);
        }

        public NavigationViewPaneDisplayMode PaneDisplayMode
        {
            get => (NavigationViewPaneDisplayMode)GetValue(PaneDisplayModeProperty);
            set => SetValue(PaneDisplayModeProperty, value);
        }

        public AppTitleBar()
        {
            this.DefaultStyleKey = typeof(AppTitleBar);
        }

        protected override void OnApplyTemplate()
        {
            UpdateStates(false);
            base.OnApplyTemplate();
        }

        private void UpdateStates(bool useTransitions)
        {
            VisualStateManager.GoToState(this, IsActive ? "Active" : "Inactive", useTransitions);

            var titleBarMargin = new Thickness(0, 0, 126, 0);
            if (PaneDisplayMode == NavigationViewPaneDisplayMode.Auto)
            {
                switch (DisplayMode)
                {
                    case NavigationViewDisplayMode.Compact:
                    case NavigationViewDisplayMode.Expanded:
                        titleBarMargin.Left = IsBackButtonVisible switch
                        {
                            NavigationViewBackButtonVisible.Collapsed => 0,
                            _ => 48
                        };
                        break;
                    case NavigationViewDisplayMode.Minimal:
                        titleBarMargin.Left = IsBackButtonVisible switch
                        {
                            NavigationViewBackButtonVisible.Collapsed => 0,
                            _ => 84
                        };
                        break;
                }
            }

            Margin = titleBarMargin;
        }
    }
}
