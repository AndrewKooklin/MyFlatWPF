using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.HelpMethods;
using MyFlatWPF.Model;
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
    public class ChangeServiceCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        APIManagementRepository _api = new APIManagementRepository();

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            if (parameter == null)
            {
                return;
            }
            else
            {
                int id = (Int32)parameter;
                ServiceModel service = new ServiceModel();
                service.Id = id;
                service.ServiceName = App.ServiceEditView.tbHeaderEdit.Text;
                service.ServiceDescription = App.ServiceEditView.tbContentEdit.Text;
                bool result = await _api.ChangeService(service);
                if (result)
                {
                    App.ServiceEditView.tbHeaderEdit.Text = "";
                    App.ServiceEditView.tbContentEdit.Text = "";

                    App.ServicesEditView = null;
                    App.ServicesEditView = new ServicesEditView();
                    App.ServicesEditView.Visibility = System.Windows.Visibility.Visible;
                    StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                        App.ServicesEditView;
                }
            }
        }
    }
}
