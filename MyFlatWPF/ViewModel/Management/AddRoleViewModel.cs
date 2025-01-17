using System.Windows.Input;
using MyFlatWPF.Commands.ManagementCommand.AccountCommand;

namespace MyFlatWPF.ViewModel.Management
{
    public class AddRoleViewModel
    {
        public AddRoleViewModel()
        {
            AddRoleCommand = new AddRoleCommand();
        }

        public ICommand AddRoleCommand { get; set; }
    }
}
