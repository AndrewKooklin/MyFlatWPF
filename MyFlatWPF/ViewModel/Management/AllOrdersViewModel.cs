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

        }

        public ObservableCollection<OrderModel> _orders;
        public ObservableCollection<OrderModel> Orders
        {
            get
            {
                return _orders;
            }
            set
            {
                _orders = _api;
                OnPropertyChanged(nameof(Orders));
            }
        }
    }
}
