using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.View.ManagementView.BlogView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.PostsCommand
{
    public class DeletePostCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        APIManagementRepository _api = new APIManagementRepository();

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
                bool result = await _api.DeletePostById(id);
                if (result)
                {
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
