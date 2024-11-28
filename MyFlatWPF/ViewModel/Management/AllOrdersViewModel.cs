using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFlatWPF.ViewModel.Management
{
    public class AllOrdersViewModel : BaseViewModel
    {
        APIManagementRepository _api = new APIManagementRepository();

        public AllOrdersViewModel()
        {
            _orders = GetOrders();
            _statusNames = new ObservableCollection<string>(_api.GetStatusNames());
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

        private string _ordersCount;
        public string OrdersCount
        {
            get
            {
                return _ordersCount;
            }
            set
            {
                _ordersCount = value;
                OnPropertyChanged(nameof(OrdersCount));
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

        private ObservableCollection<OrderModel> GetOrders()
        {
            ObservableCollection<OrderModel> orders =
                new ObservableCollection<OrderModel>(_api.GetAllOrders());
            _ordersCount = $"Orders count : {orders.Count}";
            return orders;
        }
    }
}
