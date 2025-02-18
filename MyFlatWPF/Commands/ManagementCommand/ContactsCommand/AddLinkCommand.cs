﻿using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.HelpMethods;
using MyFlatWPF.Model;
using MyFlatWPF.View.ManagementView.ContactsView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.ContactsCommand
{
    public class AddLinkCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        APIManagementRepository _api = new APIManagementRepository();

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            SocialModel social = new SocialModel();
            if (String.IsNullOrEmpty(App.AddLinkView.tbContentEdit.Text) ||
                StaticImage.NewSocialLinkImage == null)
            {
                return;
            }
            else
            {
                social.SocialImage = StaticImage.NewSocialLinkImage;
                social.SocialLink = App.AddLinkView.tbContentEdit.Text;

                bool result = await _api.AddSocialToDB(social);
                if (result)
                {
                    App.AddLinkView.iLinkImage.Source = null;
                    App.AddLinkView.tbContentEdit.Text = "";
                    App.AddProjectView.tblImageName.Text = "Image not choosed";
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
