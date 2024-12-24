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
