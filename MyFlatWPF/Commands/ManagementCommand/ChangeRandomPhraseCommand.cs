using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.Model;
using MyFlatWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand
{
    public class ChangeRandomPhraseCommand : ICommand
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
            if (parameter != null)
            {
                int id = (Int32)parameter;
                string text = "";
                List<StackPanel> sps = new List<StackPanel>();
                var UICollection = (UIElementCollection)App.HomeEditView.wpRandomPhrases.Children;
                foreach (var panel in UICollection)
                {
                    StackPanel sp = (StackPanel)panel;
                    if (sp.Name == $"sp{id}")
                    {
                        var spChildren = sp.Children;
                        TextBox tb = (TextBox)spChildren[0];
                        text = tb.Text;
                    }
                }
                RandomPhraseModel model = new RandomPhraseModel()
                {
                    Id = id,
                    Phrase = text
                };
                bool result = await _api.ChangeRandomPhrase(model);
                if (result)
                {
                    StaticViewModel.MainViewModel.AssignRandomPhrase();
                }
            }
        }
    }
}
