using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.Model;
using MyFlatWPF.Model.ManagementModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for AllOrdersView.xaml
    /// </summary>
    public partial class AllOrdersView : UserControl
    {
        APIManagementRepository _api = new APIManagementRepository();

        public AllOrdersView()
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

        private void Dp_SelectedDate(object sender, SelectionChangedEventArgs e)
        {
            var dp = sender as DatePicker;
            if (dp == null) return;
            var date = dp.DisplayDate;
            dp.Text = date.ToString("dd.MM.yyyy", CultureInfo.GetCultureInfo("ru-RU"));
        }

        private void Dp_Loaded(object sender, RoutedEventArgs e)
        {
            var dp = sender as DatePicker;
            dp.Text = "Date from";
        }


        //private void Dp_Loaded(object sender, RoutedEventArgs e)
        //{
        //    var dp = sender as DatePicker;
        //    if (dp == null) return;

        //    if (VisualTreeHelper.GetChildrenCount(dp) == 1)
        //    {
        //        var border = VisualTreeHelper.GetChild(dp, 0);
        //        if (border == null)
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            var grid = VisualTreeHelper.GetChild(border, 0);
        //            if (grid == null) return;

        //            DatePickerTextBox txb = VisualTreeHelper.GetChild(grid, 1) as DatePickerTextBox;
        //            if (txb == null)
        //            {
        //                return;
        //            }
        //            else
        //            {
        //                txb.Text = "Date from";
        //            }
        //        }
        //    }
        //}
    }
}
