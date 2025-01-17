using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.View.ManagementView.ServicesView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.ServicesCommand
{
    class DeleteServiceCommand : ICommand
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
                bool result = await _api.DeleteServiceById(id);
                if (result)
                {
                    App.ServicesEditView = null;
                    App.ServicesEditView = new ServicesEditView();
                    App.ProjectsEditView.Visibility = System.Windows.Visibility.Visible;
                    StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                        App.ServicesEditView;
                }
            }
        }
    }
}
