using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyFlatWPF.View.ManagementView.UsersView
{
    /// <summary>
    /// Interaction logic for AddUserView.xaml
    /// </summary>
    public partial class AddUserView : UserControl
    {
        Style styleButton = new Style();
        Style styleHoverButton = new Style();

        public AddUserView()
        {
            InitializeComponent();
            styleButton = (Style)this.gAddUser.FindResource("ButtonStyle");
            styleHoverButton = (Style)this.gAddUser.FindResource("ButtonHoverStyle");
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
    }
}
