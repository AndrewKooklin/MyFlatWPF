﻿using MyFlatWPF.View.ManagementView.UsersView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                int id = (Int32)parameter;

                App.UserEditView = null;
                App.UserEditView = new UserEditView();
                UserEditViewModel pevm =
                    new UserEditViewModel(App.UserEditView.lbRoles,
                                          App.UserEditView.btnAddRole,
                                          App.UserEditView.btnDeleteRole,
                                          App.UserEditView.btnBackToUsers,
                                          id);

                App.UserEditView.Visibility = System.Windows.Visibility.Visible;
                StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                    App.UserEditView;
            }
        }
    }
}
