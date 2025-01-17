using Microsoft.AspNet.Identity.EntityFramework;
using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.View.ManagementView.RolesView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.AccountCommand
{
    public class AddRoleCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        List<string> _roleNames = new List<string>();
        APIAccountRepository _api = new APIAccountRepository();

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            if (parameter == null)
            {
                return;
            }
            else
            {
                var values = (object[])parameter;
                TextBox tbRoleName = (TextBox)values[0];
                Label lErrorRoleNAme = (Label)values[1];
                if (String.IsNullOrEmpty(tbRoleName.Text) || tbRoleName.Text.Length < 3)
                {
                    lErrorRoleNAme.Content = "At least 3 characters!";
                    return;
                }
                _roleNames = _api.GetRoleNames();
                if(_roleNames.Contains(tbRoleName.Text))
                {
                    lErrorRoleNAme.Content = "Role already exists!";
                    return;
                }
                IdentityRole role = new IdentityRole() 
                { 
                    Name = tbRoleName.Text
                };
                bool result = await _api.CreateRole(role);
                if (result)
                {
                    tbRoleName.Text = "";
                    lErrorRoleNAme.Content = "";
                    App.AllRolesView = null;
                    App.AllRolesView = new AllRolesView();
                    App.AllUsersView.Visibility = System.Windows.Visibility.Visible;
                    StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                        App.AllRolesView;
                }
                else
                {
                    lErrorRoleNAme.Content = "Server error.";
                }
            }
        }
    }
}
