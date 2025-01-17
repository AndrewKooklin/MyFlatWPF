using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.Model;
using MyFlatWPF.Model.ManagementModel;
using System.Windows.Controls;

namespace MyFlatWPF.View.ManagementView
{
    /// <summary>
    /// Interaction logic for OrdersByPeriodView.xaml
    /// </summary>
    public partial class OrdersByPeriodView : UserControl
    {
        APIManagementRepository _api = new APIManagementRepository();

        public OrdersByPeriodView()
        {
            InitializeComponent();
        }

        private async void Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox)
            {
                var comboBox = sender as ComboBox;
                if (comboBox.SelectedItem == comboBox.SelectionBoxItem)
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

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
