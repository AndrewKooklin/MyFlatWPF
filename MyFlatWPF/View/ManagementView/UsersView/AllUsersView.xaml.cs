using MyFlatWPF.ViewModel.Management;
using System.Windows.Controls;

namespace MyFlatWPF.View.ManagementView.UsersView
{
    /// <summary>
    /// Interaction logic for AllUsersView.xaml
    /// </summary>
    public partial class AllUsersView : UserControl
    {
        public AllUsersView()
        {
            InitializeComponent();
            this.DataContext = new AllUsersViewModel(this.btnAddUser,
                                                     this.spUsers);
        }
    }
}
