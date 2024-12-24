using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.View.ManagementView.ContactsView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.ContactsCommand
{
    public class DeleteSocialLinkCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        APIManagementRepository _api = new APIManagementRepository();

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            if (parameter == null)
            {
                return;
            }
            else
            {
                int id = (Int32)parameter;
                bool result = await _api.DeleteSocialById(id);
                if (result)
                {
                    App.ContactsEditView = null;
                    App.ContactsEditView = new ContactsEditView();
                    App.ContactsEditView.Visibility = System.Windows.Visibility.Visible;
                    StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                        App.ContactsEditView;
                }
            }
        }
    }
}
