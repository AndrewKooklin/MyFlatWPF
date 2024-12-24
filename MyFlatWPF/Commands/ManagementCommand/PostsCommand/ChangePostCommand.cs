using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.HelpMethods;
using MyFlatWPF.Model;
using MyFlatWPF.View.ManagementView.BlogView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.PostsCommand
{
    public class ChangePostCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        APIManagementRepository _api = new APIManagementRepository();
        private ImageConverter _ic = new ImageConverter();

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            if (parameter == null)
            {
                return;
            }
            else
            {
                int id = (Int32)parameter;
                PostModel post = new PostModel();
                post.Id = id;
                post.PostHeader = App.PostEditView.tbHeaderEdit.Text;
                post.PostDescription = App.PostEditView.tbContentEdit.Text;
                post.PostImage = StaticImage.NewPostImage;
                bool result = await _api.ChangePost(post);
                if (result)
                {
                    App.PostEditView.tbHeaderEdit.Text = "";
                    App.PostEditView.iPostImage.Source = null;
                    App.PostEditView.tbContentEdit.Text = "";
                    App.PostEditView.tblImageName.Text = "Image not choosed";
                    StaticImage.NewPostImage = null;

                    App.PostsEditView = null;
                    App.PostsEditView = new PostsEditView();
                    App.ProjectsEditView.Visibility = System.Windows.Visibility.Visible;
                    StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                        App.PostsEditView;
                }
            }
        }
    }
}
