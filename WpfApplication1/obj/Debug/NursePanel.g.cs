﻿#pragma checksum "..\..\NursePanel.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7DC7DFAFCC6D17D20D11D5192A2AC3B5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HMS;
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


namespace HMS {
    
    
    /// <summary>
    /// NursePanel
    /// </summary>
    public partial class NursePanel : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\NursePanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuLogout;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\NursePanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuAbout;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\NursePanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch_Room;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\NursePanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label4;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\NursePanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboSearch_Rooms;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\NursePanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid_Rooms;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\NursePanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch_Patient;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\NursePanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label4_Copy;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\NursePanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboSearch_Patient;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\NursePanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid_Patients;
        
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
            System.Uri resourceLocater = new System.Uri("/HMS;component/nursepanel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NursePanel.xaml"
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
            
            #line 8 "..\..\NursePanel.xaml"
            ((HMS.NursePanel)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.menuLogout = ((System.Windows.Controls.MenuItem)(target));
            
            #line 14 "..\..\NursePanel.xaml"
            this.menuLogout.Click += new System.Windows.RoutedEventHandler(this.menuLogout_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.menuAbout = ((System.Windows.Controls.MenuItem)(target));
            
            #line 15 "..\..\NursePanel.xaml"
            this.menuAbout.Click += new System.Windows.RoutedEventHandler(this.menuAbout_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtSearch_Room = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\NursePanel.xaml"
            this.txtSearch_Room.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtSearch_Room_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.label4 = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.cboSearch_Rooms = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.dataGrid_Rooms = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.txtSearch_Patient = ((System.Windows.Controls.TextBox)(target));
            
            #line 57 "..\..\NursePanel.xaml"
            this.txtSearch_Patient.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtSearch_Patient_TextChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.label4_Copy = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.cboSearch_Patient = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.dataGrid_Patients = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
