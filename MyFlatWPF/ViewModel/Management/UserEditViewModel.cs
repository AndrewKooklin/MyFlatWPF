using MyFlatWPF.Commands.ManagementCommand.AccountCommand;
using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.Model.AccountModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyFlatWPF.ViewModel.Management
{
    public class UserEditViewModel : BaseViewModel
    {
        APIAccountRepository _api = new APIAccountRepository();

        public UserEditViewModel()
        {

        }

        public UserEditViewModel(int id,
                                 ComboBox cbRoles,
                                 TextBlock tblUserName,
                                 TextBlock tblEmail,
                                 TextBlock tblRoles,
                                 Button btnAddRole,
                                 Button btnDeleteRole,
                                 TextBlock tblMessage)
        {
            UserWithRolesModel user = _api.GetUserWithRoles(id.ToString());
            cbRoles.ItemsSource = _api.GetRoles();
            tblUserName.Text = user.User.UserName;
            tblEmail.Text = user.User.Email;
            List<string> roles = user.Roles;
            if(roles.Count > 0)
            {
                foreach (string role in roles)
                {
                    tblRoles.Text += $"{role}\n";
                }
            }
            else
            {
                tblRoles.Text = "";
            }
            AddRoleToUserCommand = new AddRoleToUserCommand();
            DeleteRoleToUserCommand = new DeleteRoleToUserCommand();
            btnAddRole.Command = AddRoleToUserCommand;
            btnDeleteRole.Command = DeleteRoleToUserCommand;
        }

        public ICommand AddRoleToUserCommand { get; set; }

        public ICommand DeleteRoleToUserCommand { get; set; }
    }
}
