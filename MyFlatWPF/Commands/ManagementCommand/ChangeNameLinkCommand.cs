using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.Model;
using MyFlatWPF.View.ManagementView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand
{
    public class ChangeNameLinkCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        APIManagementRepository _api = new APIManagementRepository();

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            if(parameter != null)
            {
                int id = Int32.Parse(parameter.ToString());
                TopMenuLinkNameModel model = new TopMenuLinkNameModel()
                {
                    Id = id
                };
                bool result = await _api.ChangeNameLinkTopMenu(model);
                if (result)
                {
                    App.HomeEditView.wpTopMenuLinks.Children.Clear();
                    HomeEditViewModel hevm = new HomeEditViewModel();
                    hevm.AddElementsTopMenuLinks(App.HomeEditView.wpTopMenuLinks);
                    //App.HomeEditView = new HomeEditView();
                    //App.AllOrdersView.Visibility = System.Windows.Visibility.Visible;
                    //StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                    //    App.HomeEditView;
                }
            }
        }
    }
}
