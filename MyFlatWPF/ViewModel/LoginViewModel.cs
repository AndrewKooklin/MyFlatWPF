using MyFlatWPF.Commands;
using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyFlatWPF.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private APIAccountRepository _api = new APIAccountRepository();
        private List<string> userRoles = new List<string>();

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Execute, CanExecute);
        }

        public ICommand LoginCommand { get; set; }

        private bool CanExecute(object param)
        {
            if (param == null)
            {
                return false;
            }
            var values = (object[])param;
            TextBox tbEmail = (TextBox)values[0];
            string tbEmailValue = tbEmail.Text;
            PasswordBox passwordBox = (PasswordBox)values[1];
            string passwordValue = passwordBox.Password;
            Label lErrorEmailBox = (Label)values[2];
            Label lErrorPasswordBox = (Label)values[3];
            Label lErrorLogIn = (Label)values[4];

            if (String.IsNullOrEmpty(tbEmailValue))
            {
                lErrorEmailBox.Content = "Fill field \"EMail\"";
                return false;
            }
            else if (!String.IsNullOrEmpty(tbEmailValue))
            {
                lErrorEmailBox.Content = "";
                try
                {
                    var mailAddress = new MailAddress(tbEmailValue);
                }
                catch
                {
                    lErrorPasswordBox.Content = "View format name@site.com!";
                    return false;
                }
                lErrorPasswordBox.Content = "";
            }
            if (String.IsNullOrEmpty(passwordValue) || passwordValue.Length < 6)
            {
                lErrorPasswordBox.Content = "At least 6 characters !";
                lErrorLogIn.Content = "";
                return false;
            }
            else
            {
                lErrorEmailBox.Content = "";
                lErrorPasswordBox.Content = "";
                lErrorLogIn.Content = "";
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
            string tbEmailValue = tbEmail.Text;
            PasswordBox passwordBox = (PasswordBox)values[1];
            string passwordValue = passwordBox.Password;
            Label lErrorLogIn = (Label)values[4];

            LoginModel model = new LoginModel
            {
                Email = tbEmailValue,
                Password = passwordValue
            };

            bool userExist = await _api.CheckUserToDB(model);
            if (!userExist)
            {
                tbEmail.Text = "";
                passwordBox.Password = "";

                lErrorLogIn.Content = "User not found, check login" +
                                      "\nand password or register.";
            }
            else
            {
                tbEmail.Text = "";
                passwordBox.Password = "";
                lErrorLogIn.Content = "";
                string[] email = model.Email.Split('@');
                string userName = email[0];
                App.MainWindow.lUserName.Content = userName;
                App.MainWindow.btnLogIn.Visibility = System.Windows.Visibility.Collapsed;
                App.MainWindow.btnRegister.Visibility = System.Windows.Visibility.Collapsed;
                App.MainWindow.lUserName.Visibility = System.Windows.Visibility.Visible;
                App.MainWindow.btnLogOut.Visibility = System.Windows.Visibility.Visible;
                App.LoginView.btnLogin.IsEnabled = false;
                App.RegistrationView.btnRegistration.IsEnabled = false;

                userRoles = await _api.GetUserRoles(model);
                if (userRoles != null && userRoles.Contains("Admin"))
                {
                    App.MainWindow.btnManagement.Visibility = System.Windows.Visibility.Visible;
                }
            }
        }

        
    }
}
