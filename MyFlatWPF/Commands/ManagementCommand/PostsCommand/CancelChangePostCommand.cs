using MyFlatWPF.HelpMethods;
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
    public class CancelChangePostCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            StaticImage.NewPostImage = null;
            App.PostEditView.tblImageName.Text = "Image not choosed";
            App.AddPostView.tblImageName.Text = "Image not choosed";
            App.PostEditView.iPostImage.Source = null;
            App.AddPostView.iPostImage.Source = null;
            App.PostsEditView = null;
            App.PostsEditView = new PostsEditView();
            App.ProjectsEditView.Visibility = System.Windows.Visibility.Visible;
            StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                App.PostsEditView;
        }
    }
}
