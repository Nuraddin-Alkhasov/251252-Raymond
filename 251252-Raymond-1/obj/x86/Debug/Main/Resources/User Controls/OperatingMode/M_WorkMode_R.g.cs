﻿#pragma checksum "..\..\..\..\..\..\..\Main\Resources\User Controls\OperatingMode\M_WorkMode_R.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "72B3401CEDFEE66C78F9A028A3D7C5660FDC978B4130980334E7446C63B7256C"
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


namespace HMI.Resources.UserControls.MO {
    
    
    /// <summary>
    /// M_WorkMode_R
    /// </summary>
    public partial class M_WorkMode_R : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\..\..\..\..\Main\Resources\User Controls\OperatingMode\M_WorkMode_R.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox H;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\..\..\..\Main\Resources\User Controls\OperatingMode\M_WorkMode_R.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.Key WorkingMode;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\..\..\..\Main\Resources\User Controls\OperatingMode\M_WorkMode_R.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.Key btnstart;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\..\..\..\Main\Resources\User Controls\OperatingMode\M_WorkMode_R.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.Key btnstop;
        
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
            System.Uri resourceLocater = new System.Uri("/251252-Raymond-1;component/main/resources/user%20controls/operatingmode/m_workmo" +
                    "de_r.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\Main\Resources\User Controls\OperatingMode\M_WorkMode_R.xaml"
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
            this.H = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 2:
            this.WorkingMode = ((VisiWin.Controls.Key)(target));
            
            #line 15 "..\..\..\..\..\..\..\Main\Resources\User Controls\OperatingMode\M_WorkMode_R.xaml"
            this.WorkingMode.Click += new System.Windows.RoutedEventHandler(this.WorkingMode_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnstart = ((VisiWin.Controls.Key)(target));
            return;
            case 4:
            this.btnstop = ((VisiWin.Controls.Key)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

