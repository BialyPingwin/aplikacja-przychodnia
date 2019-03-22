﻿#pragma checksum "..\..\..\Pages\LoginPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DC75A4FA1EE208AB6D617361D398BEFA492E2207"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using aplikacja_przychodnia;


namespace aplikacja_przychodnia {
    
    
    /// <summary>
    /// LoginPage
    /// </summary>
    public partial class LoginPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Pages\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox login_input;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Pages\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox password_input;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Pages\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Login_button;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/aplikacja-przychodnia;component/pages/loginpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\LoginPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.login_input = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\..\Pages\LoginPage.xaml"
            this.login_input.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.SelectAddress);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\Pages\LoginPage.xaml"
            this.login_input.GotKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.SelectAddress);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\Pages\LoginPage.xaml"
            this.login_input.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.SelectivelyIgnoreMouseButton);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\Pages\LoginPage.xaml"
            this.login_input.LostKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.RestoreValue);
            
            #line default
            #line hidden
            return;
            case 2:
            this.password_input = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 15 "..\..\..\Pages\LoginPage.xaml"
            this.password_input.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.SelectAddress);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\Pages\LoginPage.xaml"
            this.password_input.GotKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.SelectAddress);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\Pages\LoginPage.xaml"
            this.password_input.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.SelectivelyIgnoreMouseButton);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\Pages\LoginPage.xaml"
            this.password_input.LostKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.RestoreValue);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Login_button = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Pages\LoginPage.xaml"
            this.Login_button.Click += new System.Windows.RoutedEventHandler(this.Login_button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

