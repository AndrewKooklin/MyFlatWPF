using MyFlatWPF.Commands;
using MyFlatWPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyFlatWPF.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private HttpClient _httpClient;
        private string url = @"https://localhost:44388/";
        string urlRequest = "";
        HttpResponseMessage response = new HttpResponseMessage();

        public MainWindowViewModel()
        {
            SwitchViewCommand = new SwitchViewCommand(this);

            CurrentView = new HomeView();

        }


        private UserControl _CurrentView;

        public UserControl CurrentView
        {
            get
            {
                return _CurrentView;
            }
            set
            {
                _CurrentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public ICommand SwitchViewCommand { get; set; }

        
    }
}
