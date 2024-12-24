using MyFlatWPF.HelpMethods;
using MyFlatWPF.View.ManagementView.ContactsView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.ContactsCommand
{
    public class CancelChangeLinkCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            StaticImage.NewSocialLinkImage = null;
            App.LinkEditView.tblImageName.Text = "Image not choosed";
            App.AddLinkView.tblImageName.Text = "Image not choosed";
            App.LinkEditView.iLinkImage.Source = null;
            App.AddLinkView.iLinkImage.Source = null;
            App.ContactsEditView = null;
            App.ContactsEditView = new ContactsEditView();
            App.ContactsEditView.Visibility = System.Windows.Visibility.Visible;
            StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                App.ContactsEditView;
        }
    }
}
