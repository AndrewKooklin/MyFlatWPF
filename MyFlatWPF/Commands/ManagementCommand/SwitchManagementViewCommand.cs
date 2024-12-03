using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.View.ManagementView;
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
                            App.HomeEditView = new HomeEditView();
                            App.AllOrdersView.Visibility = System.Windows.Visibility.Visible;
                            StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                                App.HomeEditView;
                            break;
                        }
                    //case "btnProjects":
                    //case "btnBackToProjects":
                    //    {
                    //        App.ProjectsView.Visibility = System.Windows.Visibility.Visible;
                    //        StaticMainViewModel.MainViewModel.CurrentView = App.ProjectsView;
                    //        StaticMainViewModel.MainViewModel.RandomPhrase =
                    //            StaticMainViewModel.MainViewModel.GetHeaderString();
                    //        break;
                    //    }
                    //case "btnServices":
                    //    {
                    //        App.ServicesView.Visibility = System.Windows.Visibility.Visible;
                    //        StaticMainViewModel.MainViewModel.CurrentView = App.ServicesView;
                    //        StaticMainViewModel.MainViewModel.RandomPhrase =
                    //            StaticMainViewModel.MainViewModel.GetHeaderString();
                    //        break;
                    //    }
                    //case "btnBlog":
                    //case "btnBackToBlog":
                    //    {
                    //        App.BlogView.Visibility = System.Windows.Visibility.Visible;
                    //        StaticMainViewModel.MainViewModel.CurrentView = App.BlogView;
                    //        StaticMainViewModel.MainViewModel.RandomPhrase =
                    //            StaticMainViewModel.MainViewModel.GetHeaderString();
                    //        break;
                    //    }
                    //case "btnContacts":
                    //    {
                    //        App.ContactsView.Visibility = System.Windows.Visibility.Visible;
                    //        StaticMainViewModel.MainViewModel.CurrentView = App.ContactsView;
                    //        StaticMainViewModel.MainViewModel.RandomPhrase =
                    //            StaticMainViewModel.MainViewModel.GetHeaderString();
                    //        break;
                    //    }
                    //case "btnLogIn":
                    //case "btnRedirectToLogin":
                    //    {
                    //        App.LoginView.Visibility = System.Windows.Visibility.Visible;
                    //        StaticMainViewModel.MainViewModel.CurrentView = App.LoginView;
                    //        StaticMainViewModel.MainViewModel.RandomPhrase =
                    //            StaticMainViewModel.MainViewModel.GetHeaderString();
                    //        break;
                    //    }
                    //case "btnRegister":
                    //case "btnRedirectToRegistration":
                    //    {
                    //        App.RegistrationView.Visibility = System.Windows.Visibility.Visible;
                    //        StaticMainViewModel.MainViewModel.CurrentView = App.RegistrationView;
                    //        StaticMainViewModel.MainViewModel.RandomPhrase =
                    //            StaticMainViewModel.MainViewModel.GetHeaderString();
                    //        break;
                    //    }
                    default: break;
                }
            }
            //else if (parameter is ObjectModel)
            //{
            //    var values = (ObjectModel)parameter;
            //    int id = values.IdObject;
            //    string typeValue = values.TypeObject.ToString();

            //    switch (typeValue)
            //    {
            //        case "project":
            //            {
            //                ProjectModel project = new ProjectModel();
            //                project = _api.GetProjectById(id);
            //                App.ProjectDetailView.tbProjectName.Text = project.ProjectHeader;
            //                App.ProjectDetailView.tbProjectDescription.Text = project.ProjectDescription;
            //                App.ProjectDetailView.iProjectImage.Source = ic.ByteArrayToImage(project.ProjectImage);

            //                App.ProjectDetailView.Visibility = System.Windows.Visibility.Visible;
            //                StaticMainViewModel.MainViewModel.CurrentView = App.ProjectDetailView;
            //                break;
            //            }
            //        case "post":
            //            {
            //                PostModel post = new PostModel();
            //                post = _api.GetPostById(id);
            //                App.PostDetailView.tbPostName.Text = post.PostHeader;
            //                App.PostDetailView.tbPostDescription.Text = post.PostDescription;
            //                App.PostDetailView.iPostImage.Source = ic.ByteArrayToImage(post.PostImage);

            //                App.PostDetailView.Visibility = System.Windows.Visibility.Visible;
            //                StaticMainViewModel.MainViewModel.CurrentView = App.PostDetailView;
            //                break;
            //            }
            //        default: break;
            //    }
            //}
        }
    }
}
