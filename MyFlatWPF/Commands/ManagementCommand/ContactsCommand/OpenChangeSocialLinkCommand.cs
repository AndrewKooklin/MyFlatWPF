using MyFlatWPF.View.ManagementView.ContactsView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.ContactsCommand
{
    public class OpenChangeSocialLinkCommand : ICommand
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

                App.LinkEditView = null;
                App.LinkEditView = new LinkEditView();
                LinkEditViewModel pevm =
                    new LinkEditViewModel(App.LinkEditView.iLinkImage, 
                                          App.LinkEditView.tbContentEdit,
                                          App.LinkEditView.btnChooseImage,
                                          App.LinkEditView.tblImageName,
                                          App.LinkEditView.btnEditLink,
                                          App.LinkEditView.btnCancel,
                                          id);

                App.LinkEditView.Visibility = System.Windows.Visibility.Visible;
                StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                    App.LinkEditView;
            }
        }
    }
}
