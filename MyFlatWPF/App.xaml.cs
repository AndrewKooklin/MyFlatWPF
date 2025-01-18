using MyFlatWPF.View;
using MyFlatWPF.View.ManagementView;
using MyFlatWPF.View.ManagementView.BlogView;
using MyFlatWPF.View.ManagementView.ContactsView;
using MyFlatWPF.View.ManagementView.RolesView;
using MyFlatWPF.View.ManagementView.ServicesView;
using MyFlatWPF.View.ManagementView.UsersView;
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

        public static HomeView HomeView = new HomeView();

        public static ManagementWindow ManagementWindow = new ManagementWindow();

        public static ProjectsView ProjectsView;

        public static ProjectDetailView ProjectDetailView = new ProjectDetailView();

        public static PostDetailView PostDetailView = new PostDetailView();

        public static ServicesView ServicesView;

        public static BlogView BlogView;

        public static ContactsView ContactsView;

        public static LoginView LoginView = new LoginView();

        public static RegistrationView RegistrationView = new RegistrationView();

        public static OrdersByServicesView OrdersByServicesView;

        public static AllOrdersView AllOrdersView;

        public static OrdersByPeriodView OrdersByPeriodView = new OrdersByPeriodView();

        public static OrdersView OrdersView = new OrdersView();

        public static HomeEditView HomeEditView;

        public static ProjectsEditView ProjectsEditView = new ProjectsEditView();

        public static ProjectEditView ProjectEditView = new ProjectEditView();

        public static AddProjectView AddProjectView = new AddProjectView();

        public static ServicesEditView ServicesEditView = new ServicesEditView();

        public static ServiceEditView ServiceEditView = new ServiceEditView();

        public static AddServiceView AddServiceView = new AddServiceView();

        public static PostsEditView PostsEditView = new PostsEditView();

        public static PostEditView PostEditView = new PostEditView();

        public static AddPostView AddPostView = new AddPostView();

        public static ContactsEditView ContactsEditView = new ContactsEditView();

        public static AddLinkView AddLinkView = new AddLinkView();

        public static LinkEditView LinkEditView = new LinkEditView();

        public static AllUsersView AllUsersView = new AllUsersView();

        public static AddUserView AddUserView = new AddUserView();

        public static UserEditView UserEditView = new UserEditView();

        public static AllRolesView AllRolesView = new AllRolesView();

        public static AddRoleView AddRoleView = new AddRoleView();

        public static RoleEditView RoleEditView = new RoleEditView();



        protected override void OnStartup(StartupEventArgs e)
        {
            App.MainWindow = new MainWindow();
            App.MainWindow.Show();

            base.OnStartup(e);

            Style dpStyle = new Style(typeof(DatePicker));
            dpStyle.Setters.Add(new Setter(DatePicker.LanguageProperty,
                System.Windows.Markup.XmlLanguage.GetLanguage("ru-RU")));
            this.Resources.Add(typeof(DatePicker), dpStyle);
        }
    }
}
