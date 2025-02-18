﻿using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.ViewModel;
using System;
using System.Windows.Input;

namespace MyFlatWPF.Commands
{
    public class LogoutCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private APIAccountRepository _api = new APIAccountRepository();

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            App.MainWindow.btnManagement.Visibility = System.Windows.Visibility.Collapsed;
            App.MainWindow.btnLogOut.Visibility = System.Windows.Visibility.Collapsed;
            App.MainWindow.lUserName.Content = null;
            App.MainWindow.lUserName.Visibility = System.Windows.Visibility.Collapsed;
            App.MainWindow.btnLogIn.Visibility = System.Windows.Visibility.Visible;
            App.MainWindow.btnRegister.Visibility = System.Windows.Visibility.Visible;
            App.LoginView.btnLogin.IsEnabled = true;
            App.RegistrationView.btnRegistration.IsEnabled = true;
            App.RegistrationView.lResultRegistration.Content = "";

            _api.LogoutUser();

            StaticViewModel.MainViewModel.RandomPhrase =
                                StaticViewModel.MainViewModel.GetHeaderString();
        }
    }
}
