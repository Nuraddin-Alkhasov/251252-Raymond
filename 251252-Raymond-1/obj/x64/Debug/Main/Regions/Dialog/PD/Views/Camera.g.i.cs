﻿#pragma checksum "..\..\..\..\..\..\..\..\Main\Regions\Dialog\PD\Views\Camera.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1ACA8B6F0D153E4F11A31E1DEE0BAB20FEE7DDA8BAC7575AD39B303CF843BD57"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HMI.Resources.UserControls.MO;
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


namespace HMI.DialogRegion.PD.Views {
    
    
    /// <summary>
    /// Camera
    /// </summary>
    public partial class Camera : VisiWin.Controls.View, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\..\..\..\..\Main\Regions\Dialog\PD\Views\Camera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid border;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\..\..\..\Main\Regions\Dialog\PD\Views\Camera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.TextBlock HeaderText;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\..\..\..\..\Main\Regions\Dialog\PD\Views\Camera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.Button CancelButton;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\..\..\..\Main\Regions\Dialog\PD\Views\Camera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel LayoutRoot;
        
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
            System.Uri resourceLocater = new System.Uri("/251252-Raymond-1;component/main/regions/dialog/pd/views/camera.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\..\Main\Regions\Dialog\PD\Views\Camera.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 10 "..\..\..\..\..\..\..\..\Main\Regions\Dialog\PD\Views\Camera.xaml"
            ((VisiWin.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancel_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.border = ((System.Windows.Controls.Grid)(target));
            
            #line 12 "..\..\..\..\..\..\..\..\Main\Regions\Dialog\PD\Views\Camera.xaml"
            this.border.Loaded += new System.Windows.RoutedEventHandler(this.Camera_Loaded);
            
            #line default
            #line hidden
            
            #line 12 "..\..\..\..\..\..\..\..\Main\Regions\Dialog\PD\Views\Camera.xaml"
            this.border.Unloaded += new System.Windows.RoutedEventHandler(this.Camera_Unlaoded);
            
            #line default
            #line hidden
            return;
            case 3:
            this.HeaderText = ((VisiWin.Controls.TextBlock)(target));
            return;
            case 4:
            this.CancelButton = ((VisiWin.Controls.Button)(target));
            
            #line 31 "..\..\..\..\..\..\..\..\Main\Regions\Dialog\PD\Views\Camera.xaml"
            this.CancelButton.Click += new System.Windows.RoutedEventHandler(this.Cancel_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.LayoutRoot = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            
            #line 47 "..\..\..\..\..\..\..\..\Main\Regions\Dialog\PD\Views\Camera.xaml"
            ((VisiWin.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Camera1_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 64 "..\..\..\..\..\..\..\..\Main\Regions\Dialog\PD\Views\Camera.xaml"
            ((VisiWin.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Camera2_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 73 "..\..\..\..\..\..\..\..\Main\Regions\Dialog\PD\Views\Camera.xaml"
            ((VisiWin.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Clean_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 74 "..\..\..\..\..\..\..\..\Main\Regions\Dialog\PD\Views\Camera.xaml"
            ((VisiWin.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Discharge_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

