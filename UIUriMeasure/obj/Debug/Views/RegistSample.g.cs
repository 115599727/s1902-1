﻿#pragma checksum "..\..\..\Views\RegistSample.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6F09C2515D871D1676D88E1DB336F51A62319B708EC7BEF3246AEE6602945503"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using C1.Silverlight.Resources;
using C1.WPF;
using C1.WPF.DateTimeEditors;
using C1.WPF.FlexGrid;
using C1.WPF.InputPanel;
using C1.WPF.Toolbar;
using Prism.Interactivity;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Regions.Behaviors;
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
using UIUriMeasure.Views;


namespace UIUriMeasure.Views {
    
    
    /// <summary>
    /// RegistSample
    /// </summary>
    public partial class RegistSample : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\Views\RegistSample.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal C1.WPF.Toolbar.C1Toolbar toolBar;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Views\RegistSample.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ckbSelectAll;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Views\RegistSample.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal C1.WPF.FlexGrid.C1FlexGrid flexGrid;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Views\RegistSample.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal C1.WPF.C1MaskedTextBox mskTSampleNo;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\Views\RegistSample.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdbTypeC;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Views\RegistSample.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdbTypeM;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\Views\RegistSample.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdbTypeCM;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Views\RegistSample.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxDilution;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\Views\RegistSample.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal C1.WPF.C1MaskedTextBox mskTTubeNo;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\Views\RegistSample.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal C1.WPF.C1MaskedTextBox mskTShelfNo;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\Views\RegistSample.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgPatient;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\Views\RegistSample.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPatienName;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\Views\RegistSample.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdbSexM;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\Views\RegistSample.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdbSexF;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\Views\RegistSample.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal C1.WPF.C1NumericBox nmbPatientAge;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\Views\RegistSample.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal C1.WPF.C1ComboBox cobAgeType;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\Views\RegistSample.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal C1.WPF.C1ComboBox cobPatientNation;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\Views\RegistSample.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal C1.WPF.C1ComboBox cobPatientType;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\Views\RegistSample.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal C1.WPF.C1ComboBox cobChargeTypes;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\Views\RegistSample.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal C1.WPF.DateTimeEditors.C1DatePicker cdpCollectTime;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\..\Views\RegistSample.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal C1.WPF.DateTimeEditors.C1DatePicker cdpSendDate;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\..\Views\RegistSample.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal C1.WPF.DateTimeEditors.C1DatePicker cdpRegistDate;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\..\Views\RegistSample.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboSent;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\Views\RegistSample.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRegistSample;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\..\Views\RegistSample.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
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
            System.Uri resourceLocater = new System.Uri("/UIUriMeasure;component/views/registsample.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\RegistSample.xaml"
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
            
            #line 11 "..\..\..\Views\RegistSample.xaml"
            ((UIUriMeasure.Views.RegistSample)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.toolBar = ((C1.WPF.Toolbar.C1Toolbar)(target));
            return;
            case 3:
            this.ckbSelectAll = ((System.Windows.Controls.CheckBox)(target));
            
            #line 35 "..\..\..\Views\RegistSample.xaml"
            this.ckbSelectAll.Click += new System.Windows.RoutedEventHandler(this.CkbSelectAll_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.flexGrid = ((C1.WPF.FlexGrid.C1FlexGrid)(target));
            
            #line 45 "..\..\..\Views\RegistSample.xaml"
            this.flexGrid.SelectedItemChanged += new System.EventHandler(this.FlexGrid_SelectedItemChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.mskTSampleNo = ((C1.WPF.C1MaskedTextBox)(target));
            return;
            case 6:
            this.rdbTypeC = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.rdbTypeM = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 8:
            this.rdbTypeCM = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 9:
            this.cbxDilution = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.mskTTubeNo = ((C1.WPF.C1MaskedTextBox)(target));
            return;
            case 11:
            this.mskTShelfNo = ((C1.WPF.C1MaskedTextBox)(target));
            return;
            case 12:
            this.imgPatient = ((System.Windows.Controls.Image)(target));
            return;
            case 13:
            this.txtPatienName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 14:
            this.rdbSexM = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 15:
            this.rdbSexF = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 16:
            this.nmbPatientAge = ((C1.WPF.C1NumericBox)(target));
            return;
            case 17:
            this.cobAgeType = ((C1.WPF.C1ComboBox)(target));
            return;
            case 18:
            this.cobPatientNation = ((C1.WPF.C1ComboBox)(target));
            return;
            case 19:
            this.cobPatientType = ((C1.WPF.C1ComboBox)(target));
            return;
            case 20:
            this.cobChargeTypes = ((C1.WPF.C1ComboBox)(target));
            return;
            case 21:
            this.cdpCollectTime = ((C1.WPF.DateTimeEditors.C1DatePicker)(target));
            return;
            case 22:
            this.cdpSendDate = ((C1.WPF.DateTimeEditors.C1DatePicker)(target));
            return;
            case 23:
            this.cdpRegistDate = ((C1.WPF.DateTimeEditors.C1DatePicker)(target));
            return;
            case 24:
            this.cboSent = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 25:
            this.btnRegistSample = ((System.Windows.Controls.Button)(target));
            
            #line 147 "..\..\..\Views\RegistSample.xaml"
            this.btnRegistSample.Click += new System.Windows.RoutedEventHandler(this.BtnRegistSample_Click);
            
            #line default
            #line hidden
            return;
            case 26:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 148 "..\..\..\Views\RegistSample.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.BtnSave_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

