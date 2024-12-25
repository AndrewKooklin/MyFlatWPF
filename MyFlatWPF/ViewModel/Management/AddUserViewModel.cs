using MyFlatWPF.Commands.ManagementCommand.AccountCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyFlatWPF.ViewModel.Management
{
    public class AddUserViewModel
    {
        public AddUserViewModel(Button btnAddUser)
        {
            AddUserCommand = new AddUserCommand();
            btnAddUser.Command = AddUserCommand;
        }

        private ICommand AddUserCommand { get; set; }
    }
}
