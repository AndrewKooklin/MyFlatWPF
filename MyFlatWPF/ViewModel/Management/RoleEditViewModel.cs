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
    public class RoleEditViewModel
    {
        APIAccountRepository _api = new APIAccountRepository();
        Style styleButton = new Style();
        Style styleHoverButton = new Style();
        IdentityRole _role = new IdentityRole();

        public RoleEditViewModel(string id,
                                 TextBox tbRoleName,
                                 Label lErrorRoleName,
                                 Button btnChangeRoleNAme)
        {
            Grid gRoleEdit = (Grid)tbRoleName.Parent;
            styleButton = (Style)gRoleEdit.FindResource("ButtonStyle");
            styleHoverButton = (Style)gRoleEdit.FindResource("ButtonHoverStyle");

            ChangeRoleNameCommand = new ChangeRoleNameCommand();
            _role = _api.GetRoleById(id);
            tbRoleName.Text = _role.Name;
            lErrorRoleName.Content = "";
            btnChangeRoleNAme.Command = ChangeRoleNameCommand;
            btnChangeRoleNAme.MouseEnter += Btn_mouseEnter;
            btnChangeRoleNAme.MouseLeave += Btn_mouseLeave;
        }

        public ICommand ChangeRoleNameCommand { get; set; }

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
