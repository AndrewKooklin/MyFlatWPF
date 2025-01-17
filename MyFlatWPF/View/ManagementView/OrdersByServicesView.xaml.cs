using MyFlatWPF.ViewModel.Management;
using System.Windows.Controls;

namespace MyFlatWPF.View.ManagementView
{
    /// <summary>
    /// Interaction logic for OrdersByServicesView.xaml
    /// </summary>
    public partial class OrdersByServicesView : UserControl
    {
        public OrdersByServicesView()
        {
            InitializeComponent();
            this.DataContext = new OrdersByServiceViewModel(this.spOrdersByService);
        }
    }
}
