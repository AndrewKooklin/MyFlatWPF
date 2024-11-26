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
    public class OrdersViewModel : BaseViewModel
    {
        APIManagementRepository _api = new APIManagementRepository();
        ObservableCollection<OrderModel> _lOm;

        public OrdersViewModel()
        {
            _orders = new ObservableCollection<OrderModel>();

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

    }
}
