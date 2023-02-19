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
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.SmartCards;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CardReader.UI.Controls
{
    public sealed class CardReader : Control
    {
        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
            nameof(Header),
            typeof(object),
            typeof(CardReader),
            new PropertyMetadata(null));

        public static readonly DependencyProperty RefreshTooltipProperty = DependencyProperty.Register(
            nameof(RefreshTooltip),
            typeof(object),
            typeof(CardReader),
            new PropertyMetadata(null));

        public static readonly DependencyProperty CardReaderIdProperty = DependencyProperty.Register(
            nameof(CardReaderId),
            typeof(string),
            typeof(CardReader),
            new PropertyMetadata(null));

        public static readonly DependencyProperty CardReaderNameProperty = DependencyProperty.Register(
            nameof(CardReaderName),
            typeof(string),
            typeof(CardReader),
            new PropertyMetadata(null));

        public object Header
        {
            get => GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        public object RefreshTooltip
        {
            get => GetValue(RefreshTooltipProperty);
            set => SetValue(RefreshTooltipProperty, value);
        }

        public string CardReaderId
        {
            get => (string)GetValue(CardReaderIdProperty);
            set => SetValue(CardReaderIdProperty, value);
        }

        public string CardReaderName
        {
            get => (string)GetValue(CardReaderNameProperty);
            set => SetValue(CardReaderNameProperty, value);
        }

        public CardReader()
        {
            this.DefaultStyleKey = typeof(CardReader);
        }

        protected override void OnApplyTemplate()
        {
            var refreshBtn = (Button)GetTemplateChild("RefreshBtn");
            refreshBtn.Click += RefreshBtn_Click;

            cardReaderCmb = (ComboBox)GetTemplateChild("CardReaderCmb");
            cardReaderCmb.ItemsSource = cardReaders;
            cardReaderCmb.DisplayMemberPath = nameof(CardReaderInfo.Name);
            cardReaderCmb.SelectionChanged += CardReaderCmb_SelectionChanged;

            PullCardReadersAsync();
            base.OnApplyTemplate();
        }

        private void CardReaderCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (CardReaderInfo) ((ComboBox)sender).SelectedItem;
            CardReaderId = item?.Id;
            CardReaderName = item?.Name;
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            PullCardReadersAsync();
        }

        private async void PullCardReadersAsync()
        {
            var cardReaderId = CardReaderId;

            cardReaders.Clear();
            var devices = await DeviceInformation.FindAllAsync(SmartCardReader.GetDeviceSelector());

            foreach (var device in devices)
            {
                cardReaders.Add(new CardReaderInfo
                {
                    Id = device.Id,
                    Name = device.Name
                });
            }

            var selected = devices.Select((x, i) => new { item = x, index = i})
                .FirstOrDefault(x => x.item.Id.Equals(cardReaderId), devices.Count > 0 ? new { item = devices[0], index = 0 } : null);

            if (selected == null)
            {
                cardReaderCmb.SelectedIndex = -1;
                CardReaderId = null;
                CardReaderName = null;
            }
            else
            {
                cardReaderCmb.SelectedIndex = selected.index;
                CardReaderId = selected.item.Id;
                CardReaderName = selected.item.Name;
            }
        }

        private ComboBox cardReaderCmb;

        private readonly ObservableCollection<CardReaderInfo> cardReaders = new();

        private class CardReaderInfo
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
    }
}
