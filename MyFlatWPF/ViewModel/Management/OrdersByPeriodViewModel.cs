using MyFlatWPF.Commands.ManagementCommand;
using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFlatWPF.ViewModel.Management
{
    public class OrdersByPeriodViewModel : BaseViewModel
    {
        APIManagementRepository _api = new APIManagementRepository();

        public OrdersByPeriodViewModel()
        {
            _orders = GetAllOrders();
            _statusNames = new ObservableCollection<string>(_api.GetStatusNames());
            ShowOrdersByPeriodCommand = new ShowOrdersByPeriodCommand(this);
        }

        public ICommand ShowOrdersByPeriodCommand { get; set; }

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

        private string _dateFrom;
        public string DateFrom
        {
            get
            {
                return _dateFrom;
            }
            set
            {
                _dateFrom = value;
                OnPropertyChanged(nameof(DateFrom));
            }
        }

        private string _dateTo;
        public string DateTo
        {
            get
            {
                return _dateTo;
            }
            set
            {
                _dateTo = value;
                OnPropertyChanged(nameof(DateTo));
            }
        }

        private ObservableCollection<OrderModel> GetAllOrders()
        {
            ObservableCollection<OrderModel> orders =
                new ObservableCollection<OrderModel>(_api.GetAllOrders());
            _ordersCount = orders.Count;
            return orders;
        }
    }
}
