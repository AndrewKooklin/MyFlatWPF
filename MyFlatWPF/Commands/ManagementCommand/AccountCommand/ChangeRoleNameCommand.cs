using Microsoft.AspNet.Identity.EntityFramework;
using MyFlatWPF.Data.Repositories.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.AccountCommand
{
    public class ChangeRoleNameCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        APIAccountRepository _api = new APIAccountRepository();

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter == null)
            {
                return;
            }
            else
            {
                string id = parameter.ToString();
                IdentityRole _role = new IdentityRole();

            }
        }
    }
}
