using MyFlatWPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFlatWPF.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {

        public HomeViewModel()
        {
            SendOrderFormCommand = new SendOrderFormCommand();
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
    }


}
