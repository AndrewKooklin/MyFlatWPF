using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyFlatWPF.ViewModel
{
    public class ServicesViewModel : BaseViewModel
    {
        private StackPanel _stackPanel;

        public ServicesViewModel(StackPanel stackPanel)
        {
            _stackPanel = stackPanel;

            GetServiceCards(_stackPanel);
        }

        private void GetServiceCards(StackPanel stackPanel)
        {
            for (int i = 0; i < 5; i++)
            {
                Expander exp = new Expander();

                Border expBorderHeader = new Border();
                expBorderHeader.BorderBrush = Brushes.Black;
                expBorderHeader.BorderThickness = new Thickness(1, 1, 1, 1);
                expBorderHeader.CornerRadius = new CornerRadius(6, 6, 6, 6);

                TextBlock tbHeader = new TextBlock();
                tbHeader.Text = "Building design";
                tbHeader.Width = 400;
                tbHeader.FontSize = 16;
                tbHeader.FontWeight = FontWeights.DemiBold;
                tbHeader.HorizontalAlignment = HorizontalAlignment.Left;
                tbHeader.Padding = new Thickness(10, 10, 0, 10);
                tbHeader.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#34b4ff"));
                tbHeader.MouseEnter += new MouseEventHandler(cursor_MouseEnter);
                tbHeader.MouseLeave += new MouseEventHandler(cursor_MouseLeave);

                expBorderHeader.Child = tbHeader;
                exp.Header = expBorderHeader;

                Border expBorderContent = new Border();
                expBorderContent.Margin = new Thickness(25, 0, 0, 0);
                expBorderContent.BorderBrush = Brushes.White;
                expBorderContent.BorderThickness = new Thickness(1, 1, 1, 1);
                expBorderContent.CornerRadius = new CornerRadius(6, 6, 6, 6);

                TextBlock tbContent = new TextBlock();
                
                tbContent.Padding = new Thickness(15, 10, 10, 10);
                tbContent.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#fff"));
                tbContent.Text = "Tempor erat elitr rebum at clita. Diam dolor diam ipsum sit."+
                        "Aliqu diam amet diam et eos.Clita erat ipsum et lorem et sit, sed"+
                        "stet lorem sit clita duo justo.Tempor erat elitr rebum at clita.";
                tbContent.FontSize = 12;
                tbContent.FontWeight = FontWeights.Normal;
                tbContent.TextWrapping = TextWrapping.Wrap;

                expBorderContent.Child = tbContent;

                exp.Content = expBorderContent;
                exp.HorizontalAlignment = HorizontalAlignment.Center;
                exp.Width = 400;

                stackPanel.Children.Add(exp);
            }
        }

        private void cursor_MouseEnter(object sender, MouseEventArgs e)
        {
            if(sender is TextBlock)
            {
                TextBlock tb = sender as TextBlock;
                tb.Cursor = Cursors.Hand;
            };
        }

        private void cursor_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is TextBlock)
            {
                TextBlock tb = sender as TextBlock;
                tb.Cursor = Cursors.Arrow;
            };
        }
    }
}
