﻿#pragma checksum "..\..\..\..\GUI\LoginWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "44EFF88BCB2FA6098DE367F26E3B0237F70C06E3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Project1_BookStore;
using Project1_BookStore.Utils;
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


namespace Project1_BookStore {
    
    
    /// <summary>
    /// LoginWindow
    /// </summary>
    public partial class LoginWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 139 "..\..\..\..\GUI\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button minButton;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\..\..\GUI\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button maxButton;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\..\..\GUI\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button reDownButton;
        
        #line default
        #line hidden
        
        
        #line 168 "..\..\..\..\GUI\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button closeButton;
        
        #line default
        #line hidden
        
        
        #line 217 "..\..\..\..\GUI\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox userTextBox;
        
        #line default
        #line hidden
        
        
        #line 237 "..\..\..\..\GUI\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passTextBox;
        
        #line default
        #line hidden
        
        
        #line 252 "..\..\..\..\GUI\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button loginButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Project1_BookStore;component/gui/loginwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\GUI\LoginWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\..\GUI\LoginWindow.xaml"
            ((Project1_BookStore.LoginWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 11 "..\..\..\..\GUI\LoginWindow.xaml"
            ((Project1_BookStore.LoginWindow)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.minButton = ((System.Windows.Controls.Button)(target));
            
            #line 140 "..\..\..\..\GUI\LoginWindow.xaml"
            this.minButton.Click += new System.Windows.RoutedEventHandler(this.minButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.maxButton = ((System.Windows.Controls.Button)(target));
            
            #line 154 "..\..\..\..\GUI\LoginWindow.xaml"
            this.maxButton.Click += new System.Windows.RoutedEventHandler(this.maxButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.reDownButton = ((System.Windows.Controls.Button)(target));
            
            #line 160 "..\..\..\..\GUI\LoginWindow.xaml"
            this.reDownButton.Click += new System.Windows.RoutedEventHandler(this.maxButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.closeButton = ((System.Windows.Controls.Button)(target));
            
            #line 169 "..\..\..\..\GUI\LoginWindow.xaml"
            this.closeButton.Click += new System.Windows.RoutedEventHandler(this.closeButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.userTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.passTextBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 8:
            this.loginButton = ((System.Windows.Controls.Button)(target));
            
            #line 252 "..\..\..\..\GUI\LoginWindow.xaml"
            this.loginButton.Click += new System.Windows.RoutedEventHandler(this.loginButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

