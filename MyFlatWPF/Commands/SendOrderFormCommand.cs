using MyFlatWPF.HelpMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFlatWPF.Commands
{
    public class SendOrderFormCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        CheckInputFields checkInput = new CheckInputFields();

        public bool CanExecute(object parameter)
        {
            if(parameter == null)
            {
                return false;
            }

            bool result = checkInput.CheckOrderFormFields(App.HomeWiew, parameter);
            if (!result)
            {
                return false;
            }
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
