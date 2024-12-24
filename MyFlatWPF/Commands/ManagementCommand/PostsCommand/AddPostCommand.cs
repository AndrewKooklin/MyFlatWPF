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
    public class AddPostCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        APIManagementRepository _api = new APIManagementRepository();

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            PostModel post = new PostModel();
            if (String.IsNullOrEmpty(App.AddPostView.tbHeaderEdit.Text) ||
                StaticImage.NewPostImage == null ||
                String.IsNullOrEmpty(App.AddPostView.tbContentEdit.Text))
            {
                return;
            }
            else
            {
                post.PostHeader = App.AddPostView.tbHeaderEdit.Text;
                post.PostImage = StaticImage.NewPostImage;
                post.PostDescription = App.AddPostView.tbContentEdit.Text;

                bool result = await _api.AddPostToDB(post);
                if (result)
                {
                    App.AddPostView.tbHeaderEdit.Text = "";
                    App.AddPostView.iPostImage.Source = null;
                    App.AddPostView.tbContentEdit.Text = "";
                    App.AddPostView.tblImageName.Text = "Image not choosed";
                    StaticImage.NewPostImage = null;

                    App.PostsEditView = null;
                    App.PostsEditView = new PostsEditView();
                    App.PostsEditView.Visibility = System.Windows.Visibility.Visible;
                    StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                        App.PostsEditView;
                }
            }
        }
    }
}
