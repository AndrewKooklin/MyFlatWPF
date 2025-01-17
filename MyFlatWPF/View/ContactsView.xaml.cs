using MyFlatWPF.ViewModel;
using System.Windows.Controls;

namespace MyFlatWPF.View
{
    /// <summary>
    /// Interaction logic for ContactsView.xaml
    /// </summary>
    public partial class ContactsView : UserControl
    {
        public ContactsView()
        {
            InitializeComponent();
            this.DataContext = new ContactsViewModel(this.spSocialLinks);
        }
    }
}
