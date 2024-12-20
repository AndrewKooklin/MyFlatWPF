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
    /// Interaction logic for ProjectEditView.xaml
    /// </summary>
    public partial class ProjectEditView : UserControl
    {
        public ProjectEditView()
        {
            InitializeComponent();
            //this.DataContext = new ProjectEditViewModel(this.tbHeader,
            //                                            this.tbContent,
            //                                            this.btnChooseImage,
            //                                            this.tblImageName,
            //                                            this.btnChange,
            //                                            this.btnCancel);
        }
    }
}
