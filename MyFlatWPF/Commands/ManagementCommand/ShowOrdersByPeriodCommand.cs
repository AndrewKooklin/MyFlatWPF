﻿using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.Model;
using MyFlatWPF.Model.ManagementModel;
using MyFlatWPF.View.ManagementView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace MyFlatWPF.Commands.ManagementCommand
{
    public class ShowOrdersByPeriodCommand : ICommand
    {
        private OrdersByPeriodViewModel _ordersByPeriodVM;
        public event EventHandler CanExecuteChanged;
        private DateTime _dateTodayStart = DateTime.Now.Date;
        private DateTime _dateTodayNow = DateTime.Now;
        private DateTime _dateYesterdayStart = DateTime.Now.Date.AddDays(-1);
        private DateTime _dateYesterdayEnd = DateTime.Now.Date.AddTicks(-1);
        private DateTime _dateWeekEarlier = DateTime.Now.Date.AddDays(-7);
        private DateTime _dateMonthEarlier = DateTime.Now.Date.AddMonths(-1);
        private DateTime? _dateFrom;
        private DateTime? _dateTo;
        private APIManagementRepository _api = new APIManagementRepository();

        public ShowOrdersByPeriodCommand(OrdersByPeriodViewModel ordersByPeriodVM)
        {
            _ordersByPeriodVM = ordersByPeriodVM;
            _ordersByPeriodVM.StatusNames = new ObservableCollection<string>(_api.GetStatusNames());
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            if(parameter != null)
            {
                PeriodModel pm = new PeriodModel();
                App.OrdersByPeriodView.tbHeaderPeriod.Foreground = Brushes.Black;
                string param = parameter.ToString();
                switch (param)
                {
                    case "btnToday":
                        {
                            pm.DateFrom = _dateTodayStart;
                            pm.DateTo = _dateTodayNow;
                            //App.OrdersByPeriodView = null;
                            //App.OrdersByPeriodView = new OrdersByPeriodView();
                            var orders = await GetOrdersByPeriod(pm);
                            App.OrdersByPeriodView.dgOrders.ItemsSource = orders;
                            App.OrdersByPeriodView.tbOrdersCount.Text = orders.Count.ToString();
                            App.OrdersByPeriodView.tbHeaderPeriod.Text = "Today";
                            App.OrdersByPeriodView.Visibility = System.Windows.Visibility.Visible;
                            StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                                App.OrdersByPeriodView;
                            break;
                        }
                    case "btnYesterday":
                        {
                            pm.DateFrom = _dateYesterdayStart;
                            pm.DateTo = _dateYesterdayEnd;
                            //App.OrdersByPeriodView = new OrdersByPeriodView();
                            var orders = await GetOrdersByPeriod(pm);
                            App.OrdersByPeriodView.dgOrders.ItemsSource = orders;
                            App.OrdersByPeriodView.tbOrdersCount.Text = orders.Count.ToString();
                            App.OrdersByPeriodView.tbHeaderPeriod.Text = "Yesterday";
                            App.OrdersByPeriodView.Visibility = System.Windows.Visibility.Visible;
                            StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                                App.OrdersByPeriodView;
                            break;
                        }
                    case "btnWeek":
                        {
                            pm.DateFrom = _dateWeekEarlier;
                            pm.DateTo = _dateYesterdayEnd;
                            //App.OrdersByPeriodView = new OrdersByPeriodView();
                            var orders = await GetOrdersByPeriod(pm);
                            App.OrdersByPeriodView.dgOrders.ItemsSource = orders;
                            App.OrdersByPeriodView.tbOrdersCount.Text = orders.Count.ToString();
                            App.OrdersByPeriodView.tbHeaderPeriod.Text = "Week";
                            App.OrdersByPeriodView.Visibility = System.Windows.Visibility.Visible;
                            StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                                App.OrdersByPeriodView;
                            break;
                        }
                    case "btnMonth":
                        {
                            pm.DateFrom = _dateMonthEarlier;
                            pm.DateTo = _dateYesterdayEnd;
                            //App.OrdersByPeriodView = null;
                            //App.OrdersByPeriodView = new OrdersByPeriodView();
                            var orders = await GetOrdersByPeriod(pm);
                            App.OrdersByPeriodView.dgOrders.ItemsSource = orders;
                            App.OrdersByPeriodView.tbOrdersCount.Text = orders.Count.ToString();
                            App.OrdersByPeriodView.tbHeaderPeriod.Text = "Month";
                            App.OrdersByPeriodView.Visibility = System.Windows.Visibility.Visible;
                            StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                                App.OrdersByPeriodView;
                            break;
                        }
                    case "btnPeriod":
                        {
                            _dateFrom = App.OrdersByPeriodView.dpDateFrom.SelectedDate;
                            _dateTo = App.OrdersByPeriodView.dpDateTo.SelectedDate;
                            if (_dateFrom == null || 
                                _dateTo == null || 
                                _dateFrom == DateTime.MinValue ||
                                _dateTo == DateTime.MinValue)
                            {
                                App.OrdersByPeriodView.dgOrders.ItemsSource = null;
                                App.OrdersByPeriodView.tbOrdersCount.Text = "0";
                                App.OrdersByPeriodView.tbHeaderPeriod.Text = "Select date !";
                                App.OrdersByPeriodView.tbHeaderPeriod.Foreground = Brushes.Red;
                                App.OrdersByPeriodView.Visibility = System.Windows.Visibility.Visible;
                                StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                                    App.OrdersByPeriodView;
                                return;
                            }
                            if (_dateFrom > _dateTo)
                            {
                                App.OrdersByPeriodView.tbOrdersCount.Text = "0";
                                App.OrdersByPeriodView.tbHeaderPeriod.Text = "Date From is greater than date To !";
                                App.OrdersByPeriodView.tbHeaderPeriod.Foreground = Brushes.Red;
                                App.OrdersByPeriodView.Visibility = System.Windows.Visibility.Visible;
                                StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                                    App.OrdersByPeriodView;
                                return;
                            }
                            if (_dateTo > DateTime.Now)
                            {
                                App.OrdersByPeriodView.tbOrdersCount.Text = "0";
                                App.OrdersByPeriodView.tbHeaderPeriod.Text = "Date To is greater than Now !";
                                App.OrdersByPeriodView.tbHeaderPeriod.Foreground = Brushes.Red;
                                App.OrdersByPeriodView.Visibility = System.Windows.Visibility.Visible;
                                StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                                    App.OrdersByPeriodView;
                                return;
                            }
                            else
                            {
                                pm.DateFrom = (DateTime)_dateFrom;
                                pm.DateTo = (DateTime)_dateTo;
                                var orders = await GetOrdersByPeriod(pm);
                                App.OrdersByPeriodView.dgOrders.ItemsSource = orders;
                                App.OrdersByPeriodView.tbOrdersCount.Text = orders.Count.ToString();
                                App.OrdersByPeriodView.tbHeaderPeriod.Text = "Period";
                                App.OrdersByPeriodView.Visibility = System.Windows.Visibility.Visible;
                                StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                                    App.OrdersByPeriodView;
                            }
                            break;
                        }
                    default: break;
                }
            }
        }

        private async Task<ObservableCollection<OrderModel>> GetOrdersByPeriod(PeriodModel pm)
        {
            ObservableCollection<OrderModel> orders =
                new ObservableCollection<OrderModel>(await _api.GetOrdersByPeriod(pm));
            return orders;
        }
    }
}
