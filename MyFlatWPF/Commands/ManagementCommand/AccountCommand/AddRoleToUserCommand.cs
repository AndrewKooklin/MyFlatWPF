using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.HelpMethods;
using MyFlatWPF.Model.AccountModel;
using MyFlatWPF.View.ManagementView.UsersView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.AccountCommand
{
    public class AddRoleToUserCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        APIAccountRepository _api = new APIAccountRepository();

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            if(parameter == null)
            {
                return;
            }
            else
            {
                var fieldElements = (object[])parameter;
                UserWithRolesModel uvrm = StaticUser.UserTemp;
                string id = uvrm.User.Id;
                ComboBox cbRoles = (ComboBox)fieldElements[0];
                TextBlock tblMessage = (TextBlock)fieldElements[1];
                
                if (cbRoles.SelectedIndex == -1)
                {
                    tblMessage.Text = "Select role!";
                    return;
                }
                string role = cbRoles.SelectedItem.ToString();
                if (uvrm.Roles.Contains(role))
                {
                    tblMessage.Text = "The User already has a role!";
                    return;
                }
                else
                {
                    tblMessage.Text = "";
                }
                RoleUserModel rum = new RoleUserModel();
                rum.UserId = id;
                rum.Role = role;
                bool result = await _api.AddRoleToUser(rum);
                if (result)
                {
                    App.UserEditView = null;
                    App.UserEditView = new UserEditView();
                    UserEditViewModel uevm =
                        new UserEditViewModel(id,
                                              App.UserEditView.cbRoles,
                                              App.UserEditView.tblUserName,
                                              App.UserEditView.tblEmail,
                                              App.UserEditView.tblRoles,
                                              App.UserEditView.btnAddRole,
                                              App.UserEditView.btnDeleteRole,
                                              App.UserEditView.tblMessage,
                                              App.UserEditView.btnBackToUsers);
                    App.UserEditView.Visibility = System.Windows.Visibility.Visible;
                    StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                        App.UserEditView;
                    tblMessage.Text = "Role added!";
                }
                else
                {
                    tblMessage.Text = "Server error!";
                }
            }
        }
    }
}
