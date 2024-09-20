using MyFlatWPF.Commands;
using MyFlatWPF.HelpMethods;
using MyFlatWPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyFlatWPF.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {

        public HomeViewModel()
        {
            SendOrderFormCommand = new RelayCommand(Execute, CanExecute); 

        }

        public ICommand SendOrderFormCommand { get; set; }

        private string _errorNameInput = "";
        public string ErrorNameInput
        {
            get
            {
                return _errorNameInput;
            }
            set
            {
                _errorNameInput = value;
                OnPropertyChanged(nameof(ErrorNameInput));
            }
        }

        private string _nameInput = "";
        public string NameInput
        {
            get
            {
                return _nameInput;
            }
            set
            {
                _nameInput = value;
                OnPropertyChanged(nameof(NameInput));
            }
        }

        private string _errorEmailInput = "";
        public string ErrorEmailInput
        {
            get
            {
                return _errorEmailInput;
            }
            set
            {
                _errorEmailInput = value;
                OnPropertyChanged(nameof(ErrorEmailInput));
            }
        }

        private string _errorMobileInput = "";
        public string ErrorMobileInput
        {
            get
            {
                return _errorMobileInput;
            }
            set
            {
                _errorMobileInput = value;
                OnPropertyChanged(nameof(ErrorMobileInput));
            }
        }

        private string _errorServiceChoose = "";
        public string ErrorServiceChoose
        {
            get
            {
                return _errorServiceChoose;
            }
            set
            {
                _errorServiceChoose = value;
                OnPropertyChanged(nameof(ErrorServiceChoose));
            }
        }

        private string _errorMessageInput = "";
        public string ErrorMessageInput
        {
            get
            {
                return _errorMessageInput;
            }
            set
            {
                _errorMessageInput = value;
                OnPropertyChanged(nameof(ErrorMessageInput));
            }
        }

        private string _resultSendForm = "";
        public string ResultSendForm
        {
            get
            {
                return _resultSendForm;
            }
            set
            {
                _resultSendForm = value;
                OnPropertyChanged(nameof(ResultSendForm));
            }
        }

        CheckInputFields checkInput = new CheckInputFields();

        private bool CanExecute(object parameter)
        {
            if (parameter == null)
            {
                return false;
            }

            HomeView homeView = App.HomeWiew;

            var fieldElements = (object[])parameter;
            string name = NameInput;
            //if (String.IsNullOrEmpty(name))
            //{
            //    App.HomeWiew.tbNameError.Text = "Fill field \"Your Name\"";
            //    return false;
            //}
            if (name.Length < 3)
            {
                ErrorNameInput = "At least 3 characters";
                return false;
            }
            else
            {
                ErrorNameInput = "";
            }
            string email = fieldElements[1].ToString();
            string mobile = fieldElements[2].ToString();
            //ComboBox cbox = new ComboBox();
            //cbox = (ComboBox)fieldElements[3];
            //ComboBoxItem cbItem = (ComboBoxItem)cbox.SelectedItem;
            //if(cbItem == null)
            //{
            //    return false;
            //}
            if(App.HomeWiew.cbiService.Content == null)
            {
                return false;
            }
            string serviceName = App.HomeWiew.cbiService.Content.ToString();
            if (String.IsNullOrEmpty(serviceName))
            {
                return false;
            }

            string message = fieldElements[4].ToString();

            

            

            if (String.IsNullOrEmpty(email))
            {
                homeView.tbEmailError.Text = "Fill field \"Your Email\"";
                return false;
            }
            if (!CheckEmail(email))
            {
                homeView.tbEmailError.Text = "Email field format name@site.com";
                return false;
            }

            if (String.IsNullOrEmpty(mobile))
            {
                homeView.tbMobileError.Text = "Fill field \"Your Mobile\"";
                return false;
            }
            if (!CheckPhone(mobile))
            {
                homeView.tbMobileError.Text = "Field must contain 11 digits";
                return false;
            }

            if (String.IsNullOrEmpty(serviceName))
            {
                homeView.tbServiceError.Text = "Choose service";
                return false;
            }

            if (String.IsNullOrEmpty(message))
            {
                homeView.tbMessageError.Text = "Fill field \"Your Message\"";
                return false;
            }
            if (message.Length < 5)
            {
                homeView.tbMessageError.Text = "Length of at least 5 characters.";
                return false;
            }
            else
            {
                homeView.tbNameError.Text = "";
                homeView.tbEmailError.Text = "";
                homeView.tbMobileError.Text = "";
                homeView.tbServiceError.Text = "";
                homeView.tbMessageError.Text = "";
                return true;
            }
        }

        private void Execute(object param)
        {

        }

        private bool CheckEmail(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
                bool result = mail.Address == email;
                if (result)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }

            return false;
        }

        private bool CheckPhone(string phoneNumber)
        {
            string expr = @"^\d{11}$";
            if (Regex.IsMatch(phoneNumber, expr))
            {
                return true;
            }
            else return false;
        }
    }


}
