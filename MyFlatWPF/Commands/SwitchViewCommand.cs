﻿using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.HelpMethods;
using MyFlatWPF.Model;
using MyFlatWPF.View;
using MyFlatWPF.ViewModel;
using System;
using System.Windows.Input;

namespace MyFlatWPF.Commands
{
    public class SwitchViewCommand : ICommand
    {
        private ObjectModel _objectModel;

        public event EventHandler CanExecuteChanged;

        private APIRenderingRepository _api = new APIRenderingRepository();

        private ImageConverter ic = new ImageConverter();

        public SwitchViewCommand(MainWindowViewModel mainWindowViewModel)
        {
            StaticViewModel.MainViewModel = mainWindowViewModel;
        }

        public SwitchViewCommand(ObjectModel objectModel)
        {
            _objectModel = objectModel;
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
                    case "btnManagement":
                        {
                            App.ManagementWindow.Show();
                            App.MainWindow.Hide();
                            break;
                        }
                    case "HomePicture":
                    case "btnHome":
                        {
                            App.HomeView = new HomeView();
                            App.HomeView.Visibility = System.Windows.Visibility.Visible;
                            StaticViewModel.MainViewModel.CurrentView = App.HomeView;
                            StaticViewModel.MainViewModel.RandomPhrase = 
                                StaticViewModel.MainViewModel.GetHeaderString();
                            break;
                        }
                    case "btnProjects":
                    case "btnBackToProjects":
                        {
                            App.ProjectsView = new ProjectsView();
                            App.ProjectsView.Visibility = System.Windows.Visibility.Visible;
                            StaticViewModel.MainViewModel.CurrentView = App.ProjectsView;
                            StaticViewModel.MainViewModel.RandomPhrase =
                                StaticViewModel.MainViewModel.GetHeaderString();
                            break;
                        }
                    case "btnServices":
                        {
                            App.ServicesView = new ServicesView();
                            App.ServicesView.Visibility = System.Windows.Visibility.Visible;
                            StaticViewModel.MainViewModel.CurrentView = App.ServicesView;
                            StaticViewModel.MainViewModel.RandomPhrase =
                                StaticViewModel.MainViewModel.GetHeaderString();
                            break;
                        }
                    case "btnBlog":
                    case "btnBackToBlog":
                        {
                            App.BlogView = new BlogView();
                            App.BlogView.Visibility = System.Windows.Visibility.Visible;
                            StaticViewModel.MainViewModel.CurrentView = App.BlogView;
                            StaticViewModel.MainViewModel.RandomPhrase =
                                StaticViewModel.MainViewModel.GetHeaderString();
                            break;
                        }
                    case "btnContacts":
                        {
                            App.ContactsView = new ContactsView();
                            App.ContactsView.Visibility = System.Windows.Visibility.Visible;
                            StaticViewModel.MainViewModel.CurrentView = App.ContactsView;
                            StaticViewModel.MainViewModel.RandomPhrase =
                                StaticViewModel.MainViewModel.GetHeaderString();
                            break;
                        }
                    case "btnLogIn":
                    case "btnRedirectToLogin":
                        {
                            App.LoginView.Visibility = System.Windows.Visibility.Visible;
                            StaticViewModel.MainViewModel.CurrentView = App.LoginView;
                            StaticViewModel.MainViewModel.RandomPhrase =
                                StaticViewModel.MainViewModel.GetHeaderString();
                            break;
                        }
                    case "btnRegister":
                    case "btnRedirectToRegistration":
                        {
                            App.RegistrationView.Visibility = System.Windows.Visibility.Visible;
                            StaticViewModel.MainViewModel.CurrentView = App.RegistrationView;
                            StaticViewModel.MainViewModel.RandomPhrase =
                                StaticViewModel.MainViewModel.GetHeaderString();
                            break;
                        }
                    default: break;
                }
            }
            else if(parameter is ObjectModel)
            {
                var values = (ObjectModel)parameter;
                int id = values.IdObject;
                string typeValue = values.TypeObject.ToString();

                switch (typeValue)
                {
                    case "project":
                        {
                            ProjectModel project = new ProjectModel();
                            project = _api.GetProjectById(id);
                            App.ProjectDetailView.tbProjectName.Text = project.ProjectHeader;
                            App.ProjectDetailView.tbProjectDescription.Text = project.ProjectDescription;
                            App.ProjectDetailView.iProjectImage.Source = ic.ByteArrayToImage(project.ProjectImage);

                            App.ProjectDetailView.Visibility = System.Windows.Visibility.Visible;
                            StaticViewModel.MainViewModel.CurrentView = App.ProjectDetailView;
                            break;
                        }
                    case "post":
                        {
                            PostModel post = new PostModel();
                            post = _api.GetPostById(id);
                            App.PostDetailView.tbPostName.Text = post.PostHeader;
                            App.PostDetailView.tbPostDescription.Text = post.PostDescription;
                            App.PostDetailView.iPostImage.Source = ic.ByteArrayToImage(post.PostImage);
                            App.PostDetailView.Visibility = System.Windows.Visibility.Visible;
                            StaticViewModel.MainViewModel.CurrentView = App.PostDetailView;
                            break;
                        }
                    default: break;
                }
            }
        }
    }
}
