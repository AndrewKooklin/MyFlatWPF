using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyFlatWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_mouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;

                Border btnParent = (Border)btnMenu.Parent;
                StackPanel borderParent = (StackPanel)btnParent.Parent;
                Grid spParent = (Grid)borderParent.Parent;
                Style styleMenuItem = (Style)spParent.FindResource("ButtonStyle");


                btnMenu.Style = styleMenuItem;
                btnMenu.OverridesDefaultStyle = true;
                btnMenu.Cursor = Cursors.Hand;
                btnMenu.FontSize = 15;
                btnMenu.Foreground = Brushes.DodgerBlue;
                btnMenu.Height = 24;
                btnMenu.BorderThickness = new System.Windows.Thickness(0, 0, 0, 0);
                btnMenu.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#fff"));
            }
        }

        private void menu_mouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;

                btnMenu.OverridesDefaultStyle = true;
                btnMenu.Cursor = Cursors.Hand;
                btnMenu.FontSize = 15;
                btnMenu.Foreground = Brushes.Black;
                btnMenu.Height = 24;
                btnMenu.BorderThickness = new System.Windows.Thickness(0, 0, 0, 0);
                btnMenu.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#fff"));
            }
        }
    }
}
