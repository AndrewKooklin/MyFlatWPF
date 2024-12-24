using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.View.ManagementView;
using MyFlatWPF.View.ManagementView.BlogView;
using MyFlatWPF.View.ManagementView.ServicesView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand
{
    public class SwitchManagementViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        APIManagementRepository _api = new APIManagementRepository();

        public SwitchManagementViewCommand(ManagementWindowViewModel mwvm)
        {
            StaticManagementViewModel.ManagementViewModel = mwvm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter == null)
            {
                return;
            }

            if (parameter is string)
            {

                switch (parameter.ToString())
                {
                    case "btnLinkToHome":
                        {
                            App.ManagementWindow.Hide();
                            App.MainWindow.Activate();
                            App.MainWindow.Focus();
                            App.MainWindow.Show();
                            break;
                        }
                    case "btnOrdersByServices":
                        {
                            App.OrdersByServicesView = new OrdersByServicesView();
                            App.OrdersByServicesView.Visibility = System.Windows.Visibility.Visible;
                            StaticManagementViewModel.ManagementViewModel.CurrentManagementView = 
                                App.OrdersByServicesView;
                            break;
                        }
                    case "btnOrdersByPeriod":
                        {
                            App.AllOrdersView = new AllOrdersView();
                            App.AllOrdersView.Visibility = System.Windows.Visibility.Visible;
                            StaticManagementViewModel.ManagementViewModel.CurrentManagementView = 
                                App.AllOrdersView;
                            break;
                        }
                    case "btnHomeEdit":
                        {
                            App.HomeEditView = null;
                            App.HomeEditView = new HomeEditView();
                            App.HomeEditView.Visibility = System.Windows.Visibility.Visible;
                            StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                                App.HomeEditView;
                            break;
                        }
                    case "btnProjectsEdit":
                        {
                            App.ProjectsEditView = null;
                            App.ProjectsEditView = new ProjectsEditView();
                            App.ProjectsEditView.Visibility = System.Windows.Visibility.Visible;
                            StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                                App.ProjectsEditView;
                            break;
                        }
                    case "btnServicesEdit":
                        {
                            App.ServicesEditView = null;
                            App.ServicesEditView = new ServicesEditView();
                            App.ServicesEditView.Visibility = System.Windows.Visibility.Visible;
                            StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                                App.ServicesEditView;
                            break;
                        }
                    case "btnBlogEdit":
                        {
                            App.PostsEditView = null;
                            App.PostsEditView = new PostsEditView();
                            App.PostsEditView.Visibility = System.Windows.Visibility.Visible;
                            StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                                App.PostsEditView;
                            break;
                        }
                    case "btnContactsEdit":
                        {
                            App.ContastsEditView = null;
                            App.ContastsEditView = new PostsEditView();
                            App.ContastsEditView.Visibility = System.Windows.Visibility.Visible;
                            StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                                App.ContastsEditView;
                            break;
                        }
                    default: break;
                }
            }
        }
    }
}
