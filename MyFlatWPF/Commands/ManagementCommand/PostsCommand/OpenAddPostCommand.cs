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
    public class OpenAddPostCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            App.AddPostView = null;
            App.AddPostView = new AddPostView();
            AddPostViewModel pevm =
                    new AddPostViewModel(App.AddPostView.btnChooseImage,
                                            App.AddPostView.btnAddProject,
                                            App.AddPostView.btnCancel);
            App.AddProjectView.Visibility = System.Windows.Visibility.Visible;
            StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                App.AddPostView;
        }
    }
}
