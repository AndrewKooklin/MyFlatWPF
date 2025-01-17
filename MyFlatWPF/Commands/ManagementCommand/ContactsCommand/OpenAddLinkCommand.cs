using MyFlatWPF.View.ManagementView.ContactsView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.ContactsCommand
{
    public class OpenAddLinkCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            App.AddLinkView = null;
            App.AddLinkView = new AddLinkView();
            AddLinkViewModel pevm =
                    new AddLinkViewModel(App.AddLinkView.btnChooseImage,
                                         App.AddLinkView.btnAddLink,
                                         App.AddLinkView.btnCancel);
            App.AddLinkView.Visibility = System.Windows.Visibility.Visible;
            StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                App.AddLinkView;
        }
    }
}
