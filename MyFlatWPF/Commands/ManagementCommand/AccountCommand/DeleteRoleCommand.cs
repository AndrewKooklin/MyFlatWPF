using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.View.ManagementView.RolesView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.AccountCommand
{
    public class DeleteRoleCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
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
                string id = parameter.ToString();
                bool result = await _api.DeleteRole(id);
                if (result)
                {
                    App.AllRolesView = null;
                    App.AllRolesView = new AllRolesView();
                    App.AllUsersView.Visibility = System.Windows.Visibility.Visible;
                    StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                        App.AllRolesView;
                }
            }
        }
    }
}
