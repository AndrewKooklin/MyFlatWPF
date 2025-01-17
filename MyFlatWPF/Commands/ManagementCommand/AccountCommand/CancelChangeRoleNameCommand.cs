using MyFlatWPF.View.ManagementView.RolesView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.AccountCommand
{
    public class CancelChangeRoleNameCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            App.AllRolesView = null;
            App.AllRolesView = new AllRolesView();
            App.AllRolesView.Visibility = System.Windows.Visibility.Visible;
            StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                App.AllRolesView;
        }
    }
}
