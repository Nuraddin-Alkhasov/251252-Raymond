﻿#pragma checksum "..\..\..\..\..\..\..\..\Main\Regions\Dialog\Protocol\Views\Protocol_Trend.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AF381F3BFA405ED2398B439AA057956CAB3AFC515B47E418557719B416B19788"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LiveCharts.Wpf;
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


namespace HMI.DialogRegion.Protocol.Views {
    
    
    /// <summary>
    /// Protocol_Trend
    /// </summary>
    public partial class Protocol_Trend : VisiWin.Controls.View, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\..\..\..\..\..\Main\Regions\Dialog\Protocol\Views\Protocol_Trend.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid border;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\..\..\..\..\Main\Regions\Dialog\Protocol\Views\Protocol_Trend.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.TextBlock HeaderText;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\..\..\..\Main\Regions\Dialog\Protocol\Views\Protocol_Trend.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.Button CancelButton;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\..\..\..\Main\Regions\Dialog\Protocol\Views\Protocol_Trend.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.CartesianChart chart;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\..\..\..\..\Main\Regions\Dialog\Protocol\Views\Protocol_Trend.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.Axis labels;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\..\..\..\..\Main\Regions\Dialog\Protocol\Views\Protocol_Trend.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.Axis oy;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\..\..\..\..\Main\Regions\Dialog\Protocol\Views\Protocol_Trend.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.Separator oySeparator;
        
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
            System.Uri resourceLocater = new System.Uri("/251252-Raymond-1;component/main/regions/dialog/protocol/views/protocol_trend.xam" +
                    "l", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\..\Main\Regions\Dialog\Protocol\Views\Protocol_Trend.xaml"
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
            this.border = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.HeaderText = ((VisiWin.Controls.TextBlock)(target));
            return;
            case 3:
            this.CancelButton = ((VisiWin.Controls.Button)(target));
            return;
            case 4:
            this.chart = ((LiveCharts.Wpf.CartesianChart)(target));
            return;
            case 5:
            this.labels = ((LiveCharts.Wpf.Axis)(target));
            return;
            case 6:
            this.oy = ((LiveCharts.Wpf.Axis)(target));
            return;
            case 7:
            this.oySeparator = ((LiveCharts.Wpf.Separator)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

