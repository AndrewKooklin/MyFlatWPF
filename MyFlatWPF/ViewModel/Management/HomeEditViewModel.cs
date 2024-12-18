using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using MyFlatWPF.Model;
using MyFlatWPF.Data.Repositories.API;
using System.Windows.Input;
using MyFlatWPF.Commands.ManagementCommand;
using System.Windows.Media.Imaging;
using MyFlatWPF.HelpMethods;

namespace MyFlatWPF.ViewModel.Management
{
    public class HomeEditViewModel : BaseViewModel
    {
        WrapPanel _wpMenuLinks;
        WrapPanel _wpRandomPrases;
        APIRenderingRepository _api = new APIRenderingRepository();
        HomePagePlaceholderModel _hpphm = new HomePagePlaceholderModel();
        Style styleButton = new Style();
        Style styleTextBox = new Style();
        private ImageConverter _ic = new ImageConverter();

        public HomeEditViewModel()
        {
            
            ChangeNameLinkCommand = new ChangeNameLinkCommand();
            AddElementsTopMenuLinks(_wpMenuLinks);
        }

        public HomeEditViewModel(WrapPanel wpMenuLinks, 
                                 WrapPanel wpRandomPrases,
                                 Image image,
                                 TextBlock tbImageName,
                                 Button btnChooseImage,
                                 Button btnSaveNewImage,
                                 TextBox tbInputCentral,
                                 TextBox tbInputHeaderBottom,
                                 TextBox tbInputBottomContent)
        {
            _wpMenuLinks = wpMenuLinks;
            _wpRandomPrases = wpRandomPrases;
            ChangeNameLinkCommand = new ChangeNameLinkCommand();
            ChangeRandomPhraseCommand = new ChangeRandomPhraseCommand();
            ChooseMainImageCommand = new ChooseMainImageCommand();
            btnChooseImage.Command = ChooseMainImageCommand;
            btnChooseImage.CommandParameter = tbImageName;
            SaveMainImageCommand = new SaveMainImageCommand();
            btnSaveNewImage.Command = SaveMainImageCommand;
            SaveImageParameters _sip= new SaveImageParameters{ NewImage = image, Text = tbImageName };
            btnSaveNewImage.CommandParameter = _sip;
            _hpphm = _api.GetHomePagePlaceholder();
            AddElementsTopMenuLinks(_wpMenuLinks);
            AddElementsRandomPhrases(_wpRandomPrases);
            GetHomePageImage(image);
            tbInputCentral.Text = _hpphm.LeftCentralAreaText;
            tbInputHeaderBottom.Text = _hpphm.BottomAreaHeader;
            tbInputBottomContent.Text = _hpphm.BottomAreaContent;
        }

        private void GetHomePageImage(Image image)
        {
            image.Source = _ic.ByteArrayToImage(_hpphm.MainPicture);
            image.Stretch = Stretch.Fill;
        }

        private ICommand ChangeNameLinkCommand { get; set; }

        private ICommand ChangeRandomPhraseCommand { get; set; }

        private ICommand DeleteRandomPhraseCommand { get; set; }

        private ICommand ChooseMainImageCommand { get; set; }

        private ICommand SaveMainImageCommand { get; set; }

        public void AddElementsTopMenuLinks(WrapPanel wrapPanel)
        {
            List<TopMenuLinkNameModel> ltml = new List<TopMenuLinkNameModel>();
            var placeHolder = _api.GetHomePagePlaceholder();
            ltml = placeHolder.LinkNames;

            foreach(TopMenuLinkNameModel link in ltml)
            {
                StackPanel sp = new StackPanel();
                sp.Name = $"sp{link.Id}";
                sp.Orientation = Orientation.Vertical;
                sp.HorizontalAlignment = HorizontalAlignment.Right;
                sp.Margin = new Thickness(5, 0, 0, 0);

                StackPanel spMenuLinksParent = (StackPanel)_wpMenuLinks.Parent;
                Grid gHomeEdit = (Grid)spMenuLinksParent.Parent;
                styleButton = (Style)gHomeEdit.FindResource("ButtonStyle");
                styleTextBox = (Style)gHomeEdit.FindResource("InputTextBox");

                TextBox tbox = new TextBox(); 
                tbox.OverridesDefaultStyle = true;
                tbox.Style = styleTextBox;
                tbox.Text = link.LinkName;
                tbox.Width = 80;
                tbox.FontSize = 12;
                sp.Children.Add(tbox);

                Button btn = new Button();
                btn.Content = "Change";
                btn.ToolTip = "Change name";
                btn.OverridesDefaultStyle = true;
                btn.HorizontalAlignment = HorizontalAlignment.Right;
                btn.Margin = new Thickness(0, 5, 1, 0);
                btn.Style = styleButton;
                btn.Command = ChangeNameLinkCommand;
                btn.CommandParameter = link.Id;

                sp.Children.Add(btn);
                _wpMenuLinks.Children.Add(sp);
            }
        }

        private void AddElementsRandomPhrases(WrapPanel wpRandomPrases)
        {
            List<RandomPhraseModel> rpm = new List<RandomPhraseModel>();
            rpm = _hpphm.RandomPhrases;

            foreach (RandomPhraseModel phrase in rpm)
            {
                StackPanel spRandomPhrases = new StackPanel();
                spRandomPhrases.Orientation = Orientation.Vertical;
                spRandomPhrases.HorizontalAlignment = HorizontalAlignment.Right;
                spRandomPhrases.Margin = new Thickness(0, 0, 5, 0);

                TextBox tbox = new TextBox();
                tbox.OverridesDefaultStyle = true;
                tbox.Style = styleTextBox;
                tbox.Text = phrase.Phrase;
                tbox.Width = 140;
                tbox.FontSize = 12;
                spRandomPhrases.Children.Add(tbox);

                StackPanel spButtons = new StackPanel();
                spButtons.Orientation = Orientation.Horizontal;
                spButtons.HorizontalAlignment = HorizontalAlignment.Right;
                spButtons.Margin = new Thickness(0, 5, 1, 0);

                Button btnChange = new Button();
                btnChange.Content = "Change";
                btnChange.ToolTip = "Change phrase";
                btnChange.OverridesDefaultStyle = true;
                btnChange.HorizontalAlignment = HorizontalAlignment.Right;
                btnChange.Margin = new Thickness(0, 0, 0, 5);
                btnChange.Style = styleButton;
                btnChange.Command = ChangeRandomPhraseCommand;
                btnChange.CommandParameter = phrase.Id;
                spButtons.Children.Add(btnChange);

                Button btnDelete = new Button();
                btnDelete.Content = "Delete";
                btnDelete.ToolTip = "Delete phrase";
                btnDelete.OverridesDefaultStyle = true;
                btnDelete.HorizontalAlignment = HorizontalAlignment.Right;
                btnDelete.Margin = new Thickness(5, 0, 0, 5);
                btnDelete.Style = styleButton;
                btnDelete.Command = DeleteRandomPhraseCommand;
                btnDelete.CommandParameter = phrase.Id;
                spButtons.Children.Add(btnDelete);

                spRandomPhrases.Children.Add(spButtons);
                _wpRandomPrases.Children.Add(spRandomPhrases);
            }
        }
    }
}
