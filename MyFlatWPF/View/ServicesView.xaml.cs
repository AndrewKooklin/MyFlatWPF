using MyFlatWPF.ViewModel;
using System.Windows.Controls;

namespace MyFlatWPF.View
{
    /// <summary>
    /// Interaction logic for ServicesView.xaml
    /// </summary>
    public partial class ServicesView : UserControl
    {
        public ServicesView()
        {
            InitializeComponent();
            this.DataContext = new ServicesViewModel(this.spServices);
        }
    }
}
