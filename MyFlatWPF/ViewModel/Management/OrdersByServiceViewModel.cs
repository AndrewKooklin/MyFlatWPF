﻿using MyFlatWPF.Commands.ManagementCommand;
using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.Model.ManagementModel;
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

namespace MyFlatWPF.ViewModel.Management
{
    public class OrdersByServiceViewModel : BaseViewModel
    {
        APIManagementRepository _api = new APIManagementRepository();

        public ICommand ShowOrdersByServiceNameCommand { get; set; }

        public OrdersByServiceViewModel(StackPanel panel)
        {
            GetMarkupOrdersByServiceCountView(panel);
            ShowOrdersByServiceNameCommand = new ShowOrdersByServiceNameCommand();
        }

        private void GetMarkupOrdersByServiceCountView(StackPanel panel)
        {
            TextBlock tbHeader = new TextBlock();
            tbHeader.Text = "Orders By Service";
            tbHeader.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            tbHeader.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            tbHeader.Margin = new System.Windows.Thickness(0, 20, 0, 20);
            tbHeader.FontSize = 24;
            panel.Children.Add(tbHeader);

            TextBlock tbTotalOrders = new TextBlock();
            tbTotalOrders.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            tbTotalOrders.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            tbTotalOrders.Margin = new System.Windows.Thickness(0, 20, 0, 20);
            tbTotalOrders.FontSize = 20;
            int totalOrders = 0;
            panel.Children.Add(tbTotalOrders);

            Grid grid = new Grid();
            grid.Width = 220;
            grid.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            grid.Margin = new System.Windows.Thickness(0, 10, 0, 20);

            RowDefinition row1 = new RowDefinition();
            grid.RowDefinitions.Add(row1);
            ColumnDefinition col1 = new ColumnDefinition();
            grid.ColumnDefinitions.Add(col1);
            ColumnDefinition col2 = new ColumnDefinition();
            grid.ColumnDefinitions.Add(col2);
            grid.ColumnDefinitions[0].Width = new GridLength(160, GridUnitType.Pixel);
            grid.ColumnDefinitions[1].Width = new GridLength(50, GridUnitType.Pixel);

            TextBlock lService = new TextBlock();
            lService.Text = "Service Name";
            lService.FontSize = 16;
            lService.MinWidth = 150;
            lService.HorizontalAlignment = HorizontalAlignment.Center;
            lService.Padding = new System.Windows.Thickness(15, 3, 15, 3);
            lService.FontWeight = System.Windows.FontWeights.SemiBold;
            lService.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ececec"));
            Grid.SetRow(lService, 0);
            Grid.SetColumn(lService, 0);
            grid.Children.Add(lService);

            TextBlock lCount = new TextBlock();
            lCount.Text = "Count";
            lCount.FontSize = 16;
            lCount.MinWidth = 50;
            lCount.HorizontalAlignment = HorizontalAlignment.Center;
            lCount.Padding = new System.Windows.Thickness(15, 3, 15, 3);
            lCount.FontWeight = System.Windows.FontWeights.SemiBold;
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
                    btn.Margin = new System.Windows.Thickness(5, 5, 5, 5);
                    btn.Cursor = Cursors.Hand;
                    btn.Command = ShowOrdersByServiceNameCommand;
                    btn.CommandParameter = service.ServiceName;
                    Grid.SetRow(btn, rowNumber);
                    Grid.SetColumn(btn, columnNumber);
                    grid.Children.Add(btn);

                    Label lbl = new Label();
                    lbl.Content = service.OrdersByServiceCount;
                    lbl.FontSize = 14;
                    lbl.HorizontalAlignment = HorizontalAlignment.Center;
                    lbl.Margin = new System.Windows.Thickness(5, 5, 5, 5);
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

        private List<ServiceOrdersCountModel> GetListServiceOrdersCount()
        {
            return _api.GetServiceOrdersCount();
        }
    }
}
