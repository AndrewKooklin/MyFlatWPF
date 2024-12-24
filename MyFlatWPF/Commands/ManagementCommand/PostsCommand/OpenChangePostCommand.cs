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
    public class OpenChangePostCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

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
            else
            {
                int id = (Int32)parameter;

                App.PostEditView = null;
                App.PostEditView = new PostEditView();
                PostEditViewModel pevm =
                    new PostEditViewModel(App.PostEditView.tbHeaderEdit,
                                             App.PostEditView.tbContentEdit,
                                             App.PostEditView.iPostImage,
                                             App.PostEditView.btnChooseImage,
                                             App.PostEditView.tblImageName,
                                             App.PostEditView.btnChange,
                                             App.PostEditView.btnCancel,
                                             id);

                App.PostEditView.Visibility = System.Windows.Visibility.Visible;
                StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                    App.PostEditView;
            }
        }
    }
}
