using MyFlatWPF.View.ManagementView.ServicesView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.ServicesCommand
{
    public class CancelChangeServiceCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            App.ServiceEditView.tbHeaderEdit.Text = "";
            App.ServiceEditView.tblContentEdit.Text = "";
            App.ServicesEditView = null;
            App.ServicesEditView = new ServicesEditView();
            App.ServicesEditView.Visibility = System.Windows.Visibility.Visible;
            StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                App.ServicesEditView;
        }
    }
}
