﻿using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.View.ManagementView;
using MyFlatWPF.View.ManagementView.BlogView;
using MyFlatWPF.View.ManagementView.ContactsView;
using MyFlatWPF.View.ManagementView.RolesView;
using MyFlatWPF.View.ManagementView.ServicesView;
using MyFlatWPF.View.ManagementView.UsersView;
using MyFlatWPF.ViewModel.Management;
using System;
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
                            App.ContactsEditView = null;
                            App.ContactsEditView = new ContactsEditView();
                            App.ContactsEditView.Visibility = System.Windows.Visibility.Visible;
                            StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                                App.ContactsEditView;
                            break;
                        }
                    case "btnAllUsers":
                        {
                            App.AllUsersView = null;
                            App.AllUsersView = new AllUsersView();
                            App.AllUsersView.Visibility = System.Windows.Visibility.Visible;
                            StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                                App.AllUsersView;
                            break;
                        }
                    case "btnAddUser":
                        {
                            App.AddUserView.Visibility = System.Windows.Visibility.Visible;
                            StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                                App.AddUserView;
                            break;
                        }
                    case "btnRoles":
                        {
                            App.AllRolesView = null;
                            App.AllRolesView = new AllRolesView();
                            App.AllRolesView.Visibility = System.Windows.Visibility.Visible;
                            StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                                App.AllRolesView;
                            break;
                        }
                    case "btnAddRole":
                        {
                            App.AddRoleView.Visibility = System.Windows.Visibility.Visible;
                            StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                                App.AddRoleView;
                            break;
                        }
                    default: break;
                }
            }
        }
    }
}
