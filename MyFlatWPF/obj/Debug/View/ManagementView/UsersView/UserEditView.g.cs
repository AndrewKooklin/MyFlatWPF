﻿#pragma checksum "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EE1E04B8D7E06885D7623CE7E407C8CEA102CF5B6C6050C37172B4AD848D80F3"
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
        
        
        #line 148 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblEditUser;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblUserNameHeader;
        
        #line default
        #line hidden
        
        
        #line 166 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblEmailHeader;
        
        #line default
        #line hidden
        
        
        #line 175 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblRolesHeader;
        
        #line default
        #line hidden
        
        
        #line 187 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblUserName;
        
        #line default
        #line hidden
        
        
        #line 197 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblEmail;
        
        #line default
        #line hidden
        
        
        #line 208 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblRoles;
        
        #line default
        #line hidden
        
        
        #line 219 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border bRoles;
        
        #line default
        #line hidden
        
        
        #line 229 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbRoles;
        
        #line default
        #line hidden
        
        
        #line 239 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddRole;
        
        #line default
        #line hidden
        
        
        #line 254 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteRole;
        
        #line default
        #line hidden
        
        
        #line 269 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblMessage;
        
        #line default
        #line hidden
        
        
        #line 278 "..\..\..\..\..\View\ManagementView\UsersView\UserEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBackToUsers;
        
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
            this.tblUserName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.tblEmail = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.tblRoles = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.bRoles = ((System.Windows.Controls.Border)(target));
            return;
            case 10:
            this.cbRoles = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.btnAddRole = ((System.Windows.Controls.Button)(target));
            return;
            case 12:
            this.btnDeleteRole = ((System.Windows.Controls.Button)(target));
            return;
            case 13:
            this.tblMessage = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 14:
            this.btnBackToUsers = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

