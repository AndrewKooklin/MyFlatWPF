using Microsoft.AspNet.Identity.EntityFramework;
using MyFlatWPF.Commands.ManagementCommand.AccountCommand;
using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.HelpMethods;
using MyFlatWPF.Model.AccountModel;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyFlatWPF.ViewModel.Management
{
    public class UserEditViewModel : BaseViewModel
    {
        APIAccountRepository _api = new APIAccountRepository();
        Style styleButton = new Style();
        Style styleHoverButton = new Style();

        public UserEditViewModel()
        {

        }

        public UserEditViewModel(string id,
                                 ComboBox cbRoles,
                                 TextBlock tblUserName,
                                 TextBlock tblEmail,
                                 TextBlock tblRoles,
                                 Button btnAddRole,
                                 Button btnDeleteRole,
                                 TextBlock tblMessage,
                                 Button btnBackToUsers)
        {
            Grid gUserEdit = (Grid)tblUserName.Parent;
            styleButton = (Style)gUserEdit.FindResource("ButtonStyle");
            styleHoverButton = (Style)gUserEdit.FindResource("ButtonHoverStyle");

            UserWithRolesModel user = _api.GetUserWithRoles(id);
            IEnumerable<IdentityRole> lRoles = _api.GetRoles();
            List<string> roleNames = new List<string>();
            foreach(var role in lRoles)
            {
                roleNames.Add(role.Name);
            }
            cbRoles.ItemsSource = roleNames;
            tblUserName.Text = user.User.UserName;
            tblEmail.Text = user.User.Email;
            if (user.Roles != null)
            {
                List<string> roles = user.Roles;
                int count = 1;
                if (roles.Count > 0)
                {
                    foreach (string role in roles)
                    {
                        if (count == roles.Count)
                        {
                            tblRoles.Text += $"{role}";
                        }
                        else
                        {
                            tblRoles.Text += $"{role}\n";
                            count++;
                        }
                    }
                }
            }
            else
            {
                tblRoles.Text = "";
            }
            AddRoleToUserCommand = new AddRoleToUserCommand();
            DeleteRoleToUserCommand = new DeleteRoleToUserCommand();
            BackToListUsersCommand = new BackToListUsersCommand();
            btnAddRole.Command = AddRoleToUserCommand;
            btnAddRole.MouseEnter += Btn_mouseEnter;
            btnAddRole.MouseLeave += Btn_mouseLeave;
            btnDeleteRole.Command = DeleteRoleToUserCommand;
            btnDeleteRole.MouseEnter += Btn_mouseEnter;
            btnDeleteRole.MouseLeave += Btn_mouseLeave;
            tblMessage.Text = "";
            btnBackToUsers.Command = BackToListUsersCommand;
            btnBackToUsers.MouseEnter += Btn_mouseEnter;
            btnBackToUsers.MouseLeave += Btn_mouseLeave;
            StaticUser.UserTemp = user;
        }

        public ICommand AddRoleToUserCommand { get; set; }

        public ICommand DeleteRoleToUserCommand { get; set; }

        public ICommand BackToListUsersCommand { get; set; }

        private void Btn_mouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;
                btnMenu.Style = styleHoverButton;
                btnMenu.OverridesDefaultStyle = true;
                btnMenu.Cursor = Cursors.Hand;
                btnMenu.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#0082ff"));
            }
        }

        private void Btn_mouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;
                btnMenu.Style = styleButton;
                btnMenu.OverridesDefaultStyle = true;
                btnMenu.Cursor = Cursors.Hand;
                btnMenu.Background = Brushes.DeepSkyBlue;
            }
        }
    }
}
