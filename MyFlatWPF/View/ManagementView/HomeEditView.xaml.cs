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
    /// Interaction logic for HomeEditView.xaml
    /// </summary>
    public partial class HomeEditView : UserControl
    {
        public HomeEditView()
        {
            InitializeComponent();
            this.DataContext = new HomeEditViewModel(this.wpTopMenuLinks, 
                                                     this.wpRandomPhrases,
                                                     this.iHomePage,
                                                     this.tbImageName,
                                                     this.btnChooseImage,
                                                     this.btnSaveNewImage,
                                                     this.tbInputCentralArea,
                                                     this.tbInputHeaderBottom,
                                                     this.tbInputBottomContent);
        }
    }
}
