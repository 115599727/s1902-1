﻿#pragma checksum "..\..\..\Views\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "233E94CE4C155B39C9258C215DE81CF221DFAD3946BE1201AA93616C2C437875"
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
using C1.WPF.Theming;
using C1.WPF.Theming.BureauBlack;
using C1.WPF.Theming.C1Blue;
using C1.WPF.Theming.Cosmopolitan;
using C1.WPF.Theming.CosmopolitanDark;
using C1.WPF.Theming.ExpressionDark;
using C1.WPF.Theming.ExpressionLight;
using C1.WPF.Theming.Office2007;
using C1.WPF.Theming.Office2010;
using C1.WPF.Theming.Office2013;
using C1.WPF.Theming.Office2016;
using C1.WPF.Theming.Ribbon;
using C1.WPF.Theming.ShinyBlue;
using C1.WPF.Theming.WhistlerBlue;
using C1.WPF.Toolbar;
using MahApps.Metro.Controls;
using MahApps.Metro.IconPacks;
using Prism.Interactivity;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Regions.Behaviors;
using Prism.Unity;
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
using WpfApp1Metro;


namespace WpfApp1Metro.Views {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal C1.WPF.C1ComboBox cmbTheme;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Ribbon.Ribbon ribbon;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Ribbon.RibbonApplicationMenuItem CmdExit;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Ribbon.RibbonGroup ribStatus;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Ribbon.RibbonGroup MenuGroup;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1Metro;component/views/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\MainWindow.xaml"
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
            this.cmbTheme = ((C1.WPF.C1ComboBox)(target));
            
            #line 30 "..\..\..\Views\MainWindow.xaml"
            this.cmbTheme.SelectedItemChanged += new System.EventHandler<C1.WPF.PropertyChangedEventArgs<object>>(this.CmbTheme_SelectedItemChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.ribbon = ((System.Windows.Controls.Ribbon.Ribbon)(target));
            return;
            case 4:
            this.CmdExit = ((System.Windows.Controls.Ribbon.RibbonApplicationMenuItem)(target));
            
            #line 63 "..\..\..\Views\MainWindow.xaml"
            this.CmdExit.Click += new System.Windows.RoutedEventHandler(this.CmdExit_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ribStatus = ((System.Windows.Controls.Ribbon.RibbonGroup)(target));
            return;
            case 6:
            this.MenuGroup = ((System.Windows.Controls.Ribbon.RibbonGroup)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
