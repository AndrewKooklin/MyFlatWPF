using MyFlatWPF.ViewModel.Management;
using System.Windows.Controls;

namespace MyFlatWPF.View.ManagementView.ServicesView
{
    /// <summary>
    /// Interaction logic for ServicesEditView.xaml
    /// </summary>
    public partial class ServicesEditView : UserControl
    {
        public ServicesEditView()
        {
            InitializeComponent();
            this.DataContext = new ServicesEditViewModel(this.wpServices,
                                                         this.btnAddService);
        }
    }
}
