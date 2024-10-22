using MyFlatWPF.Commands;
using MyFlatWPF.Data;
using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.Model;
using MyFlatWPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MyFlatWPF.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private HttpClient _httpClient;
        private string url = @"https://localhost:44388/";
        string urlRequest = "";
        HttpResponseMessage response = new HttpResponseMessage();
        private Menu _menu;

        public MainWindowViewModel()
        {

            SwitchViewCommand = new SwitchViewCommand(this);

            CurrentView = App.HomeWiew;

            MenuItems = GetTopMenu();

        }

        public List<MenuItem> GetTopMenu()
        {


            List<MenuItem> menuItems = new List<MenuItem>();

            List<TopMenuLinkNameModel> tmln = new List<TopMenuLinkNameModel>();
            APIRenderingRepository apiRep = new APIRenderingRepository();
            tmln = apiRep.GetTopMenuLinkNames();

            //MenuItem miPicture = new MenuItem();
            //miPicture.Name = "HomePicture";
            //miPicture.FontSize = 15;
            //miPicture.Height = 24;
            //miPicture.Width = 40;
            //miPicture.Command = SwitchViewCommand;
            //miPicture.CommandParameter = miPicture.Name;
            //miPicture.Padding = new System.Windows.Thickness(5, 0, 2, 2);
            //ImageBrush ib = new ImageBrush(new BitmapImage(new Uri(
            //    "C:\\repos\\MyFlatWPF\\MyFlatWPF\\Images\\kind.png")));
            //miPicture.Background = ib;
            //miPicture.Cursor = Cursors.Hand;
            //miPicture.MouseEnter += menu_mouseEnter;
            //miPicture.MouseLeave += menu_mouseLeave;
            //menuItems.Add(miPicture);

            MenuItem miManage = new MenuItem();
            miManage.Name = "miManagement";
            miManage.Header = "Management";
            miManage.FontSize = 15;
            miManage.Height = 24;
            miManage.Margin = new System.Windows.Thickness(2, 0, 0, 0);
            miManage.Padding = new System.Windows.Thickness(5, 0, 2, 2);
            miManage.Background = Brushes.Transparent;
            miManage.Command = SwitchViewCommand;
            miManage.CommandParameter = miManage.Name;
            miManage.Visibility = System.Windows.Visibility.Collapsed;
            miManage.Cursor = Cursors.Hand;
            menuItems.Add(miManage);

            foreach (var linkName in tmln)
            {
                MenuItem mi = new MenuItem();
                mi.Name = linkName.LinkName;
                mi.Header = linkName.LinkName;
                mi.Cursor = Cursors.Hand;
                mi.FontSize = 15;
                mi.Foreground = Brushes.Black;
                mi.Height = 24;
                mi.Padding = new System.Windows.Thickness(5, 0, 2, 2);
                mi.Margin = new System.Windows.Thickness(2, 0, 0, 0);
                mi.BorderThickness = new System.Windows.Thickness(0, 0, 0, 0);
                mi.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#fff"));
                mi.Command = SwitchViewCommand;
                mi.CommandParameter = mi.Name;
                mi.MouseEnter += menu_mouseEnter;
                mi.MouseLeave += menu_mouseLeave;
                menuItems.Add(mi);

            }
            return menuItems;
        }

        private void menu_mouseEnter(object sender, MouseEventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            e.Handled = true;
            //Border menuBorder = (Border)mi.Parent;
            Menu miParent = (Menu)mi.Parent;
            //Border menuBorder = (Border)miParent.Parent;
            //Grid menuParent = (Grid)miParent.Parent;
            Style styleMenuItem = (Style)menuParent.FindResource("MenuItemStyle");


            mi.Style = styleMenuItem;
            mi.OverridesDefaultStyle = true;
            mi.BorderThickness = new System.Windows.Thickness(0, 0, 0, 0);
            mi.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#fff"));
            mi.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#fff"));
            //ImageBrush ib = new ImageBrush(new BitmapImage(new Uri(
            //     "C:\\repos\\MyFlatWPF\\MyFlatWPF\\Images\\kind.png")));
            //mi.Background = ib;
        }

        private void menu_mouseLeave(object sender, MouseEventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            e.Handled = true;
            mi.OverridesDefaultStyle = true;
            mi.BorderThickness = new System.Windows.Thickness(0, 0, 0, 0);
            mi.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#fff"));
            mi.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#fff"));
            //ImageBrush ib = new ImageBrush(new BitmapImage(new Uri(
            //     "C:\\repos\\MyFlatWPF\\MyFlatWPF\\Images\\kind.png")));
            //mi.Background = ib;
        }


        private List<MenuItem> _menuItems;

        public List<MenuItem> MenuItems
        {
            get
            {
                return _menuItems;
            }
            set
            {
                _menuItems = value;
                OnPropertyChanged(nameof(MenuItems));
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
