using MyFlatWPF.View;
using MyFlatWPF.View.ManagementView;
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

        public static OrdersByServicesView OrdersByServicesView = new OrdersByServicesView();

        public static OrdersByPeriodView OrdersByPeriodView = new OrdersByPeriodView();

        public static OrdersView OrdersView = new OrdersView();



        protected override void OnStartup(StartupEventArgs e)
        {
            App.MainWindow = new MainWindow();
            App.MainWindow.Show();

            base.OnStartup(e);

            Style dpStyle = new Style(typeof(System.Windows.Controls.DatePicker));
            dpStyle.Setters.Add(new Setter(System.Windows.Controls.DatePicker.LanguageProperty,
                System.Windows.Markup.XmlLanguage.GetLanguage("ru-RU")));
            this.Resources.Add(typeof(System.Windows.Controls.DatePicker), dpStyle);
        }
    }
}
