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
    public class OpenChangeRoleCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter == null)
            {
                return;
            }
            else
            {
                string id = parameter.ToString();

                App.RoleEditView = null;
                App.RoleEditView = new RoleEditView();
                RoleEditViewModel uevm =
                    new RoleEditViewModel(id,
                                          App.RoleEditView.tbRoleName,
                                          App.RoleEditView.lErrorRoleName,
                                          App.RoleEditView.btnChangeRoleName);
                App.RoleEditView.Visibility = System.Windows.Visibility.Visible;
                StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                    App.RoleEditView;
            }
        }
    }
}
