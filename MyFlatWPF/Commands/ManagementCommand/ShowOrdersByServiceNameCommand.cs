using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.Model;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand
{
    class ShowOrdersByServiceNameCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        ObservableCollection<OrderModel> _lOm;
        APIManagementRepository _api = new APIManagementRepository();

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter != null && (parameter is String))
            {
                string service = parameter.ToString();
                _lOm = new ObservableCollection<OrderModel>(_api.GetOrdersByService(service));
                App.OrdersView.tbHeader.Text = $"Service : {service}";
                App.OrdersView.tbOrdersCount.Text = $"Orders count : {_lOm.Count}";
                App.OrdersView.dgOrders.ItemsSource = _lOm;
                App.OrdersView.Visibility = System.Windows.Visibility.Visible;
                StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                    App.OrdersView;
            }
        }
    }
}
