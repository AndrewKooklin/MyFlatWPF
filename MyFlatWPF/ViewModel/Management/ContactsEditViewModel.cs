using MyFlatWPF.Commands.ManagementCommand.ContactsCommand;
using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.HelpMethods;
using MyFlatWPF.Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyFlatWPF.ViewModel.Management
{
    public class ContactsEditViewModel : BaseViewModel
    {
        StackPanel _spEditContacts;
        ContactModel _contacts;
        APIRenderingRepository _api = new APIRenderingRepository();
        APIManagementRepository _apiManage = new APIManagementRepository();
        Style styleButton = new Style();
        Style styleHoverButton = new Style();
        Style styleCircleButton = new Style();
        Style styleHoverCircleButton = new Style();
        private ImageConverter _ic = new ImageConverter();

        public ContactsEditViewModel(TextBox tbAddress,
                                     TextBox tbPhone,
                                     TextBox tbEmail,
                                     Button btnChangeContacts,
                                     Button btnAddLink,
                                     StackPanel spSocialLinks)
        {
            _spEditContacts = spSocialLinks;
            _contacts = new ContactModel();
            _contacts = _api.GetContactsFromDB();
            tbAddress.Text = _contacts.ContactAddress;
            tbPhone.Text = _contacts.ContactPhone;
            tbEmail.Text = _contacts.ContactEmail;
            ChangeContactsCommand = new ChangeContactsCommand();
            OpenAddLinkCommand = new OpenAddLinkCommand();
            OpenChangeSocialLinkCommand = new OpenChangeSocialLinkCommand();
            DeleteSocialLinkCommand = new DeleteSocialLinkCommand();
            AddElementsWrapPanel(_spEditContacts);
            btnChangeContacts.Command = ChangeContactsCommand;
            btnChangeContacts.MouseEnter += Btn_mouseEnter;
            btnChangeContacts.MouseLeave += Btn_mouseLeave;
            btnAddLink.Command = OpenAddLinkCommand;
            btnAddLink.MouseEnter += Btn_mouseEnter;
            btnAddLink.MouseLeave += Btn_mouseLeave;
        }

        private ICommand ChangeContactsCommand { get; set; }

        private ICommand OpenAddLinkCommand { get; set; }

        private ICommand OpenChangeSocialLinkCommand { get; set; }

        private ICommand DeleteSocialLinkCommand { get; set; }

        private void AddElementsWrapPanel(StackPanel spEditContacts)
        {
            Grid gContactsEdit = (Grid)spEditContacts.Parent;
            styleButton = (Style)gContactsEdit.FindResource("ButtonStyle");
            styleHoverButton = (Style)gContactsEdit.FindResource("ButtonHoverStyle");
            styleCircleButton = (Style)gContactsEdit.FindResource("ButtonCircleStyle");
            styleHoverCircleButton = (Style)gContactsEdit.FindResource("HoverButtonCircleStyle");

            List<SocialModel> lsocial = new List<SocialModel>();
            lsocial = _api.GetSocialLinksFromDB();

            foreach (SocialModel social in lsocial)
            {
                StackPanel spSocial = new StackPanel();
                spSocial.Orientation = Orientation.Horizontal;
                spSocial.HorizontalAlignment = HorizontalAlignment.Left;
                spSocial.Margin = new Thickness(0, 0, 0, 10);

                Image img = new Image();
                img.Source = _ic.ByteArrayToImage(social.SocialImage);
                img.Width = 30;
                img.Height = 30;
                img.Stretch = Stretch.Fill;
                spSocial.Children.Add(img);

                TextBlock tblock = new TextBlock();
                tblock.OverridesDefaultStyle = true;
                tblock.Text = social.SocialLink;
                tblock.HorizontalAlignment = HorizontalAlignment.Center;
                tblock.Width = 200;
                tblock.Height = 25;
                tblock.FontSize = 12;
                tblock.FontWeight = FontWeights.DemiBold;
                tblock.Background = Brushes.LightGray;
                tblock.Margin = new Thickness(5, 0, 0, 0);
                tblock.Padding = new Thickness(3, 3, 3, 3);
                tblock.TextWrapping = TextWrapping.Wrap;
                spSocial.Children.Add(tblock);

                Button btnOpenChange = new Button();
                btnOpenChange.Content = "🖉";
                btnOpenChange.ToolTip = "Change link";
                btnOpenChange.OverridesDefaultStyle = true;
                btnOpenChange.HorizontalAlignment = HorizontalAlignment.Left;
                btnOpenChange.Margin = new Thickness(5, 0, 0, 0);
                btnOpenChange.Style = styleCircleButton;
                btnOpenChange.MouseEnter += BtnCircle_mouseEnter;
                btnOpenChange.MouseLeave += BtnCircle_mouseLeave;
                btnOpenChange.Command = OpenChangeSocialLinkCommand;
                btnOpenChange.CommandParameter = social.Id;
                spSocial.Children.Add(btnOpenChange);

                Button btnDelete = new Button();
                btnDelete.Content = "✖";
                btnDelete.ToolTip = "Delete link";
                btnDelete.OverridesDefaultStyle = true;
                btnDelete.HorizontalAlignment = HorizontalAlignment.Left;
                btnDelete.Margin = new Thickness(5, 0, 0, 0);
                btnDelete.Style = styleCircleButton;
                btnDelete.MouseEnter += BtnCircle_mouseEnter;
                btnDelete.MouseLeave += BtnCircle_mouseLeave;
                btnDelete.Command = DeleteSocialLinkCommand;
                btnDelete.CommandParameter = social.Id;
                spSocial.Children.Add(btnDelete);

                spEditContacts.Children.Add(spSocial);
            }
        }

        private void Btn_mouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;
                btnMenu.Style = styleHoverButton;
                btnMenu.OverridesDefaultStyle = true;
                btnMenu.Cursor = Cursors.Hand;
                btnMenu.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#0082ff"));
            }
        }

        private void Btn_mouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;
                btnMenu.Style = styleButton;
                btnMenu.OverridesDefaultStyle = true;
                btnMenu.Cursor = Cursors.Hand;
                btnMenu.Background = Brushes.DeepSkyBlue;
            }
        }

        private void BtnCircle_mouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;
                btnMenu.Style = styleHoverCircleButton;
                btnMenu.OverridesDefaultStyle = true;
                btnMenu.Cursor = Cursors.Hand;
                btnMenu.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#0082ff"));
            }
        }

        private void BtnCircle_mouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;
                btnMenu.Style = styleCircleButton;
                btnMenu.OverridesDefaultStyle = true;
                btnMenu.Cursor = Cursors.Hand;
                btnMenu.Background = Brushes.DeepSkyBlue;
            }
        }
    }
}
