using MyFlatWPF.View.ManagementView.UsersView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.AccountCommand
{
    public class BackToListUsersCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            App.AllUsersView = null;
            App.AllUsersView = new AllUsersView();
            App.AllUsersView.Visibility = System.Windows.Visibility.Visible;
            StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                App.AllUsersView;
        }
    }
}
