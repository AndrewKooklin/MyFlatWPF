using MyFlatWPF.View;
using MyFlatWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyFlatWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainWindow MainWindow;

        //public static MainWindowViewModel MainWindowViewModel = new MainWindowViewModel();

        public static HomeView HomeView = new HomeView();

        public static ManagementWindow ManagementWindow = new ManagementWindow();

        public static ProjectsView ProjectsView = new ProjectsView();

        public static ProjectDetailView ProjectDetailView = new ProjectDetailView();

        public static PostDetailView PostDetailView = new PostDetailView();

        public static ServicesView ServicesView = new ServicesView();

        public static BlogView BlogView = new BlogView();

        public static ContactsView ContactsView = new ContactsView();

        public static LoginView LoginView = new LoginView();

        public static RegistrationView RegistrationView = new RegistrationView();

        //public static RegistrationWindow RegistrationWindow = new RegistrationWindow();



        protected override void OnStartup(StartupEventArgs e)
        {
            App.MainWindow = new MainWindow();
            //App.MainWindow.mTopLeft = MainWindowViewModel.GetTopMenu();
            //App.MainWindow.DataContext = new MainWindowViewModel();
            App.MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
