using MyFlatWPF.ViewModel;
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
            this.DataContext = new MainWindowViewModel(this.gTopMenu);
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
                //mi.Padding = new System.Windows.Thickness(5, 0, 2, 2);
                //mi.Margin = new System.Windows.Thickness(4, 0, 0, 0);
                btnMenu.BorderThickness = new System.Windows.Thickness(0, 0, 0, 0);
                btnMenu.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#fff"));
                //ImageBrush ib = new ImageBrush(new BitmapImage(new Uri(
                //     "C:\\repos\\MyFlatWPF\\MyFlatWPF\\Images\\kind.png")));
                //mi.Background = ib;
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
                //mi.Padding = new System.Windows.Thickness(5, 0, 2, 2);
                //mi.Margin = new System.Windows.Thickness(4, 0, 0, 0);
                btnMenu.BorderThickness = new System.Windows.Thickness(0, 0, 0, 0);
                btnMenu.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#fff"));
            }
        }
    }
}
