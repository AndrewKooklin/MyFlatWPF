﻿#pragma checksum "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "05EB41FD544EB907B51640408110DC8179C98C80C81CDD499CF11A997B292985"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MyFlatWPF.HelpMethods;
using MyFlatWPF.View.ManagementView.UsersView;
using MyFlatWPF.ViewModel.Management;
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


namespace MyFlatWPF.View.ManagementView.UsersView {
    
    
    /// <summary>
    /// UserEditView
    /// </summary>
    public partial class UserEditView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gUserEdit;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblEditUser;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblUserNameHeader;
        
        #line default
        #line hidden
        
        
        #line 165 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblEmailHeader;
        
        #line default
        #line hidden
        
        
        #line 174 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblRolesHeader;
        
        #line default
        #line hidden
        
        
        #line 186 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblId;
        
        #line default
        #line hidden
        
        
        #line 191 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblUserName;
        
        #line default
        #line hidden
        
        
        #line 200 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblEmail;
        
        #line default
        #line hidden
        
        
        #line 210 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblRoles;
        
        #line default
        #line hidden
        
        
        #line 220 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border bRoles;
        
        #line default
        #line hidden
        
        
        #line 230 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbRoles;
        
        #line default
        #line hidden
        
        
        #line 240 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddRole;
        
        #line default
        #line hidden
        
        
        #line 256 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteRole;
        
        #line default
        #line hidden
        
        
        #line 272 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblMessage;
        
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
            System.Uri resourceLocater = new System.Uri("/MyFlatWPF;component/view/managementview/usersview/usereditview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
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
            this.gUserEdit = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.tblEditUser = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.tblUserNameHeader = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.tblEmailHeader = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.tblRolesHeader = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.tblId = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.tblUserName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.tblEmail = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.tblRoles = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.bRoles = ((System.Windows.Controls.Border)(target));
            return;
            case 11:
            this.cbRoles = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 12:
            this.btnAddRole = ((System.Windows.Controls.Button)(target));
            return;
            case 13:
            this.btnDeleteRole = ((System.Windows.Controls.Button)(target));
            return;
            case 14:
            this.tblMessage = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

