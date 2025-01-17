using MyFlatWPF.Commands;
using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.HelpMethods;
using MyFlatWPF.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MyFlatWPF.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        //private HttpClient _httpClient;
        //private string url = @"https://localhost:44388/";
        //string urlRequest = "";
        //HttpResponseMessage response;
        //string apiResponse;
        //public bool apiResponseConvert;
        private APIRenderingRepository _api = new APIRenderingRepository();
        private ImageConverter _ic = new ImageConverter();

        public HomeViewModel()
        {
            SendOrderFormCommand = new RelayCommand(Execute, CanExecute);

            if(HomePagePlaceholder == null)
            {
                HomePagePlaceholder = _api.GetHomePagePlaceholder();
            }

            ServiceItems = CreateBoxItems();

            BlocksAssignText();

            StaticViewModel.HomeViewModel = this;
        }

        public ICommand SendOrderFormCommand { get; set; }

        public HomePagePlaceholderModel HomePagePlaceholder { get; set; }

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
                ServerError = "";
                OrderSaved = "";
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
                ServerError = "";
                OrderSaved = "";
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
                ServerError = "";
                OrderSaved = "";
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

        private List<ComboBoxItem> _serviceItems;
        public List<ComboBoxItem> ServiceItems
        {
            get
            {
                return _serviceItems;
            }
            set
            {
                _serviceItems = value;
                OnPropertyChanged(nameof(ServiceItems));
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
                ServerError = "";
                OrderSaved = "";
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
                ServerError = "";
                OrderSaved = "";
                OnPropertyChanged(nameof(MessageInput));
            }
        }

        private string _serverError = "";
        public string ServerError
        {
            get
            {
                return _serverError;
            }
            set
            {
                _serverError = value;
                OnPropertyChanged(nameof(ServerError));
            }
        }

        private string _orderSaved = "";
        public string OrderSaved
        {
            get
            {
                return _orderSaved;
            }
            set
            {
                _orderSaved = value;
                OnPropertyChanged(nameof(OrderSaved));
            }
        }

        private string _leftCentralAreaText;
        public string LeftCentralAreaText
        {
            get
            {
                return _leftCentralAreaText;
            }
            set
            {
                _leftCentralAreaText = value;
                OnPropertyChanged(nameof(LeftCentralAreaText));
            }
        }

        private BitmapImage _mainPicture;
        public BitmapImage MainPicture
        {
            get
            {
                return _mainPicture;
            }
            set
            {
                _mainPicture = value;
                OnPropertyChanged(nameof(MainPicture));
            }
        }

        private string _bottomAreaHeader;
        public string BottomAreaHeader
        {
            get
            {
                return _bottomAreaHeader;
            }
            set
            {
                _bottomAreaHeader = value;
                OnPropertyChanged(nameof(BottomAreaHeader));
            }
        }

        private string _bottomAreaContent;
        public string BottomAreaContent
        {
            get
            {
                return _bottomAreaContent;
            }
            set
            {
                _bottomAreaContent = value;
                OnPropertyChanged(nameof(BottomAreaContent));
            }
        }

        private bool CanExecute(object parameter)
        {
            if (parameter == null)
            {
                return false;
            }

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

        

        private async void Execute(object param)
        {
            var fieldElements = (object[])param;
            string name = NameInput;
            string email = EmailInput;
            string mobile = MobileInput;
            string serviceName = ServiceChooseItem.Content.ToString();
            string message = MessageInput;
            TextBlock tbServerError = (TextBlock)fieldElements[5];
            TextBlock tbOrderSave = (TextBlock)fieldElements[6];

            OrderModel order = new OrderModel();
            order.Name = name;
            order.Email = email;
            order.Mobile = mobile;
            order.ServiceName = serviceName;
            order.Message = message;
            order.StatusName = "Recieved";
            bool resultSendOrder = await _api.SaveOrder(order);

            if (resultSendOrder)
            {
                tbOrderSave.Text = "Order succesfully added";
            }
            else
            {
                tbServerError.Text = "Server error";
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

        private void BlocksAssignText()
        {
            LeftCentralAreaText = HomePagePlaceholder.LeftCentralAreaText;
            MainPicture = _ic.ByteArrayToImage(HomePagePlaceholder.MainPicture);
            BottomAreaHeader = HomePagePlaceholder.BottomAreaHeader;
            BottomAreaContent = HomePagePlaceholder.BottomAreaContent;
        }

        private List<ComboBoxItem> CreateBoxItems()
        {
            List<ComboBoxItem> lCbItems = new List<ComboBoxItem>();
            List<string> lsn = GetServiceNames();
            foreach(string name in lsn)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = name;
                lCbItems.Add(cbi);
            }
            return lCbItems;
        }

        private List<string> GetServiceNames()
        {
            List<string> lsn = new List<string>();
            lsn = _api.GetServiceNames();
            return lsn;
        }
    }
}
