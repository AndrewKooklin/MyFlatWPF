using MyFlatWPF.Data.Repositories.API;
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
    public class AddServiceCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        APIManagementRepository _api = new APIManagementRepository();

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            ServiceModel service = new ServiceModel();
            if (String.IsNullOrEmpty(App.AddServiceView.tbHeaderEdit.Text) ||
                String.IsNullOrEmpty(App.AddServiceView.tbContentEdit.Text))
            {
                return;
            }
            else
            {
                service.ServiceName = App.AddServiceView.tbHeaderEdit.Text;
                service.ServiceDescription = App.AddServiceView.tbContentEdit.Text;

                bool result = await _api.AddServiceToDB(service);
                if (result)
                {
                    App.AddServiceView.tbHeaderEdit.Text = "";
                    App.AddServiceView.tbContentEdit.Text = "";

                    App.ServicesEditView = null;
                    App.ServicesEditView = new ServicesEditView();
                    App.ProjectsEditView.Visibility = System.Windows.Visibility.Visible;
                    StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                        App.ServicesEditView;
                }
            }
        }
    }
}
