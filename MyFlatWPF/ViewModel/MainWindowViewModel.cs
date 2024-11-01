using MyFlatWPF.Commands;
using MyFlatWPF.Data;
using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.Model;
using MyFlatWPF.View;
using Prism.Commands;
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

        public MainWindowViewModel(Grid gridHeader)
        {

            CombineElements(CreateLeftTopMenu(), 
                            CreateRightTopMenu(), 
                            
                            gridHeader);

            SwitchViewCommand = new SwitchViewCommand(this);

            CurrentView = App.HomeWiew;

            //MenuItems = GetTopMenu();

        }

        private StackPanel CreateLeftTopMenu()
        {
            StackPanel spLeftTopMenu = new StackPanel();
            spLeftTopMenu.Name = "spLeftTopMenu";
            spLeftTopMenu.Height = 25;
            spLeftTopMenu.Orientation = Orientation.Horizontal;
            spLeftTopMenu.Width = 430;
            spLeftTopMenu.VerticalAlignment = VerticalAlignment.Top;
            spLeftTopMenu.HorizontalAlignment = HorizontalAlignment.Left;
            spLeftTopMenu.Margin = new System.Windows.Thickness(10, 0, 0, 0);
            spLeftTopMenu.Background = Brushes.White;

            Border bManagement = new Border();
            bManagement.Height = 25;
            //border.Width = 40;
            bManagement.BorderBrush = Brushes.Transparent;
            bManagement.BorderThickness = new Thickness(0, 0, 0, 0);

            Button btnManagement = new Button();
            btnManagement.Name = "Management";
            btnManagement.Content = "Management";
            btnManagement.Cursor = Cursors.Hand;
            btnManagement.FontSize = 15;
            btnManagement.Foreground = Brushes.Black;
            btnManagement.Height = 24;
            //btnManagement.Padding = new System.Windows.Thickness(5, 0, 2, 2);
            btnManagement.Margin = new System.Windows.Thickness(7, 0, 0, 0);
            btnManagement.BorderThickness = new System.Windows.Thickness(0, 0, 0, 0);
            btnManagement.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#fff"));
            btnManagement.Command = SwitchViewCommand;
            btnManagement.CommandParameter = btnManagement.Name;
            btnManagement.MouseEnter += menu_MouseEnter;
            btnManagement.MouseLeave += menu_MouseLeave;

            bManagement.Child = btnManagement;
            spLeftTopMenu.Children.Add(bManagement);

            List<TopMenuLinkNameModel> tmln = new List<TopMenuLinkNameModel>();
            tmln = GetLinkNamesFromDB();
            if(tmln != null)
            {
                foreach (var linkName in tmln)
                {
                    Border border = new Border();
                    border.Height = 25;
                    //border.Width = 40;
                    border.BorderBrush = Brushes.Transparent;
                    border.BorderThickness = new Thickness(0, 0, 0, 0);

                    Button btnMenu = new Button();
                    btnMenu.Name = linkName.LinkName;
                    btnMenu.Content = linkName.LinkName;
                    btnMenu.Cursor = Cursors.Hand;
                    btnMenu.FontSize = 15;
                    btnMenu.Foreground = Brushes.Black;
                    btnMenu.Height = 24;
                    //btnMenu.Padding = new System.Windows.Thickness(5, 0, 2, 2);
                    btnMenu.Margin = new System.Windows.Thickness(7, 0, 0, 0);
                    btnMenu.BorderThickness = new System.Windows.Thickness(0, 0, 0, 0);
                    btnMenu.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#fff"));
                    btnMenu.Command = SwitchViewCommand;
                    btnMenu.CommandParameter = btnMenu.Name;
                    btnMenu.MouseEnter += menu_MouseEnter;
                    btnMenu.MouseLeave += menu_MouseLeave;
                    
                    border.Child = btnMenu;
                    spLeftTopMenu.Children.Add(border);

                }
            }
            return spLeftTopMenu;
        }

        private StackPanel CreateRightTopMenu()
        {
            StackPanel spRightTopMenu = new StackPanel();
            spRightTopMenu.Name = "spRightTopMenu";
            spRightTopMenu.Height = 25;
            spRightTopMenu.Width = 100;
            spRightTopMenu.Orientation = Orientation.Horizontal;
            spRightTopMenu.VerticalAlignment = VerticalAlignment.Top;
            spRightTopMenu.HorizontalAlignment = HorizontalAlignment.Right;
            spRightTopMenu.Margin = new System.Windows.Thickness(10, 0, 10, 0);
            spRightTopMenu.Background = Brushes.White;

            List<Button> listBtns = new List<Button>();

            Button btnLogin = new Button();
            btnLogin.Name = "Login";
            btnLogin.Content = "Login";
            listBtns.Add(btnLogin);

            Button btnRegistration = new Button();
            btnRegistration.Name = "Register";
            btnRegistration.Content = "Register";
            listBtns.Add(btnRegistration);

            Button btnUserName = new Button();
            btnRegistration.Name = "UserName";
            btnRegistration.Content = "";
            btnUserName.Foreground = Brushes.Coral;
            btnUserName.IsEnabled = false;
            btnUserName.Cursor = Cursors.Arrow;
            btnUserName.Visibility = Visibility.Collapsed;

            Button btnLogOut = new Button();
            btnLogOut.Name = "LogOut";
            btnLogOut.Content = "LogOut";
            btnLogOut.Visibility = Visibility.Collapsed;
            listBtns.Add(btnLogOut);

            foreach(Button btn in listBtns)
            {
                btn.Cursor = Cursors.Hand;
                btn.FontSize = 15;
                btn.Foreground = Brushes.Black;
                btn.Height = 24;
                //btnManagement.Padding = new System.Windows.Thickness(5, 0, 2, 2);
                btn.Margin = new System.Windows.Thickness(7, 0, 0, 0);
                btn.BorderThickness = new System.Windows.Thickness(0, 0, 0, 0);
                btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#fff"));
                btn.Command = SwitchViewCommand;
                btn.CommandParameter = btn.Name;
                btn.MouseEnter += menu_MouseEnter;
                btn.MouseLeave += menu_MouseLeave;

                Border bbtnRightMenu = new Border();
                bbtnRightMenu.Height = 25;
                bbtnRightMenu.Width = 60;
                bbtnRightMenu.BorderBrush = Brushes.Transparent;
                bbtnRightMenu.BorderThickness = new Thickness(0, 0, 0, 0);
                bbtnRightMenu.Child = btn;
                spRightTopMenu.Children.Add(bbtnRightMenu);
            }
            return spRightTopMenu;
        }

        private void CombineElements(StackPanel spLeftTopMenu, 
                                     StackPanel spRightTopMenu,
                                     //StackPanel spRandomPhrase,
                                     //Border bContent,
                                     Grid gridHeader)
        {
            Grid.SetRow(spLeftTopMenu, 0);
            Grid.SetColumn(spLeftTopMenu, 0);
            gridHeader.Children.Add(spLeftTopMenu);

            Grid.SetRow(spRightTopMenu, 0);
            Grid.SetColumn(spRightTopMenu, 1);
            gridHeader.Children.Add(spRightTopMenu);
        }

        private List<TopMenuLinkNameModel> GetLinkNamesFromDB()
        {
            List<TopMenuLinkNameModel> tmln = new List<TopMenuLinkNameModel>();
            APIRenderingRepository apiRep = new APIRenderingRepository();
            tmln = apiRep.GetTopMenuLinkNames();
            return tmln;
        }


        
        public void menu_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;

                Border btnParent = (Border)btnMenu.Parent;
                StackPanel borderParent = (StackPanel)btnParent.Parent;
                Grid spParent = (Grid)borderParent.Parent;
                Style styleMenuItem = (Style)spParent.FindResource("ButtonStyle");


                btnMenu.Style = styleMenuItem;
                btnMenu.OverridesDefaultStyle = true;
                btnMenu.Cursor = Cursors.Hand;
                btnMenu.FontSize = 15;
                btnMenu.Foreground = Brushes.DodgerBlue;
                btnMenu.Height = 24;
                //mi.Padding = new System.Windows.Thickness(5, 0, 2, 2);
                //mi.Margin = new System.Windows.Thickness(4, 0, 0, 0);
                btnMenu.BorderThickness = new System.Windows.Thickness(0, 0, 0, 0);
                btnMenu.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#fff"));
                //ImageBrush ib = new ImageBrush(new BitmapImage(new Uri(
                //     "C:\\repos\\MyFlatWPF\\MyFlatWPF\\Images\\kind.png")));
                //mi.Background = ib;
            }
        }

        public void menu_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;

                btnMenu.OverridesDefaultStyle = true;

                btnMenu.Cursor = Cursors.Hand;
                btnMenu.FontSize = 15;
                btnMenu.Foreground = Brushes.Black;
                btnMenu.Height = 24;
                //mi.Padding = new System.Windows.Thickness(5, 0, 2, 2);
                //mi.Margin = new System.Windows.Thickness(4, 0, 0, 0);
                btnMenu.BorderThickness = new System.Windows.Thickness(0, 0, 0, 0);
                btnMenu.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#fff"));
            }
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
