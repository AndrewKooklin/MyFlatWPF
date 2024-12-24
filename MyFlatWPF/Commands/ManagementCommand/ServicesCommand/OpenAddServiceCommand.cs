using MyFlatWPF.View.ManagementView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.ServicesCommand
{
    public class OpenAddServiceCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            App.AddProjectView = null;
            App.AddProjectView = new AddProjectView();
            AddProjectViewModel pevm =
                    new AddProjectViewModel(App.AddProjectView.btnChooseImage,
                                            App.AddProjectView.btnAddProject,
                                            App.AddProjectView.btnCancel);
            App.AddProjectView.Visibility = System.Windows.Visibility.Visible;
            StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                App.AddProjectView;
        }
    }
}
