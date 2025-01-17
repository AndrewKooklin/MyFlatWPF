using MyFlatWPF.Commands.ManagementCommand;
using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.Model.ManagementModel;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyFlatWPF.ViewModel.Management
{
    public class OrdersByServiceViewModel : BaseViewModel
    {
        APIManagementRepository _api = new APIManagementRepository();
        StackPanel _sp;

        public ICommand ShowOrdersByServiceNameCommand { get; set; }

        public OrdersByServiceViewModel(StackPanel panel)
        {
            _sp = panel;
            ShowOrdersByServiceNameCommand = new ShowOrdersByServiceNameCommand();
            GetMarkupOrdersByServiceCountView(_sp);
        }

        private void GetMarkupOrdersByServiceCountView(StackPanel panel)
        {
            TextBlock tbHeader = new TextBlock();
            tbHeader.Text = "Orders By Service";
            tbHeader.HorizontalAlignment = HorizontalAlignment.Center;
            tbHeader.VerticalAlignment = VerticalAlignment.Top;
            tbHeader.Margin = new Thickness(0, 20, 0, 20);
            tbHeader.FontSize = 24;
            panel.Children.Add(tbHeader);

            TextBlock tbTotalOrders = new TextBlock();
            tbTotalOrders.HorizontalAlignment = HorizontalAlignment.Center;
            tbTotalOrders.VerticalAlignment = VerticalAlignment.Top;
            tbTotalOrders.Margin = new Thickness(0, 20, 0, 20);
            tbTotalOrders.FontSize = 20;
            int totalOrders = 0;
            panel.Children.Add(tbTotalOrders);

            Grid grid = new Grid();
            grid.Width = 220;
            grid.HorizontalAlignment = HorizontalAlignment.Center;
            grid.Margin = new Thickness(0, 10, 0, 20);

            RowDefinition row1 = new RowDefinition();
            grid.RowDefinitions.Add(row1);
            ColumnDefinition col1 = new ColumnDefinition();
            grid.ColumnDefinitions.Add(col1);
            ColumnDefinition col2 = new ColumnDefinition();
            grid.ColumnDefinitions.Add(col2);
            grid.ColumnDefinitions[0].Width = new GridLength(160, GridUnitType.Pixel);
            grid.ColumnDefinitions[1].Width = new GridLength(60, GridUnitType.Pixel);

            TextBlock lService = new TextBlock();
            lService.Text = "Service Name";
            lService.FontSize = 16;
            lService.MinWidth = 150;
            lService.HorizontalAlignment = HorizontalAlignment.Center;
            lService.Padding = new Thickness(25, 3, 15, 3);
            lService.FontWeight = FontWeights.SemiBold;
            lService.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ececec"));
            Grid.SetRow(lService, 0);
            Grid.SetColumn(lService, 0);
            grid.Children.Add(lService);

            TextBlock lCount = new TextBlock();
            lCount.Text = "Count";
            lCount.FontSize = 16;
            lCount.MinWidth = 60;
            lCount.HorizontalAlignment = HorizontalAlignment.Center;
            lCount.Padding = new Thickness(15, 3, 15, 3);
            lCount.FontWeight = FontWeights.SemiBold;
            lCount.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ececec"));
            Grid.SetRow(lCount, 0);
            Grid.SetColumn(lCount, 1);
            grid.Children.Add(lCount);

            List<ServiceOrdersCountModel> listServiceOrdersCount = new List<ServiceOrdersCountModel>();
            listServiceOrdersCount = GetListServiceOrdersCount();
            if(listServiceOrdersCount.Count >= 0)
            {
                int rowNumber = 1;
                int columnNumber = 0;

                foreach (ServiceOrdersCountModel service in listServiceOrdersCount)
                {
                    RowDefinition row = new RowDefinition();
                    grid.RowDefinitions.Add(row);
                    ColumnDefinition colService = new ColumnDefinition();
                    colService.Width = new GridLength(150);
                    grid.ColumnDefinitions.Add(colService);
                    ColumnDefinition colCount = new ColumnDefinition();
                    colCount.Width = new GridLength(40);
                    grid.ColumnDefinitions.Add(colCount);

                    Button btn = new Button();
                    btn.Content = service.ServiceName;
                    btn.Width = 150;
                    btn.FontSize = 14;
                    btn.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#2235ef"));
                    btn.Margin = new Thickness(5, 5, 5, 5);
                    btn.Padding = new Thickness(15, 0, 0, 0);
                    btn.Cursor = Cursors.Hand;
                    btn.OverridesDefaultStyle = true;
                    Grid spParent = (Grid)_sp.Parent;
                    Style styleButton = (Style)spParent.FindResource("HoverButtonStyle");
                    btn.Style = styleButton;
                    btn.BorderThickness = new Thickness(0, 0, 0, 0);
                    btn.HorizontalContentAlignment = HorizontalAlignment.Center;
                    btn.Background = Brushes.Transparent;
                    btn.BorderBrush = Brushes.Transparent;
                    btn.Command = ShowOrdersByServiceNameCommand;
                    btn.CommandParameter = service.ServiceName;
                    btn.MouseEnter += Btn_MouseEnter;
                    btn.MouseLeave += Btn_MouseLeave;
                    Grid.SetRow(btn, rowNumber);
                    Grid.SetColumn(btn, columnNumber);
                    grid.Children.Add(btn);

                    Label lbl = new Label();
                    lbl.Content = service.OrdersByServiceCount;
                    lbl.FontSize = 14;
                    lbl.HorizontalAlignment = HorizontalAlignment.Center;
                    lbl.Margin = new Thickness(5, 5, 5, 5);
                    lbl.Cursor = Cursors.Arrow;
                    Grid.SetRow(lbl, rowNumber);
                    Grid.SetColumn(lbl, columnNumber + 1);
                    grid.Children.Add(lbl);

                    totalOrders += service.OrdersByServiceCount;
                    rowNumber += 1;
                }
            }
            
            tbTotalOrders.Text = $"Total orders : {totalOrders}";
            panel.Children.Add(grid);
        }

        private void Btn_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btn = sender as Button;
                e.Handled = true;
                Grid spParent = (Grid)_sp.Parent;
                Style styleButton = (Style)spParent.FindResource("HoverButtonStyle");
                btn.OverridesDefaultStyle = true;
                btn.BorderThickness = new Thickness(0, 0, 0, 0);
                btn.Style = styleButton;
                btn.FontWeight = FontWeights.SemiBold;
                btn.Background = Brushes.Transparent;
                btn.BorderBrush = Brushes.Transparent;
                btn.Padding = new Thickness(15, 0, 0, 0);
                btn.HorizontalContentAlignment = HorizontalAlignment.Center;
            }
        }

        private void Btn_MouseLeave(object sender, MouseEventArgs e)
        {
            if(sender is Button)
            {
                Button btn = sender as Button;
                e.Handled = true;
                Grid spParent = (Grid)_sp.Parent;
                Style styleButton = (Style)spParent.FindResource("HoverButtonStyle");
                btn.OverridesDefaultStyle = true;
                btn.FontWeight = FontWeights.Normal;
                btn.BorderThickness = new Thickness(0, 0, 0, 0);
                btn.Background = Brushes.Transparent;
                btn.BorderBrush = Brushes.Transparent;
                btn.Padding = new Thickness(15, 0, 0, 0);
                btn.HorizontalContentAlignment = HorizontalAlignment.Center;
            }
        }

        private List<ServiceOrdersCountModel> GetListServiceOrdersCount()
        {
            return _api.GetServiceOrdersCount();
        }
    }
}
