using MyFlatWPF.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MyFlatWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static new MainWindow mainWindow = new MainWindow();

        public static HomeView HomeWiew = new HomeView();

        public static ManagementWindow ManagementWindow = new ManagementWindow();

        public static ProjectsView ProjectsWiew = new ProjectsView();

        public static ServicesView ServicesWiew = new ServicesView();

        public static BlogView BlogWiew = new BlogView();

        public static ContactsView ContactsWiew = new ContactsView();

        //public static LoginWindow LoginWindow = new LoginWindow();

        //public static RegistrationWindow RegistrationWindow = new RegistrationWindow();



        protected override void OnStartup(StartupEventArgs e)
        {
            
            App.mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
