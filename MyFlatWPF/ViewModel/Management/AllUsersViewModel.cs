using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyFlatWPF.ViewModel.Management
{
    public class AllUsersViewModel : BaseViewModel
    {
        public AllUsersViewModel(Button btnAddUser,
                                 StackPanel spUsers)
        {



        }

        private ICommand OpenAddUserCommand { get; set; }

        private ICommand OpenChangeUserCommand { get; set; }

        private ICommand DeleteUserCommand { get; set; }
    }
}
