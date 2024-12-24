using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.HelpMethods;
using MyFlatWPF.Model;
using MyFlatWPF.View.ManagementView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.ProjectCommand
{
    public class AddProjectCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        APIManagementRepository _api = new APIManagementRepository();

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            ProjectModel project = new ProjectModel();
            if (String.IsNullOrEmpty(App.AddProjectView.tbHeaderEdit.Text) ||
                String.IsNullOrEmpty(App.AddProjectView.tbContentEdit.Text))
            {
                return;
            }
            else
            {
                project.ProjectHeader = App.AddProjectView.tbHeaderEdit.Text;
                project.ProjectImage = StaticImage.NewProjectImage;
                project.ProjectDescription = App.AddProjectView.tbContentEdit.Text;

                bool result = await _api.AddProjectToDB(project);
                if (result)
                {
                    App.AddProjectView.tbHeaderEdit.Text = "";
                    App.AddProjectView.iProjectImage.Source = null;
                    App.AddProjectView.tbContentEdit.Text = "";
                    App.AddProjectView.tblImageName.Text = "Image not choosed";
                    StaticImage.NewProjectImage = null;

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
