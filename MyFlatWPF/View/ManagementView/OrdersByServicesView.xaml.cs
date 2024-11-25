using MyFlatWPF.ViewModel.Management;
using System;
using System.Collections.Generic;
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
