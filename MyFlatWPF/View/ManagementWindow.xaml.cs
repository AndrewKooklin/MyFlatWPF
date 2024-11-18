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
using System.Windows.Shapes;

namespace MyFlatWPF.View
{
    /// <summary>
    /// Interaction logic for ManagementWindow.xaml
    /// </summary>
    public partial class ManagementWindow : Window
    {
        public ManagementWindow()
        {
            InitializeComponent();
        }

        private void btnExpander_mouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;
                Border btnParent = (Border)btnMenu.Parent;
                StackPanel bParent = (StackPanel)btnParent.Parent;
                Expander spParent = (Expander)bParent.Parent;
                StackPanel expParent = (StackPanel)spParent.Parent;
                StackPanel spLeftMenu = (StackPanel)expParent.Parent;
                Grid grid = (Grid)spLeftMenu.Parent;
                Style styleMenuItem = (Style)grid.FindResource("HoverButtonStyle");

                btnMenu.Style = styleMenuItem;
                btnMenu.OverridesDefaultStyle = true;
                btnMenu.FontSize = 16;
                btnMenu.Width = 140;
                btnMenu.HorizontalContentAlignment = HorizontalAlignment.Left;
                btnMenu.Margin = new System.Windows.Thickness(0, 10, 0, 0);
                btnMenu.Cursor = Cursors.Hand;
                btnMenu.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#69baff"));

                btnParent.BorderThickness = new System.Windows.Thickness(1, 1, 1, 1);
            }
        }

        private void btnExpander_mouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;
                btnMenu.OverridesDefaultStyle = true;
                btnMenu.Cursor = Cursors.Hand;
                btnMenu.Foreground = Brushes.White;
            }
        }

        private void btn_mouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;
                Border btnParent = (Border)btnMenu.Parent;
                StackPanel bParent = (StackPanel)btnParent.Parent;
                StackPanel spLeftMenu = (StackPanel)bParent.Parent;
                Grid grid = (Grid)spLeftMenu.Parent;
                Style styleMenuItem = (Style)grid.FindResource("HoverButtonStyle");

                btnMenu.Style = styleMenuItem;
                btnMenu.OverridesDefaultStyle = true;
                btnMenu.FontSize = 16;
                btnMenu.HorizontalAlignment = HorizontalAlignment.Left;
                btnMenu.Margin = new System.Windows.Thickness(0, 10, 0, 0);
                btnMenu.Cursor = Cursors.Hand;
                btnMenu.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#69baff"));

                btnParent.BorderThickness = new System.Windows.Thickness(1, 1, 1, 1);
            }
        }

        private void btn_mouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;
                btnMenu.OverridesDefaultStyle = true;
                btnMenu.Cursor = Cursors.Hand;
                btnMenu.Foreground = Brushes.White;
            }
        }
    }
}
