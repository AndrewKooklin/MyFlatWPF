using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.Model;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand
{
    public class ShowOrdersByServiceNameCommand : ICommand, INotifyPropertyChanged
    {
        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        APIManagementRepository _api = new APIManagementRepository();
        public ICommand BackToOrdersByService { get; set; }

        public ShowOrdersByServiceNameCommand()
        {
            _statusNames = new ObservableCollection<string>(_api.GetStatusNames());
            BackToOrdersByService = this;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter != null && (parameter is String))
            {
                string service = parameter.ToString();
                Orders = new ObservableCollection<OrderModel>(_api.GetOrdersByService(service));
                
                App.OrdersView.tbHeader.Text = $"Service : {service}";
                App.OrdersView.tbOrdersCount.Text = $"Orders count : {_orders.Count}";
                App.OrdersView.dgOrders.ItemsSource = null;
                App.OrdersView.dgOrders.Items.Clear();
                App.OrdersView.dgOrders.ItemsSource = _orders;
                App.OrdersView.dgOrders.Items.Refresh();
                App.OrdersView.Visibility = System.Windows.Visibility.Visible;
                StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                    App.OrdersView;
            }
            else
            {
                App.OrdersByServicesView.Visibility = System.Windows.Visibility.Visible;
                StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                    App.OrdersByServicesView;
            }
        }

        private ObservableCollection<OrderModel> _orders;
        public ObservableCollection<OrderModel> Orders
        {
            get
            {
                return _orders;
            }
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        private ObservableCollection<string> _statusNames;
        public ObservableCollection<string> StatusNames
        {
            get
            {
                return _statusNames;
            }
            set
            {
                _statusNames = value;
                OnPropertyChanged(nameof(StatusNames));
            }
        }

        private OrderModel _orderModel;
        public OrderModel OrderModel
        {
            get
            {
                return _orderModel;
            }
            set
            {
                _orderModel = value;
                OnPropertyChanged(nameof(OrderModel));
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
