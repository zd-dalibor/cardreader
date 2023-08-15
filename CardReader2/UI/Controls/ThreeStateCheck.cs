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
    public sealed class ThreeStateCheck : Control
    {
        public static readonly DependencyProperty StateProperty = DependencyProperty.Register(
            nameof(State),
            typeof(bool?),
            typeof(ThreeStateCheck),
            new PropertyMetadata(null, StatePropertyChangedCallback));

        private static void StatePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctl = (ThreeStateCheck)d;
            ctl.UpdateStates(true);
        }

        public bool? State
        {
            get => (bool?) GetValue(StateProperty);
            set => SetValue(StateProperty, value);
        }

        public ThreeStateCheck()
        {
            this.DefaultStyleKey = typeof(ThreeStateCheck);
        }

        protected override void OnApplyTemplate()
        {
            UpdateStates(false);
            base.OnApplyTemplate();
        }

        private void UpdateStates(bool useTransitions)
        {
            string state;
            if (State.HasValue)
            {
                state = State.Value ? "Success" : "Failed";
            }
            else
            {
                state = "None";
            }
            VisualStateManager.GoToState(this, state, useTransitions);
        }
    }
}
