﻿#pragma checksum "..\..\..\..\..\..\Editor.Windows\NonCrud.Windows\Settings.Windows\GetCustomersByMinBalanceSettingsWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7B6C8E4F2EA383006D7408AA9051C949BEB38909"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BankApplication.WPFClient.Editor.Windows.NonCrud.Windows.Settings.Windows;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace BankApplication.WPFClient.Editor.Windows.NonCrud.Windows.Settings.Windows {
    
    
    /// <summary>
    /// GetCustomersByMinBalanceSettingsWindow
    /// </summary>
    public partial class GetCustomersByMinBalanceSettingsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\..\..\..\..\Editor.Windows\NonCrud.Windows\Settings.Windows\GetCustomersByMinBalanceSettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox minAmount;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\..\Editor.Windows\NonCrud.Windows\Settings.Windows\GetCustomersByMinBalanceSettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button submitButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BankApplication.WPFClient;component/editor.windows/noncrud.windows/settings.wind" +
                    "ows/getcustomersbyminbalancesettingswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Editor.Windows\NonCrud.Windows\Settings.Windows\GetCustomersByMinBalanceSettingsWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.minAmount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.submitButton = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\..\..\..\Editor.Windows\NonCrud.Windows\Settings.Windows\GetCustomersByMinBalanceSettingsWindow.xaml"
            this.submitButton.Click += new System.Windows.RoutedEventHandler(this.submitButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

