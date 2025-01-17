using MyFlatWPF.Commands.ManagementCommand.ContactsCommand;
using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.HelpMethods;
using MyFlatWPF.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyFlatWPF.ViewModel.Management
{
    class LinkEditViewModel : BaseViewModel
    {
        Style styleButton = new Style();
        Style styleButtonHover = new Style();
        APIManagementRepository _api = new APIManagementRepository();
        private ImageConverter _ic = new ImageConverter();

        public LinkEditViewModel(Image image, 
                                 TextBox tbContent,
                                 Button btnChooseImage,
                                 TextBlock tblImageName,
                                 Button btnChange,
                                 Button btnCancel,
                                 int id)
        {
            Grid grid = (Grid)tbContent.Parent;
            styleButton = (Style)grid.FindResource("ButtonStyle");
            styleButtonHover = (Style)grid.FindResource("ButtonHoverStyle");
            ChooseLinkImageCommand = new ChooseLinkImageCommand();
            ChangeLinkCommand = new ChangeLinkCommand();
            CancelChangeLinkCommand = new CancelChangeLinkCommand();
            AddElementsToGrid(tbContent,
                              image,
                              btnChooseImage,
                              tblImageName,
                              btnChange,
                              btnCancel,
                              id);
        }

        private ICommand ChooseLinkImageCommand { get; set; }
        private ICommand ChangeLinkCommand { get; set; }
        private ICommand CancelChangeLinkCommand { get; set; }

        private void AddElementsToGrid(TextBox tbContent,
                                       Image image,
                                       Button btnChooseImage,
                                       TextBlock tblImageName,
                                       Button btnChange,
                                       Button btnCancel,
                                       int id)
        {
            SocialModel social = GetSocialLinkByIdFromDB(id);

            tbContent.Text = social.SocialLink;

            image.Source = _ic.ByteArrayToImage(social.SocialImage);
            StaticImage.NewSocialLinkImage = social.SocialImage;

            btnChooseImage.Command = ChooseLinkImageCommand;
            btnChooseImage.CommandParameter = tblImageName;
            btnChooseImage.MouseEnter += Btn_mouseEnter;
            btnChooseImage.MouseLeave += Btn_mouseLeave;

            btnChange.Command = ChangeLinkCommand;
            btnChange.CommandParameter = id;
            btnChange.MouseEnter += Btn_mouseEnter;
            btnChange.MouseLeave += Btn_mouseLeave;

            btnCancel.Command = CancelChangeLinkCommand;
            btnCancel.MouseEnter += Btn_mouseEnter;
            btnCancel.MouseLeave += Btn_mouseLeave;
        }

        private SocialModel GetSocialLinkByIdFromDB(int id)
        {
            return _api.GetSocialById(id);
        }

        private void Btn_mouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;
                btnMenu.Style = styleButtonHover;
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
    }
}
