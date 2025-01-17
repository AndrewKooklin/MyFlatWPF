using MyFlatWPF.ViewModel.Management;
using System;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.AccountCommand
{
    public class OpenAddUserCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            App.AddUserView.Visibility = System.Windows.Visibility.Visible;
            StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                App.AddUserView;
        }
    }
}
