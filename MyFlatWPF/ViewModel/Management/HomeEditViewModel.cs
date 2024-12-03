using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyFlatWPF.ViewModel.Management
{
    public class HomeEditViewModel : BaseViewModel
    {
        WrapPanel _wrapPanel;

        public HomeEditViewModel(WrapPanel wrapPpanel)
        {
            _wrapPanel = wrapPpanel;
            AddElementsTopMenuLinks(_wrapPanel);
        }

        private void AddElementsTopMenuLinks(WrapPanel wrapPanel)
        {
            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Vertical;
            sp.HorizontalAlignment = HorizontalAlignment.Right;
            sp.Margin = new Thickness(5, 0, 0, 0);

            TextBox tb = new TextBox();
            tb.Width = 100;
            tb.FontSize = 12;
            sp.Children.Add(tb);

            Border brd = new Border();
            brd.Width = 20;
            brd.Height = 20;

            Button btn = new Button();
            btn.Background = Brushes.LightSkyBlue;

            brd.Child = btn;
            sp.Children.Add(brd);

        }
    }
}
