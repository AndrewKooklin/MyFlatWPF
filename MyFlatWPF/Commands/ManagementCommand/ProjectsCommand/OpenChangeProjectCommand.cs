using MyFlatWPF.View.ManagementView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.ProjectsCommand
{
    public class OpenChangeProjectCommand : ICommand
    {
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
            else
            {
                int id = (Int32)parameter;

                App.ProjectEditView = null;
                App.ProjectEditView = new ProjectEditView();
                ProjectEditViewModel pevm = 
                    new ProjectEditViewModel(App.ProjectEditView.tbHeaderEdit,
                                             App.ProjectEditView.tbContentEdit,
                                             App.ProjectEditView.iProjectImage,
                                             App.ProjectEditView.btnChooseImage,
                                             App.ProjectEditView.tblImageName,
                                             App.ProjectEditView.btnChange,
                                             App.ProjectEditView.btnCancel,
                                             id);

                App.ProjectEditView.Visibility = System.Windows.Visibility.Visible;
                StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                    App.ProjectEditView;
            }
        }
    }
}
