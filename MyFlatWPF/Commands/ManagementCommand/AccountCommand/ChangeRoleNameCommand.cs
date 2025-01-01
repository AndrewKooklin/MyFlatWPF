using Microsoft.AspNet.Identity.EntityFramework;
using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.View.ManagementView.RolesView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.AccountCommand
{
    public class ChangeRoleNameCommand : ICommand
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
                string id = parameter.ToString();
                IdentityRole _role = new IdentityRole();
                _role.Id = id;
                _role.Name = App.RoleEditView.tbRoleName.Text;
                bool result = await _api.ChangeRoleName(_role);
                if (result)
                {
                    App.AllRolesView = null;
                    App.AllRolesView = new AllRolesView();
                    App.AllRolesView.Visibility = System.Windows.Visibility.Visible;
                    StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                        App.AllRolesView;
                }
                else
                {
                    App.RoleEditView.lErrorRoleName.Content = "Server error!";
                }
            }
        }
    }
}
