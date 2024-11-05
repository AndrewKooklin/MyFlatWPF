using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.Model;
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

        private APIRenderingRepository _api = new APIRenderingRepository();

        private List<ServiceModel> Services { get; set; }

        public ServicesViewModel(StackPanel stackPanel)
        {
            _stackPanel = stackPanel;

            Services = GetServices();

            GetServiceCards(_stackPanel);
        }

        private void GetServiceCards(StackPanel stackPanel)
        {
            if(Services.Count >= 0)
            {
                foreach (ServiceModel service in Services)
                {
                    Expander exp = new Expander();

                    Border expBorderHeader = new Border();
                    expBorderHeader.BorderBrush = Brushes.Black;
                    expBorderHeader.BorderThickness = new Thickness(1, 1, 1, 1);
                    expBorderHeader.CornerRadius = new CornerRadius(6, 6, 6, 6);

                    TextBlock tbHeader = new TextBlock();
                    tbHeader.Text = service.ServiceName;
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
                    tbContent.Text = service.ServiceDescription;
                        //"Tempor erat elitr rebum at clita. Diam dolor diam ipsum sit." +
                        //    "Aliqu diam amet diam et eos.Clita erat ipsum et lorem et sit, sed" +
                        //    "stet lorem sit clita duo justo.Tempor erat elitr rebum at clita.";
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
            
        }

        private List<ServiceModel> GetServices()
        {
            List<ServiceModel> lsm = new List<ServiceModel>();
            lsm = _api.GetServicesFromDB();
            return lsm;
        }

        private void cursor_MouseEnter(object sender, MouseEventArgs e)
        {
            if(sender is TextBlock)
            {
                TextBlock tb = sender as TextBlock;
                tb.Cursor = Cursors.Hand;
                tb.Foreground = Brushes.White;
                tb.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#0193e8"));
            }
        }

        private void cursor_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is TextBlock)
            {
                TextBlock tb = sender as TextBlock;
                tb.Cursor = Cursors.Arrow;
                tb.Foreground = Brushes.Black;
                tb.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#34b4ff"));
            }
        }
    }
}
