using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.ViewModel;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand
{
    public class DeleteRandomPhraseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        APIManagementRepository _api = new APIManagementRepository();

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            if(parameter == null)
            {
                return;
            }
            else
            {
                int id = (Int32)parameter;
                bool result = await _api.DeleteRandomPhrase(id);
                if (result)
                {
                    App.HomeEditView.wpRandomPhrases.Children.Clear();
                    StaticManagementViewModel.EditViewModel.AddElementsRandomPhrases(App.HomeEditView.wpRandomPhrases);
                    StaticMainViewModel.MainViewModel.AssignRandomPhrase();
                }
            }
        }
    }
}
