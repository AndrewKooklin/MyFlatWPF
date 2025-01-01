using Microsoft.AspNet.Identity.EntityFramework;
using MyFlatWPF.Commands.ManagementCommand.AccountCommand;
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
    public class AllRolesViewModel
    {
        IEnumerable<IdentityRole> _lRoles;
        APIAccountRepository _api = new APIAccountRepository();
        Style styleButton = new Style();
        Style styleHoverButton = new Style();
        Style styleCircleButton = new Style();
        Style styleHoverCircleButton = new Style();

        public AllRolesViewModel(Button btnAddRole,
                                 StackPanel spRoles)
        {
            _lRoles = _api.GetRoles();
            OpenAddRoleCommand = new OpenAddRoleCommand();
            OpenChangeRoleCommand = new OpenChangeRoleCommand();
            DeleteRoleCommand = new DeleteRoleCommand();
            Grid gAllRoles = (Grid)spRoles.Parent;
            styleButton = (Style)gAllRoles.FindResource("ButtonStyle");
            styleHoverButton = (Style)gAllRoles.FindResource("ButtonHoverStyle");
            styleCircleButton = (Style)gAllRoles.FindResource("ButtonCircleStyle");
            styleHoverCircleButton = (Style)gAllRoles.FindResource("HoverButtonCircleStyle");

            if (_lRoles != null)
            {
                AddElementProperties(btnAddRole,
                                     spRoles);
            }
        }

        private ICommand OpenAddRoleCommand { get; set; }

        private ICommand OpenChangeRoleCommand { get; set; }

        private ICommand DeleteRoleCommand { get; set; }

        private void AddElementProperties(Button btnAddRole,
                                          StackPanel spRoles)
        {
            btnAddRole.Command = OpenAddRoleCommand;
            btnAddRole.MouseEnter += Btn_mouseEnter;
            btnAddRole.MouseLeave += Btn_mouseLeave;

            StackPanel spHeaders = new StackPanel();
            spHeaders.Orientation = Orientation.Horizontal;


            TextBlock tblRoleIdHeader = new TextBlock();
            tblRoleIdHeader.Text = "Id";
            tblRoleIdHeader.Width = 200;
            tblRoleIdHeader.Height = 25;
            tblRoleIdHeader.TextWrapping = TextWrapping.Wrap;
            tblRoleIdHeader.Padding = new Thickness(40, 3, 0, 0);
            tblRoleIdHeader.Background = Brushes.LightGray;
            spHeaders.Children.Add(tblRoleIdHeader);
            TextBlock tblRoleNameHeader = new TextBlock();
            tblRoleNameHeader.Text = "Role Name";
            tblRoleNameHeader.Width = 200;
            tblRoleNameHeader.Height = 25;
            tblRoleNameHeader.Padding = new Thickness(10, 3, 0, 0);
            tblRoleNameHeader.Background = Brushes.LightGray;
            spHeaders.Children.Add(tblRoleNameHeader);

            spRoles.Children.Add(spHeaders);

            foreach (var role in _lRoles)
            {
                StackPanel spRole = new StackPanel();
                spRole.Orientation = Orientation.Horizontal;

                TextBlock tblRoleId = new TextBlock();
                tblRoleId.Text = $"{role.Id}";
                tblRoleId.Width = 200;
                tblRoleId.TextWrapping = TextWrapping.Wrap;
                tblRoleId.Padding = new Thickness(5, 5, 5, 5);
                spRole.Children.Add(tblRoleId);

                TextBlock tblRoleName = new TextBlock();
                tblRoleName.Text = $"{role.Name}";
                tblRoleName.Width = 150;
                tblRoleName.TextWrapping = TextWrapping.Wrap;
                tblRoleName.Padding = new Thickness(5, 5, 5, 5);
                spRole.Children.Add(tblRoleName);

                Button btnOpenChange = new Button();
                btnOpenChange.Content = "🖉";
                btnOpenChange.ToolTip = "Change role";
                btnOpenChange.OverridesDefaultStyle = true;
                btnOpenChange.HorizontalAlignment = HorizontalAlignment.Right;
                btnOpenChange.Margin = new Thickness(10, 2, 0, 2);
                btnOpenChange.Style = styleCircleButton;
                btnOpenChange.MouseEnter += BtnCircle_mouseEnter;
                btnOpenChange.MouseLeave += BtnCircle_mouseLeave;
                btnOpenChange.Command = OpenChangeRoleCommand;
                btnOpenChange.CommandParameter = role.Id;
                spRole.Children.Add(btnOpenChange);

                Button btnDelete = new Button();
                btnDelete.Content = "✖";
                btnDelete.ToolTip = "Delete role";
                btnDelete.OverridesDefaultStyle = true;
                btnDelete.HorizontalAlignment = HorizontalAlignment.Right;
                btnDelete.Margin = new Thickness(5, 2, 0, 2);
                btnDelete.Style = styleCircleButton;
                btnDelete.MouseEnter += BtnCircle_mouseEnter;
                btnDelete.MouseLeave += BtnCircle_mouseLeave;
                btnDelete.Command = DeleteRoleCommand;
                btnDelete.CommandParameter = role.Id;
                spRole.Children.Add(btnDelete);

                spRoles.Children.Add(spRole);

                Border border = new Border();
                border.Width = 415;
                border.Height = 0.75;
                border.BorderThickness = new Thickness(1, 1, 1, 1);
                border.BorderBrush = Brushes.LightSkyBlue;
                border.HorizontalAlignment = HorizontalAlignment.Left;
                spRoles.Children.Add(border);
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
