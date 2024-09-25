using MyFlatWPF.Model;
using MyFlatWPF.View;
using MyFlatWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFlatWPF.Commands
{
    public class OpenProjectDetailsCommand : ICommand
    {
        private MainWindowViewModel _mainWindowViewModel;

        public OpenProjectDetailsCommand(/*MainWindowViewModel mainWindowViewModel*/)
        {
            //_mainWindowViewModel = mainWindowViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter == null)
            {
                return;
            }


            string idProject = parameter.ToString();

            //var projectFromBase = GetProject(string idProject);

            ProjectModel project = new ProjectModel();
            //project.ProjectHeader = projectFromBase.ProjectHeader;
            //project.ProjectImage = projectFromBase.ProjectImage;
            //project.ProjectDescription = projectFromBase.ProjectDescription;

            //ProjectDetailView projectDetailView = new ProjectDetailView();
            //projectDetailView.tbProjectName.Text = "";
            //projectDetailView.tbProjectDescription.Text = "";
            //projectDetailView.iProjectImage.Source = "";

            App.ProjectDetailWiew.Visibility = System.Windows.Visibility.Visible;

            App.mainWindow.ccView = App.ProjectDetailWiew;
        }
    }
}
