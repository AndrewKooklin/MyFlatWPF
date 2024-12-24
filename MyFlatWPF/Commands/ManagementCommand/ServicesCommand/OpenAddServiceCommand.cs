using MyFlatWPF.View.ManagementView;
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
    public class OpenAddServiceCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            App.AddServiceView = null;
            App.AddServiceView = new AddServiceView();
            AddServiceViewModel pevm =
                    new AddServiceViewModel(App.AddServiceView.btnAddService,
                                            App.AddServiceView.btnCancel);
            App.AddServiceView.Visibility = System.Windows.Visibility.Visible;
            StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                App.AddServiceView;
        }
    }
}
