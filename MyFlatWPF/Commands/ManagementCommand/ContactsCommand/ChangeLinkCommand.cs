using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.HelpMethods;
using MyFlatWPF.Model;
using MyFlatWPF.View.ManagementView.ContactsView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.ContactsCommand
{
    public class ChangeLinkCommand : ICommand
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
                SocialModel social = new SocialModel();
                social.Id = id;
                social.SocialLink = App.LinkEditView.tbContentEdit.Text;
                social.SocialImage = StaticImage.NewSocialLinkImage;
                bool result = await _api.ChangeSocial(social);
                if (result)
                {
                    App.LinkEditView.iLinkImage.Source = null;
                    App.LinkEditView.tbContentEdit.Text = "";
                    App.LinkEditView.tblImageName.Text = "Image not choosed";
                    StaticImage.NewSocialLinkImage = null;

                    App.ContactsEditView = null;
                    App.ContactsEditView = new ContactsEditView();
                    App.ContactsEditView.Visibility = System.Windows.Visibility.Visible;
                    StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                        App.ContactsEditView;
                }
            }
        }
    }
}
