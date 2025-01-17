using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.Model;
using MyFlatWPF.ViewModel;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand
{
    public class AddRandomPhraseCommand : ICommand
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
                string text = parameter.ToString();
                RandomPhraseModel rpm = new RandomPhraseModel();
                rpm.Phrase = text;
                bool result = await _api.AddRandomPhrase(rpm);
                if (result)
                {
                    App.HomeEditView.wpRandomPhrases.Children.Clear();
                    StaticManagementViewModel.EditViewModel.AddElementsRandomPhrases(App.HomeEditView.wpRandomPhrases);
                    StaticViewModel.MainViewModel.AssignRandomPhrase();
                    App.HomeEditView.tbInputPhrase.Text = "";
                }
            }
        }
    }
}
