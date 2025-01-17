using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.View.ManagementView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.ProjectsCommand
{
    public class DeleteProjectCommand : ICommand
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
                bool result = await _api.DeleteProjectById(id);
                if (result)
                {
                    App.ProjectsEditView = null;
                    App.ProjectsEditView = new ProjectsEditView();
                    App.ProjectsEditView.Visibility = System.Windows.Visibility.Visible;
                    StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                        App.ProjectsEditView;
                }
            }
        }
    }
}
