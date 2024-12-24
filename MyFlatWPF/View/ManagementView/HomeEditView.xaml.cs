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
        Style styleButton = new Style();
        Style styleHoverButton = new Style();
        Style styleCircleButton = new Style();
        Style styleHoverCircleButton = new Style();

        public HomeEditView()
        {
            InitializeComponent();
            styleButton = (Style)this.gHomeEdit.FindResource("ButtonStyle");
            styleHoverButton = (Style)this.gHomeEdit.FindResource("ButtonHoverStyle");
            styleCircleButton = (Style)this.gHomeEdit.FindResource("ButtonCircleStyle");
            styleHoverCircleButton = (Style)this.gHomeEdit.FindResource("HoverButtonCircleStyle");
            this.DataContext = new HomeEditViewModel(this.wpTopMenuLinks, 
                                                     this.btnAddPhrase,
                                                     this.wpRandomPhrases,
                                                     this.iHomePage,
                                                     this.tbImageName,
                                                     this.btnChooseImage,
                                                     this.btnSaveNewImage,
                                                     this.tbInputCentralArea,
                                                     this.btnChangeHeaderCentralArea,
                                                     this.tbInputHeaderBottom,
                                                     this.btnChangeBottomHeader,
                                                     this.tbInputBottomContent,
                                                     this.btnChangeBotomContent);
        }



        private void Btn_mouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;
                btnMenu.Style = styleHoverButton;
                btnMenu.OverridesDefaultStyle = true;
                btnMenu.Cursor = Cursors.Hand;
                btnMenu.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#0082ff"));
            }
        }

        private void Btn_mouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;
                btnMenu.Style = styleButton;
                btnMenu.OverridesDefaultStyle = true;
                btnMenu.Cursor = Cursors.Hand;
                btnMenu.Background = Brushes.DeepSkyBlue;
            }
        }

        private void BtnCircle_mouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;
                btnMenu.Style = styleHoverCircleButton;
                btnMenu.OverridesDefaultStyle = true;
                btnMenu.Cursor = Cursors.Hand;
                btnMenu.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#0082ff"));
            }
        }

        private void BtnCircle_mouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;
                btnMenu.Style = styleCircleButton;
                btnMenu.OverridesDefaultStyle = true;
                btnMenu.Cursor = Cursors.Hand;
                btnMenu.Background = Brushes.DeepSkyBlue;
            }
        }
    }
}
