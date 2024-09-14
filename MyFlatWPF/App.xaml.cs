using MyFlatWPF.View;
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
            App.mainWindow = new MainWindow();
            //CreateButton();
            App.mainWindow.Show();

            base.OnStartup(e);
        }

        public void CreateButton()
        {
            Button newBtn = new Button();
            newBtn.Content = "Click me";
            newBtn.Width = 50;
            App.mainWindow.spContent.Children.Add(newBtn);
            App.mainWindow.Show();
        }
    }
}
