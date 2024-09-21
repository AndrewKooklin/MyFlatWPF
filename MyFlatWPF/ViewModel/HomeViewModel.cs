using MyFlatWPF.Commands;
using MyFlatWPF.HelpMethods;
using MyFlatWPF.Model;
using MyFlatWPF.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
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

        private string _emailInput = "";
        public string EmailInput
        {
            get
            {
                return _emailInput;
            }
            set
            {
                _emailInput = value;
                OnPropertyChanged(nameof(EmailInput));
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

        private string _mobileInput = "";
        public string MobileInput
        {
            get
            {
                return _mobileInput;
            }
            set
            {
                _mobileInput = value;
                OnPropertyChanged(nameof(MobileInput));
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

        private ComboBoxItem _serviceChooseItem;
        public ComboBoxItem ServiceChooseItem
        {
            get
            {
                return _serviceChooseItem;
            }
            set
            {
                _serviceChooseItem = value;
                OnPropertyChanged(nameof(ServiceChooseItem));
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

        private string _messageInput = "";
        public string MessageInput
        {
            get
            {
                return _messageInput;
            }
            set
            {
                _messageInput = value;
                OnPropertyChanged(nameof(MessageInput));
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

            //HomeView homeView = App.HomeWiew;

            //var fieldElements = (object[])parameter;
            string name = NameInput;
            if (String.IsNullOrEmpty(name))
            {
                ErrorNameInput = "Fill field \"Your Name\"";
                return false;
            }
            
            if (name.Length < 3)
            {
                ErrorNameInput = "At least 3 characters";
                return false;
            }
            else
            {
                ErrorNameInput = "";
            }

            string email = EmailInput;
            if (String.IsNullOrEmpty(email))
            {
                ErrorEmailInput = "Fill field \"Your Email\"";
                return false;
            }
            if (!CheckEmail(email))
            {
                ErrorEmailInput = "Email format name@site.com";
                return false;
            }
            else
            {
                ErrorEmailInput = "";
            }

            string mobile = MobileInput;
            if (String.IsNullOrEmpty(mobile))
            {
                ErrorMobileInput = "Fill field \"Your Mobile\"";
                return false;
            }
            if (!CheckPhone(mobile))
            {
                ErrorMobileInput = "Format 11 digits";
                return false;
            }
            else
            {
                ErrorMobileInput = "";
            }

            //ComboBox cbox = new ComboBox();
            //cbox = (ComboBox)fieldElements[3];
            //ComboBoxItem cbItem = (ComboBoxItem)cbox.SelectedItem;
            //if(cbItem == null)
            //{
            //    return false;
            //}
            if (ServiceChooseItem == null)
            {
                ErrorServiceChoose = "Choose service";
                return false;
            }
            else
            {
                ErrorServiceChoose = "";
            }
            


            string message = MessageInput;
            if (String.IsNullOrEmpty(message))
            {
                ErrorMessageInput = "Fill field \"Your Message\"";
                return false;
            }
            if (message.Length < 5)
            {
                ErrorMessageInput = "At least 5 characters.";
                return false;
            }
            else
            {
                ErrorNameInput = "";
                ErrorEmailInput = "";
                ErrorMobileInput = "";
                ErrorServiceChoose = "";
                ErrorMessageInput = "";
                return true;
            }
        }

        private HttpClient _httpClient;
        private string url = @"https://localhost:44388/";
        string urlRequest = "";
        HttpResponseMessage response;
        string result;
        bool apiResponseConvert;

        private void Execute(object param)
        {
            string name = NameInput;
            string email = EmailInput;
            string mobile = MobileInput;
            string serviceName = ServiceChooseItem.Content.ToString();
            string message = MessageInput;

            OrderModel order = new OrderModel();
            order.Name = name;
            order.Email = email;
            order.Mobile = mobile;
            order.ServiceName = serviceName;
            order.Message = message;
            var response = SaveOrder(order);
            if (!response.GetAwaiter().GetResult())
            {
                ResultSendForm = "API server error";
            }
            else
            {
                ResultSendForm = "Order succesfully accepted";
            }
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

        public async Task<bool> SaveOrder(OrderModel order)
        {
            urlRequest = $"{url}" + "OrdersAPI/SaveOrder/" + $"{order}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, order))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    apiResponseConvert = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }

            return apiResponseConvert;
        }
    }


}
