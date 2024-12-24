using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.ContactsCommand
{
    public class ChangeContactsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        APIManagementRepository _api = new APIManagementRepository();

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            ContactModel cm = new ContactModel();
            cm.ContactAddress = App.ContactsEditView.tbAddress.Text;
            cm.ContactPhone = App.ContactsEditView.tbPhone.Text;
            cm.ContactEmail = App.ContactsEditView.tbEmail.Text;
            if (String.IsNullOrEmpty(cm.ContactAddress) ||
               String.IsNullOrEmpty(cm.ContactPhone) ||
               String.IsNullOrEmpty(cm.ContactEmail))
            {
                return;
            }
            else
            {
                bool result = await _api.ChangeContacts(cm);
            }
        }
    }
}
