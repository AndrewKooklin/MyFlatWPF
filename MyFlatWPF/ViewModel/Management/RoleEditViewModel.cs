using Microsoft.AspNet.Identity.EntityFramework;
using MyFlatWPF.Commands.ManagementCommand.AccountCommand;
using MyFlatWPF.Data.Repositories.API;
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
        Style styleTextBox = new Style();

        public RoleEditViewModel(string id,
                                 TextBox tbRoleName,
                                 Label lErrorRoleName,
                                 Button btnChangeRoleNAme,
                                 Button btnCancel)
        {
            Grid gRoleEdit = (Grid)tbRoleName.Parent;
            styleButton = (Style)gRoleEdit.FindResource("ButtonStyle");
            styleHoverButton = (Style)gRoleEdit.FindResource("ButtonHoverStyle");
            styleTextBox = (Style)gRoleEdit.FindResource("InputTextBox");

            ChangeRoleNameCommand = new ChangeRoleNameCommand();
            CancelChangeRoleNameCommand = new CancelChangeRoleNameCommand();
            _role = _api.GetRoleById(id);
            tbRoleName.Text = _role.Name;
            tbRoleName.OverridesDefaultStyle = true;
            tbRoleName.Style = styleTextBox;
            lErrorRoleName.Content = "";
            btnChangeRoleNAme.Command = ChangeRoleNameCommand;
            btnChangeRoleNAme.CommandParameter = id;
            btnChangeRoleNAme.MouseEnter += Btn_mouseEnter;
            btnChangeRoleNAme.MouseLeave += Btn_mouseLeave;

            btnCancel.Command = CancelChangeRoleNameCommand;
            btnCancel.MouseEnter += Btn_mouseEnter;
            btnCancel.MouseLeave += Btn_mouseLeave;
        }

        public ICommand ChangeRoleNameCommand { get; set; }

        public ICommand CancelChangeRoleNameCommand { get; set; }

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
