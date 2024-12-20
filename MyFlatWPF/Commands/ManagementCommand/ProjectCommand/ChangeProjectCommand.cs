using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.HelpMethods;
using MyFlatWPF.Model;
using MyFlatWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.ProjectCommand
{
    public class ChangeProjectCommand : ICommand
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
                ProjectModel project = new ProjectModel();
                project.Id = id;
                project.ProjectHeader = App.ProjectEditView.tblHeaderEdit.Text;
                project.ProjectDescription = App.ProjectEditView.tbContentEdit.Text;
                project.ProjectImage = StaticImage.NewProjectImage;
                bool result = await _api.ChangeProject(project);
                if (result)
                {
                    App.ProjectEditView.tblImageName.Text = "";
                    App.ProjectsView.wpProjects.Children.Clear();
                    StaticViewModel.ProjectsViewModel.GetProjectCards(App.ProjectsView.wpProjects);
                }
            }
        }
    }
}
