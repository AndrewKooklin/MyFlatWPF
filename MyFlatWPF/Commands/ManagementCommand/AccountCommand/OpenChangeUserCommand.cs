using MyFlatWPF.View.ManagementView.UsersView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.AccountCommand
{
    public class OpenChangeUserCommand : ICommand
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
            }
        }
    }
}
