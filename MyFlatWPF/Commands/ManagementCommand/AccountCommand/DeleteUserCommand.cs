using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.View.ManagementView.UsersView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.AccountCommand
{
    public class DeleteUserCommand : ICommand
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
                bool result = await _api.DeleteUser(id);
                if (result)
                {
                    App.AllUsersView = null;
                    App.AllUsersView = new AllUsersView();
                    App.AllUsersView.Visibility = System.Windows.Visibility.Visible;
                    StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                        App.AllUsersView;
                }
            }
        }
    }
}
