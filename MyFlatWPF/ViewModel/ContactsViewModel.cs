using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.HelpMethods;
using MyFlatWPF.Model;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyFlatWPF.ViewModel
{
    public class ContactsViewModel : BaseViewModel
    {
        ContactModel _cm = new ContactModel();
        APIRenderingRepository _api = new APIRenderingRepository();
        StackPanel _sp = new StackPanel();
        List<SocialModel> _lsm = new List<SocialModel>();
        ImageConverter _ic = new ImageConverter();

        public ContactsViewModel(StackPanel sp)
        {
            _cm = GetContacts();
            Address = _cm.ContactAddress;
            Phone = _cm.ContactPhone;
            Email = _cm.ContactEmail;
            _lsm = GetSocialLinks();
            RenderingSocialLinks(sp);
        }

        private ContactModel GetContacts()
        {
            return _api.GetContactsFromDB();
        }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        private List<SocialModel> GetSocialLinks()
        {
            return _api.GetSocialLinksFromDB();
        }

        private void RenderingSocialLinks(StackPanel sp)
        {
            foreach(SocialModel sm in _lsm)
            {
                Border bdr = new Border();
                bdr.Margin = new System.Windows.Thickness(10, 0, 0, 0);
                bdr.BorderBrush = Brushes.White;
                bdr.BorderThickness = new System.Windows.Thickness(0, 0, 0, 0);

                Image img = new Image();
                img.Cursor = Cursors.Hand;
                img.MouseDown += Img_MouseDown;
                img.Width = 32;
                img.Height = 32;
                img.ToolTip = sm.SocialLink;
                img.Margin = new System.Windows.Thickness(0, 0, 0, 0);
                img.Source = _ic.ByteArrayToImage(sm.SocialImage);

                bdr.Child = img;

                sp.Children.Add(bdr);
            }
        }

        private void Img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(sender is Image)
            {
                Image img = (Image)sender;
                string url = img.ToolTip.ToString();
                var sInfo = new System.Diagnostics.ProcessStartInfo(url)
                { 
                    UseShellExecute = true,
                };
                System.Diagnostics.Process.Start(sInfo);
                //open link to browser by default
            }
        }
    }
}
