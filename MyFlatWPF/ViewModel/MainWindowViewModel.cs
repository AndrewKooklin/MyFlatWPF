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
        public MainWindowViewModel()
        {
            SwitchViewCommand = new SwitchViewCommand(this);
            LogoutCommand = new LogoutCommand();
            CurrentView = App.HomeView;
            //StaticMainViewModel.HomeViewModel = this;
            AssignNamesLinks();
            AssignRandomPhrase();
        }

        private string _home;
        public string Home
        {
            get
            {
                return _home;
            }
            set
            {
                _home = value;
                OnPropertyChanged(nameof(Home));
            }
        }

        private string _projects;
        public string Projects
        {
            get
            {
                return _projects;
            }
            set
            {
                _projects = value;
                OnPropertyChanged(nameof(Projects));
            }
        }

        private string _services;
        public string Services
        {
            get
            {
                return _services;
            }
            set
            {
                _services = value;
                OnPropertyChanged(nameof(Services));
            }
        }

        private string _blog;
        public string Blog
        {
            get
            {
                return _blog;
            }
            set
            {
                _blog = value;
                OnPropertyChanged(nameof(Blog));
            }
        }

        private string _contacts;
        public string Contacts
        {
            get
            {
                return _contacts;
            }
            set
            {
                _contacts = value;
                OnPropertyChanged(nameof(Contacts));
            }
        }

        private string _userName;
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        private string _randomPhrase;
        public string RandomPhrase
        {
            get
            {
                return _randomPhrase;
            }
            set
            {
                _randomPhrase = value;
                OnPropertyChanged(nameof(RandomPhrase));
            }
        }

        public List<string> RandomPhrases { get; set; } = new List<string>();

        public void AssignNamesLinks()
        {
            List<TopMenuLinkNameModel> tmln = new List<TopMenuLinkNameModel>();
            tmln = GetLinkNamesFromDB();
            Home = tmln[0].LinkName;
            Projects = tmln[1].LinkName;
            Services = tmln[2].LinkName;
            Blog = tmln[3].LinkName;
            Contacts = tmln[4].LinkName;
        }

        public void AssignRandomPhrase()
        {
            _randomPhrase = GetHeaderString();
        }

        public string GetHeaderString()
        {
            RandomPhrases = GetRandomPhrasesFromDB();
            string[] Titles = RandomPhrases.ToArray();
            //{
            //    "BUILD YOU FLAT!",
            //    "GOOD HOUSE!",
            //    "THE BEST SERVICE",
            //    "EXCELLENT QUALITY",
            //    "EXCELLENT JOB",
            //    "LIVE COMFORTABLY",
            //    "ECO-FRIENDLY HOUSES",
            //    "SMART CONSTRUCTION"
            //};

            return Titles[new Random().Next(0, Titles.Length)];
        }

        private List<TopMenuLinkNameModel> GetLinkNamesFromDB()
        {
            List<TopMenuLinkNameModel> tmln = new List<TopMenuLinkNameModel>();
            APIRenderingRepository apiRep = new APIRenderingRepository();
            tmln = apiRep.GetTopMenuLinkNames();
            return tmln;
        }

        private List<string> GetRandomPhrasesFromDB()
        {
            APIRenderingRepository apiRep = new APIRenderingRepository();
            return apiRep.GetRandomPhraseNames();
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

        private UserControl _currentView;

        public UserControl CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public ICommand SwitchViewCommand { get; set; }

        public ICommand LogoutCommand { get; set; }

    }
}
