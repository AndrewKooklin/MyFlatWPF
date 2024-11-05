using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.HelpMethods;
using MyFlatWPF.Model;
using MyFlatWPF.View;
using MyFlatWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            StaticMainViewModel.MainViewModel = mainWindowViewModel;
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
                            App.ManagementWindow = new ManagementWindow();
                            App.ManagementWindow.Show();
                            App.MainWindow.Close();
                            break;
                        }
                    case "HomePicture":
                    case "btnHome":
                        {
                            App.HomeWiew.Visibility = System.Windows.Visibility.Visible;
                            StaticMainViewModel.MainViewModel.CurrentView = App.HomeWiew;
                            StaticMainViewModel.MainViewModel.RandomPhrase = 
                                StaticMainViewModel.MainViewModel.GetHeaderString();
                            break;
                        }
                    case "btnProjects":
                    case "btnBackToProjects":
                        {
                            App.ProjectsWiew.Visibility = System.Windows.Visibility.Visible;
                            StaticMainViewModel.MainViewModel.CurrentView = App.ProjectsWiew;
                            StaticMainViewModel.MainViewModel.RandomPhrase =
                                StaticMainViewModel.MainViewModel.GetHeaderString();
                            break;
                        }
                    case "btnServices":
                        {
                            App.ServicesWiew.Visibility = System.Windows.Visibility.Visible;
                            StaticMainViewModel.MainViewModel.CurrentView = App.ServicesWiew;
                            StaticMainViewModel.MainViewModel.RandomPhrase =
                                StaticMainViewModel.MainViewModel.GetHeaderString();
                            break;
                        }
                    case "btnBlog":
                    case "btnBackToBlog":
                        {
                            App.BlogWiew.Visibility = System.Windows.Visibility.Visible;
                            StaticMainViewModel.MainViewModel.CurrentView = App.BlogWiew;
                            StaticMainViewModel.MainViewModel.RandomPhrase =
                                StaticMainViewModel.MainViewModel.GetHeaderString();
                            break;
                        }
                    case "btnContacts":
                        {
                            App.ContactsWiew.Visibility = System.Windows.Visibility.Visible;
                            StaticMainViewModel.MainViewModel.CurrentView = App.ContactsWiew;
                            StaticMainViewModel.MainViewModel.RandomPhrase =
                                StaticMainViewModel.MainViewModel.GetHeaderString();
                            break;
                        }
                    case "btnLogIn":
                        {


                            StaticMainViewModel.MainViewModel.RandomPhrase =
                                StaticMainViewModel.MainViewModel.GetHeaderString();
                            break;
                        }
                    case "btnRegister":
                        {


                            StaticMainViewModel.MainViewModel.RandomPhrase =
                                StaticMainViewModel.MainViewModel.GetHeaderString();
                            break;
                        }
                    case "btnLogOut":
                        {


                            StaticMainViewModel.MainViewModel.RandomPhrase =
                                StaticMainViewModel.MainViewModel.GetHeaderString();
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
                            App.ProjectDetailWiew.tbProjectName.Text = project.ProjectHeader;
                            App.ProjectDetailWiew.tbProjectDescription.Text = project.ProjectDescription;
                            App.ProjectDetailWiew.iProjectImage.Source = ic.ByteArrayToImage(project.ProjectImage);

                            App.ProjectDetailWiew.Visibility = System.Windows.Visibility.Visible;
                            StaticMainViewModel.MainViewModel.CurrentView = App.ProjectDetailWiew;
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
                            StaticMainViewModel.MainViewModel.CurrentView = App.PostDetailView;
                            break;
                        }
                    default: break;
                }
            }
        }


    }
}
