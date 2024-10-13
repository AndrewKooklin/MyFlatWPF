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
        public static MainWindow mainWindow;

        //public static MainWindowViewModel mainWindowViewModel = new MainWindowViewModel(); 

        public static HomeView HomeWiew = new HomeView();

        public static ManagementWindow ManagementWindow = new ManagementWindow();

        public static ProjectsView ProjectsWiew = new ProjectsView();

        public static ProjectDetailView ProjectDetailWiew = new ProjectDetailView();

        public static PostDetailView PostDetailView = new PostDetailView();

        public static ServicesView ServicesWiew = new ServicesView();

        public static BlogView BlogWiew = new BlogView();

        public static ContactsView ContactsWiew = new ContactsView();

        //public static LoginWindow LoginWindow = new LoginWindow();

        //public static RegistrationWindow RegistrationWindow = new RegistrationWindow();



        protected override void OnStartup(StartupEventArgs e)
        {
            App.mainWindow = new MainWindow();
            App.mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
