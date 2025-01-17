using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.Model;
using System.Collections.ObjectModel;

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

        private string _periodName;
        public string PeriodName
        {
            get
            {
                return _periodName;
            }
            set
            {
                _periodName = value;
                OnPropertyChanged(nameof(PeriodName));
            }
        }

        private int _ordersCount;
        public int OrdersCount
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
            _ordersCount = orders.Count;
            _periodName = "All Orders";
            return orders;
        }
    }
}
