using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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
            
        }

        
    }
}
