using MyFlatWPF.Commands;
using MyFlatWPF.Data;
using MyFlatWPF.Model;
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
        private Menu _menu;

        public MainWindowViewModel(Menu menu)
        {
            _menu = menu;

            GetMenuItems(menu);

            SwitchViewCommand = new SwitchViewCommand(this);

            CurrentView = App.HomeWiew;

        }

        private void GetMenuItems(Menu menu)
        {
            List<TopMenuLinkNameModel> tmln = DataManager.Rendering.GetTopMenuLinkNames();

            MenuItem miPicture = new MenuItem();

            //miPicture.Background =

            MenuItem miManage = new MenuItem();
            miManage.Name = "miManagement";
            miManage.FontSize = 15;
            miManage.



            foreach (var linkName in tmln)
            {
                MenuItem mi = new MenuItem();
                mi.Name = linkName.LinkName;
                mi.Cursor = Cursors.Hand;
                mi.Command = SwitchViewCommand;
                mi.CommandParameter = mi.Name;


            }
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
