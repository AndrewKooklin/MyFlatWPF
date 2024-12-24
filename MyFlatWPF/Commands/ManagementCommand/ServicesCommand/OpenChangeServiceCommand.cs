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
    class OpenChangeServiceCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter == null)
            {
                return;
            }
            else
            {
                int id = (Int32)parameter;

                App.ServiceEditView = null;
                App.ServiceEditView = new ServiceEditView();
                ServiceEditViewModel pevm =
                    new ServiceEditViewModel(App.ServiceEditView.tbHeaderEdit,
                                             App.ServiceEditView.tbContentEdit,
                                             App.ServiceEditView.btnChange,
                                             App.ServiceEditView.btnCancel,
                                             id);

                App.ServiceEditView.Visibility = System.Windows.Visibility.Visible;
                StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                    App.ServiceEditView;
            }
        }
    }
}
