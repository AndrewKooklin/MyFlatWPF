using Microsoft.AspNet.Identity.EntityFramework;
using MyFlatWPF.Data.Repositories.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyFlatWPF.ViewModel.Management
{
    public class AllUsersViewModel : BaseViewModel
    {
        List<IdentityUser> _lUsers;
        APIAccountRepository _api = new APIAccountRepository();
        Style styleButton = new Style();
        Style styleHoverButton = new Style();
        Style styleCircleButton = new Style();
        Style styleHoverCircleButton = new Style();

        public AllUsersViewModel(Button btnAddUser,
                                 StackPanel spUsers)
        {
            _lUsers = _api.GetUsers();
            OpenAddUserCommand = new OpenAddUserCommand();
            OpenChangeUserCommand = new OpenChangeUserCommand();
            DeleteUserCommand = new DeleteUserCommand();
            Grid gAllUsers = (Grid)spUsers.Parent;
            styleButton = (Style)gAllUsers.FindResource("ButtonStyle");
            styleHoverButton = (Style)gAllUsers.FindResource("ButtonHoverStyle");
            styleCircleButton = (Style)gAllUsers.FindResource("ButtonCircleStyle");
            styleHoverCircleButton = (Style)gAllUsers.FindResource("HoverButtonCircleStyle");

            if (_lUsers.Count > 0)
            {
                AddElementProperties(btnAddUser,
                                     spUsers);
            }

        }

        private ICommand OpenAddUserCommand { get; set; }

        private ICommand OpenChangeUserCommand { get; set; }

        private ICommand DeleteUserCommand { get; set; }

        private void AddElementProperties(Button btnAddUser,
                                          StackPanel spUsers)
        {


            btnAddUser.Command = OpenAddUserCommand;
            btnAddUser.MouseEnter += Btn_mouseEnter;
            btnAddUser.MouseLeave += Btn_mouseLeave;

            StackPanel spHeaders = new StackPanel();
            spHeaders.Orientation = Orientation.Horizontal;

            TextBlock tblUserNameHeader = new TextBlock();
            tblUserNameHeader.Text = "UserName";
            tblUserNameHeader.Width = 200;
            tblUserNameHeader.Height = 25;
            tblUserNameHeader.HorizontalAlignment = HorizontalAlignment.Center;
            tblUserNameHeader.Background = Brushes.LightGray;
            spHeaders.Children.Add(tblUserNameHeader);
            TextBlock tblEmailHeader = new TextBlock();
            tblEmailHeader.Text = "E-Mail";
            tblEmailHeader.Width = 200;
            tblEmailHeader.Height = 25;
            tblEmailHeader.HorizontalAlignment = HorizontalAlignment.Center;
            tblEmailHeader.Background = Brushes.LightGray;
            spHeaders.Children.Add(tblEmailHeader);
            TextBlock tblRolesHeader = new TextBlock();
            tblRolesHeader.Text = "Roles";
            tblRolesHeader.Width = 50;
            tblRolesHeader.Height = 25;
            tblRolesHeader.HorizontalAlignment = HorizontalAlignment.Center;
            tblRolesHeader.Background = Brushes.LightGray;
            spHeaders.Children.Add(tblRolesHeader);

            spUsers.Children.Add(spHeaders);

            foreach (IdentityUser user in _lUsers)
            {
                StackPanel spUser = new StackPanel();
                spUser.Orientation = Orientation.Horizontal;

                TextBlock tblUserName = new TextBlock();
                tblUserName.Text = $"{user.UserName}";
                tblUserName.Width = 200;
                tblUserName.TextWrapping = TextWrapping.Wrap;
                tblUserName.Padding = new Thickness(5, 3, 5, 3);
                spUser.Children.Add(tblUserName);

                TextBlock tblEmail = new TextBlock();
                tblEmail.Text = $"{user.Email}";
                tblEmail.Width = 200;
                tblEmail.TextWrapping = TextWrapping.Wrap;
                tblEmail.Padding = new Thickness(5, 3, 5, 3);
                spUser.Children.Add(tblEmail);

                TextBlock tblRoles = new TextBlock();
                tblRoles.Text = $"{user.Roles}";
                tblRoles.Width = 50;
                tblRoles.TextWrapping = TextWrapping.Wrap;
                tblRoles.Padding = new Thickness(5, 3, 5, 3);
                spUser.Children.Add(tblRoles);

                Button btnOpenChange = new Button();
                btnOpenChange.Content = "🖉";
                btnOpenChange.ToolTip = "Change user";
                btnOpenChange.OverridesDefaultStyle = true;
                btnOpenChange.HorizontalAlignment = HorizontalAlignment.Right;
                btnOpenChange.Margin = new Thickness(5, 0, 0, 0);
                btnOpenChange.Style = styleCircleButton;
                btnOpenChange.MouseEnter += BtnCircle_mouseEnter;
                btnOpenChange.MouseLeave += BtnCircle_mouseLeave;
                btnOpenChange.Command = OpenChangeUserCommand;
                btnOpenChange.CommandParameter = user.Id;
                spUser.Children.Add(btnOpenChange);

                Button btnDelete = new Button();
                btnDelete.Content = "✖";
                btnDelete.ToolTip = "Delete user";
                btnDelete.OverridesDefaultStyle = true;
                btnDelete.HorizontalAlignment = HorizontalAlignment.Right;
                btnDelete.Margin = new Thickness(5, 0, 0, 0);
                btnDelete.Style = styleCircleButton;
                btnDelete.MouseEnter += BtnCircle_mouseEnter;
                btnDelete.MouseLeave += BtnCircle_mouseLeave;
                btnDelete.Command = DeleteUserCommand;
                btnDelete.CommandParameter = user.Id;
                spUser.Children.Add(btnDelete);

                spUsers.Children.Add(spUser);
            }
        }

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

        private void BtnCircle_mouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;
                btnMenu.Style = styleHoverCircleButton;
                btnMenu.OverridesDefaultStyle = true;
                btnMenu.Cursor = Cursors.Hand;
                btnMenu.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#0082ff"));
            }
        }

        private void BtnCircle_mouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;
                btnMenu.Style = styleCircleButton;
                btnMenu.OverridesDefaultStyle = true;
                btnMenu.Cursor = Cursors.Hand;
                btnMenu.Background = Brushes.DeepSkyBlue;
            }
        }
    }
}
