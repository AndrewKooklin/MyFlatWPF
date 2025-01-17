using MyFlatWPF.ViewModel.Management;
using System.Windows.Controls;

namespace MyFlatWPF.View.ManagementView.ContactsView
{
    /// <summary>
    /// Interaction logic for ContastsEditView.xaml
    /// </summary>
    public partial class ContactsEditView : UserControl
    {
        public ContactsEditView()
        {
            InitializeComponent();
            this.DataContext = new ContactsEditViewModel(this.tbAddress,
                                                         this.tbPhone,
                                                         this.tbEmail,
                                                         this.btnChangeContacts,
                                                         this.btnAddLink,
                                                         this.spSocialLinks);
        }
    }
}
