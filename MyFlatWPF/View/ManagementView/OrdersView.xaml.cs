using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.Model;
using MyFlatWPF.Model.ManagementModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyFlatWPF.View.ManagementView
{
    /// <summary>
    /// Interaction logic for OrdersView.xaml
    /// </summary>
    public partial class OrdersView : UserControl
    {
        APIManagementRepository _api = new APIManagementRepository();

        public OrdersView()
        {
            InitializeComponent();
        }

        private async void Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(sender is ComboBox)
            {
                var comboBox = sender as ComboBox;
                if(comboBox.SelectedItem == comboBox.SelectionBoxItem)
                {
                    return;
                }

                if (this.dgOrders.SelectedItem != null && comboBox.SelectedItem != null)
                {
                    OrderModel om = (OrderModel)this.dgOrders.SelectedItem;
                    var selectedStatus = comboBox.SelectedItem;
                    ChangeStatusModel csm = new ChangeStatusModel();
                    csm.Id = om.Id;
                    csm.Status = selectedStatus.ToString();
                    bool result = await _api.ChangeStatusOrder(csm);
                    return;
                }
            }
        }

    }
}
