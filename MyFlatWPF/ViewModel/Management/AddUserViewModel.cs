﻿using MyFlatWPF.Commands;
using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.Model;
using MyFlatWPF.Model.AccountModel;
using MyFlatWPF.View.ManagementView.UsersView;
using System;
using System.Net.Mail;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyFlatWPF.ViewModel.Management
{
    public class AddUserViewModel : BaseViewModel
    {
        private APIAccountRepository _api = new APIAccountRepository();

        public AddUserViewModel()
        {
            RegisterCommand = new RelayCommand(Execute, CanExecute);
        }

        public ICommand RegisterCommand { get; set; }

        private bool CanExecute(object param)
        {
            if (param == null)
            {
                return false;
            }
            var values = (object[])param;
            TextBox tbEmail = (TextBox)values[0];
            TextBox passwordBox = (TextBox)values[1];
            TextBox confirmPasswordBox = (TextBox)values[2];
            Label lErrorEMail = (Label)values[3];
            Label lErrorPassword = (Label)values[4];
            Label lErrorConfirmPassword = (Label)values[5];
            Label lResultRegistration = (Label)values[6];

            if (String.IsNullOrEmpty(tbEmail.Text))
            {
                lErrorEMail.Content = "Fill field \"EMail!\"";
                return false;
            }
            else if (!String.IsNullOrEmpty(tbEmail.Text))
            {
                try
                {
                    var mailAddress = new MailAddress(tbEmail.Text);
                }
                catch
                {
                    lErrorEMail.Content = "View format name@site.com!";
                    return false;
                }
                lErrorEMail.Content = "";
            }

            if (String.IsNullOrEmpty(passwordBox.Text) || passwordBox.Text.Length < 6)
            {
                lErrorPassword.Content = "At least 6 characters !";
                return false;
            }
            else
            {
                lErrorPassword.Content = "";
            }

            if (!passwordBox.Text.Equals(confirmPasswordBox.Text))
            {
                lErrorConfirmPassword.Content = "Passwords don't match!";
                return false;
            }
            else
            {
                lResultRegistration.Content = "";
                lErrorConfirmPassword.Content = "";
                return true;
            }
        }

        private async void Execute(object param)
        {
            if (param == null)
            {
                return;
            }
            var values = (object[])param;
            TextBox tbEmail = (TextBox)values[0];
            TextBox passwordBox = (TextBox)values[1];
            TextBox confirmPasswordBox = (TextBox)values[2];
            Label lErrorEMail = (Label)values[3];
            Label lErrorPassword = (Label)values[4];
            Label lErrorConfirmPassword = (Label)values[5];
            Label lResultRegistration = (Label)values[6];

            RegisterModel model = new RegisterModel
            {
                Email = tbEmail.Text,
                Password = passwordBox.Text
            };

            AddUserModel addUserModel = new AddUserModel
            {
                Email = tbEmail.Text,
                Password = passwordBox.Text
            };

            LoginModel loginModel = new LoginModel
            {
                Email = tbEmail.Text,
                Password = passwordBox.Text
            };
            bool checkUser = await _api.CheckUserToDB(loginModel);
            if (checkUser)
            {
                tbEmail.Text = "";
                passwordBox.Text = "";
                confirmPasswordBox.Text = "";
                lResultRegistration.Content = "User already exists!" +
                                              "\nLogin with email and password";
                return;
            }
            else
            {
                bool result = await _api.AddNewUser(addUserModel);
                if (result)
                {
                    tbEmail.Text = "";
                    passwordBox.Text = "";
                    lResultRegistration.Content = "New user added.";
                    App.AllUsersView = null;
                    App.AllUsersView = new AllUsersView();
                    App.AllUsersView.Visibility = System.Windows.Visibility.Visible;
                    StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                        App.AllUsersView;
                }
                else
                {
                    lResultRegistration.Content = "Server error !";
                }
            }
        }
    }
}
