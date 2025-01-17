using MyFlatWPF.ViewModel.Management;
using System.Windows.Controls;

namespace MyFlatWPF.View.ManagementView.RolesView
{
    /// <summary>
    /// Interaction logic for AllRolesView.xaml
    /// </summary>
    public partial class AllRolesView : UserControl
    {
        public AllRolesView()
        {
            InitializeComponent();
            this.DataContext = new AllRolesViewModel(this.btnAddRole,
                                                     this.spRoles);
        }
    }
}
