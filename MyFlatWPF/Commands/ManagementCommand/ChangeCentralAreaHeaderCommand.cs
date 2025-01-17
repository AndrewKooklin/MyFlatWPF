using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.Model;
using MyFlatWPF.ViewModel;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand
{
    public class ChangeCentralAreaHeaderCommand : ICommand
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
                TextBox tb = (TextBox)parameter;
                string text = tb.Text;
                HomePagePlaceholderModel hpphm = new HomePagePlaceholderModel();
                hpphm.LeftCentralAreaText = text;
                bool result = await _api.ChangeLeftCentralAreaText(hpphm);
                if (result)
                {
                    StaticViewModel.HomeViewModel.LeftCentralAreaText = text;
                }
            }
        }
    }
}
