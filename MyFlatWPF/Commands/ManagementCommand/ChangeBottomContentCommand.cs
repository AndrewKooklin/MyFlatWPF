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
    public class ChangeBottomContentCommand : ICommand
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
                TextBox tb = (TextBox)parameter;
                string text = tb.Text;
                HomePagePlaceholderModel hpphm = new HomePagePlaceholderModel();
                hpphm.BottomAreaContent = text;
                bool result = await _api.ChangeBottomAreaContent(hpphm);
                if (result)
                {
                    StaticMainViewModel.HomeViewModel.BottomAreaContent = text;
                }
            }
        }
    }
}
