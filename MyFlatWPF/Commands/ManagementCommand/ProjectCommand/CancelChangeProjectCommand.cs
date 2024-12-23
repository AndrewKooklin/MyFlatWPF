using MyFlatWPF.HelpMethods;
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
    public class CancelChangeProjectCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            StaticImage.NewProjectImage = null;
            App.ProjectEditView.tblImageName.Text = "Image not choosed";
            App.ProjectsEditView = null;
            App.ProjectsEditView = new ProjectsEditView();
            App.ProjectsEditView.Visibility = System.Windows.Visibility.Visible;
            StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                App.ProjectsEditView;
        }
    }
}
