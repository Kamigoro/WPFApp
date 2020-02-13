﻿#pragma checksum "..\..\..\Views\PeopleListingPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "84561F1281E0D3DDBB808F627BAF664022A2985ECE4C5FBFA1D9AF83B09C935E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using DatabaseTestWPF.Views;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace DatabaseTestWPF.Views {
    
    
    /// <summary>
    /// PeopleListingPage
    /// </summary>
    public partial class PeopleListingPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 22 "..\..\..\Views\PeopleListingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListViewOfPeople;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Views\PeopleListingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBXPersonToAddFirstName;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Views\PeopleListingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBXPersonToAddLastName;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Views\PeopleListingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBXPersonToAddAge;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Views\PeopleListingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBXPersonToAddEmail;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Views\PeopleListingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTNAddPerson;
        
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
            System.Uri resourceLocater = new System.Uri("/DatabaseTestWPF;component/views/peoplelistingpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\PeopleListingPage.xaml"
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
            this.ListViewOfPeople = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.TBXPersonToAddFirstName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TBXPersonToAddLastName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TBXPersonToAddAge = ((System.Windows.Controls.TextBox)(target));
            
            #line 62 "..\..\..\Views\PeopleListingPage.xaml"
            this.TBXPersonToAddAge.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumericalTextBoxHandler);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TBXPersonToAddEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.BTNAddPerson = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\Views\PeopleListingPage.xaml"
            this.BTNAddPerson.Click += new System.Windows.RoutedEventHandler(this.BtnAddPerson_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 2:
            
            #line 32 "..\..\..\Views\PeopleListingPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BTNDeletePerson_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

