﻿#pragma checksum "..\..\..\..\..\..\..\..\Main\Resources\User Controls\Recipe\Article\ArticleGeneral.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CD9B92533729ED30209FE8BF66A0A66320F6FD8445E29401D9137E1881AA44E7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
using System.Windows.Forms.Integration;
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
using VisiWin.Adapter;
using VisiWin.ApplicationFramework;
using VisiWin.Controls;
using VisiWin.Extensions;
using VisiWin.Shapes;


namespace HMI.Resources.UserControls {
    
    
    /// <summary>
    /// ArticleGeneral
    /// </summary>
    public partial class ArticleGeneral : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\..\..\..\..\..\Main\Resources\User Controls\Recipe\Article\ArticleGeneral.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.ComboBox Art;
        
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
            System.Uri resourceLocater = new System.Uri("/251252-Raymond-1;component/main/resources/user%20controls/recipe/article/article" +
                    "general.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\..\Main\Resources\User Controls\Recipe\Article\ArticleGeneral.xaml"
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
            
            #line 5 "..\..\..\..\..\..\..\..\Main\Resources\User Controls\Recipe\Article\ArticleGeneral.xaml"
            ((HMI.Resources.UserControls.ArticleGeneral)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Art = ((VisiWin.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

