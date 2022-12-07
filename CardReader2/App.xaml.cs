// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;

using Windows.Devices.SmartCards;
using Windows.Devices.Enumeration;
using CardReader.Model.Converters;
using CardReader.Util;
using System.Threading.Tasks;

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
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            //Task.Run(() => ReadIdSmartCard());
            //Task.Run(() => ReadDriverLicenseSmartCard());
            
            m_window = new MainWindow();
            m_window.Activate();
            
        }

        private Window m_window;

        private static async Task ReadIdSmartCard()
        {
            var result = IdReaderLib.IdReader.EidStartup(3);
            Debug.WriteLine($"IdReader startup: {result}");

            var smSelector = SmartCardReader.GetDeviceSelector();
            var smReaders = await DeviceInformation.FindAllAsync(smSelector);

            string smReaderName = null;
            foreach (var sm in smReaders)
            {
                Debug.WriteLine($"Kard reader: {sm.Name}");
                smReaderName = sm.Name;
            }

            if (smReaderName != null)
            {
                result = IdReaderLib.IdReader.EidBeginRead(smReaderName, out var pnCardType);
                Debug.WriteLine($"IdReader begin read: {result}");
                if (result == IdReaderLib.IdReader.EID_OK)
                {
                    Debug.WriteLine($"Card type: {pnCardType}");

                    var pDocumentData = new IdReaderLib.EID_DOCUMENT_DATA();
                    result = IdReaderLib.IdReader.EidReadDocumentData(ref pDocumentData);
                    Debug.WriteLine($"IdReader read document data: {result}");
                    if (result == IdReaderLib.IdReader.EID_OK)
                    {
                        var documentData = DocumentDataConverter.From(pDocumentData);
                        Debug.WriteLine($"Document data: {DebugUtil.Dump(documentData)}");
                        await Task.Delay(600);
                    }

                    var pFixedPersonalData = new IdReaderLib.EID_FIXED_PERSONAL_DATA();
                    result = IdReaderLib.IdReader.EidReadFixedPersonalData(ref pFixedPersonalData);
                    Debug.WriteLine($"IdReader read fixed presonal data: {result}");
                    if (result == IdReaderLib.IdReader.EID_OK)
                    {
                        var fixedPersonalData = FixedPersonalDataConverter.From(pFixedPersonalData);
                        Debug.WriteLine($"Fixed personal data: {DebugUtil.Dump(fixedPersonalData)}");
                        await Task.Delay(600);
                    }

                    var pVariablePersonalData = new IdReaderLib.EID_VARIABLE_PERSONAL_DATA();
                    result = IdReaderLib.IdReader.EidReadVariablePersonalData(ref pVariablePersonalData);
                    Debug.WriteLine($"IdReader read variable personal data: {result}");
                    if (result == IdReaderLib.IdReader.EID_OK)
                    {
                        var variablePersonalData = VariablePersonalDataConverter.From(pVariablePersonalData);
                        Debug.WriteLine($"Variable personal data: {DebugUtil.Dump(variablePersonalData)}");
                        await Task.Delay(600);
                    }

                    var pPortrait = new IdReaderLib.EID_PORTRAIT();
                    result = IdReaderLib.IdReader.EidReadPortrait(ref pPortrait);
                    Debug.WriteLine($"IdReader read portrait: {result}");
                    if (result == IdReaderLib.IdReader.EID_OK)
                    {
                        var portraitData = PortraitDataConverer.From(pPortrait);
                        Debug.WriteLine($"Portrait: {portraitData.PortraitBase64}");
                        await Task.Delay(600);
                    }
                }

                result = IdReaderLib.IdReader.EidEndRead();
                Debug.WriteLine($"IdReader end read: {result}");
            }

            result = IdReaderLib.IdReader.EidCleanup();
            Debug.WriteLine($"IdReader cleanup: {result}");
        }

        private static async Task ReadDriverLicenseSmartCard()
        {
            var temp2 = new DriverLicenseReaderLib.Class1();
            Debug.WriteLine(temp2.hello());
            await Task.Delay(1000);
        }
    }
}
