using MyFlatWPF.HelpMethods;
using System;
using System.Windows.Input;

namespace MyFlatWPF.Commands
{
    public class SendOrderFormCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        CheckInputFields checkInput = new CheckInputFields();

        public bool CanExecute(object parameter)
        {
            if (parameter == null)
            {
                return false;
            }

            bool result = checkInput.CheckOrderFormFields(App.HomeView, parameter);
            if (!result)
            {
                return false;
            }
            App.HomeView.btnSendForm.IsEnabled = true;
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
