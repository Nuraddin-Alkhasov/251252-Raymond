﻿#pragma checksum "..\..\..\..\..\..\..\..\..\Main\Resources\User Controls\MO\Material\Baskets\PZWZBasket.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8801BFAD249DD0DBC3FE531EC66C37A3FA8A467C6CB6A4FDA15D325F09F52EF1"
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
    /// PZWZBasket
    /// </summary>
    public partial class PZWZBasket : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\..\..\..\..\..\..\Main\Resources\User Controls\MO\Material\Baskets\PZWZBasket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid A;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\..\..\..\..\..\..\Main\Resources\User Controls\MO\Material\Baskets\PZWZBasket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.PictureBox basket;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\..\..\..\..\..\Main\Resources\User Controls\MO\Material\Baskets\PZWZBasket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.NumericVarOut ismaterial;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\..\..\..\..\..\Main\Resources\User Controls\MO\Material\Baskets\PZWZBasket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border discharge;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\..\..\..\..\..\Main\Resources\User Controls\MO\Material\Baskets\PZWZBasket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border watch;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\..\..\..\..\..\Main\Resources\User Controls\MO\Material\Baskets\PZWZBasket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border check;
        
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
            System.Uri resourceLocater = new System.Uri("/251252-Raymond-1;component/main/resources/user%20controls/mo/material/baskets/pz" +
                    "wzbasket.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\..\..\Main\Resources\User Controls\MO\Material\Baskets\PZWZBasket.xaml"
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
            this.A = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.basket = ((VisiWin.Controls.PictureBox)(target));
            return;
            case 3:
            this.ismaterial = ((VisiWin.Controls.NumericVarOut)(target));
            return;
            case 4:
            this.discharge = ((System.Windows.Controls.Border)(target));
            return;
            case 5:
            this.watch = ((System.Windows.Controls.Border)(target));
            return;
            case 6:
            this.check = ((System.Windows.Controls.Border)(target));
            return;
            case 7:
            
            #line 29 "..\..\..\..\..\..\..\..\..\Main\Resources\User Controls\MO\Material\Baskets\PZWZBasket.xaml"
            ((VisiWin.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

