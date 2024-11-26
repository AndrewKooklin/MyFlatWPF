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
        ObservableCollection<OrderModel> _lOm = new ObservableCollection<OrderModel>();

        public OrdersViewModel()
        {
            _lOm = new ObservableCollection<OrderModel>();
        }
        
    }
}
