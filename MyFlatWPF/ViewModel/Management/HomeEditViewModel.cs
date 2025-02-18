﻿using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using MyFlatWPF.Model;
using MyFlatWPF.Data.Repositories.API;
using System.Windows.Input;
using MyFlatWPF.Commands.ManagementCommand;
using MyFlatWPF.HelpMethods;

namespace MyFlatWPF.ViewModel.Management
{
    public class HomeEditViewModel : BaseViewModel
    {
        WrapPanel _wpMenuLinks;
        WrapPanel _wpRandomPrases;
        APIRenderingRepository _api = new APIRenderingRepository();
        APIManagementRepository _apiManage = new APIManagementRepository();
        HomePagePlaceholderModel _hpphm = new HomePagePlaceholderModel();
        Style styleButton = new Style();
        Style styleHoverButton = new Style();
        Style styleTextBox = new Style(); 
        private ImageConverter _ic = new ImageConverter();

        public HomeEditViewModel()
        {
            ChangeNameLinkCommand = new ChangeNameLinkCommand();
            AddRandomPhraseCommand = new AddRandomPhraseCommand();
            AddElementsTopMenuLinks(_wpMenuLinks);
        }

        public HomeEditViewModel(WrapPanel wpMenuLinks,
                                 Button btnAddPhrase,
                                 WrapPanel wpRandomPrases,
                                 Image image,
                                 TextBlock tbImageName,
                                 Button btnChooseImage,
                                 Button btnSaveNewImage,
                                 TextBox tbInputCentral,
                                 Button btnChangeCentralAreaHeader,
                                 TextBox tbInputBottomHeader,
                                 Button btnChangeBottomHeader,
                                 TextBox tbInputBottomContent,
                                 Button btnChangeBottomContent)
        {
            _wpMenuLinks = wpMenuLinks;
            _wpRandomPrases = wpRandomPrases;
            ChangeNameLinkCommand = new ChangeNameLinkCommand();
            AddRandomPhraseCommand = new AddRandomPhraseCommand();
            btnAddPhrase.Command = AddRandomPhraseCommand;
            ChangeRandomPhraseCommand = new ChangeRandomPhraseCommand();
            DeleteRandomPhraseCommand = new DeleteRandomPhraseCommand();
            ChooseMainImageCommand = new ChooseMainImageCommand();
            btnChooseImage.Command = ChooseMainImageCommand;
            btnChooseImage.CommandParameter = tbImageName;
            SaveMainImageCommand = new SaveMainImageCommand();
            btnSaveNewImage.Command = SaveMainImageCommand;
            SaveImageParameters _sip= new SaveImageParameters{ NewImage = image, Text = tbImageName };
            btnSaveNewImage.CommandParameter = _sip;
            ChangeCentralAreaHeaderCommand = new ChangeCentralAreaHeaderCommand();
            btnChangeCentralAreaHeader.Command = ChangeCentralAreaHeaderCommand;
            btnChangeCentralAreaHeader.CommandParameter = tbInputCentral;
            _hpphm = _api.GetHomePagePlaceholder();
            AddElementsTopMenuLinks(_wpMenuLinks);
            AddElementsRandomPhrases(_wpRandomPrases);
            GetHomePageImage(image);
            tbInputCentral.Text = _hpphm.LeftCentralAreaText;
            tbInputBottomHeader.Text = _hpphm.BottomAreaHeader;
            tbInputBottomContent.Text = _hpphm.BottomAreaContent;
            ChangeBottomHeaderCommand = new ChangeBottomHeaderCommand();
            btnChangeBottomHeader.Command = ChangeBottomHeaderCommand;
            btnChangeBottomHeader.CommandParameter = tbInputBottomHeader;
            ChangeBottomContentCommand = new ChangeBottomContentCommand();
            btnChangeBottomContent.Command = ChangeBottomContentCommand;
            btnChangeBottomContent.CommandParameter = tbInputBottomContent;
            StaticManagementViewModel.EditViewModel = this;
        }

        private void GetHomePageImage(Image image)
        {
            image.Source = _ic.ByteArrayToImage(_hpphm.MainPicture);
            image.Stretch = Stretch.Fill;
        }

        private ICommand ChangeNameLinkCommand { get; set; }

        private ICommand AddRandomPhraseCommand { get; set; }

        private ICommand ChangeRandomPhraseCommand { get; set; }

        private ICommand DeleteRandomPhraseCommand { get; set; }

        private ICommand ChooseMainImageCommand { get; set; }

        private ICommand SaveMainImageCommand { get; set; }

        private ICommand ChangeCentralAreaHeaderCommand { get; set; }

        private ICommand ChangeBottomHeaderCommand { get; set; }

        private ICommand ChangeBottomContentCommand { get; set; }

        public void AddElementsTopMenuLinks(WrapPanel wrapPanel)
        {
            StackPanel spMenuLinksParent = (StackPanel)_wpMenuLinks.Parent;
            Grid gHomeEdit = (Grid)spMenuLinksParent.Parent;
            styleButton = (Style)gHomeEdit.FindResource("ButtonStyle");
            styleHoverButton = (Style)gHomeEdit.FindResource("ButtonHoverStyle");
            styleTextBox = (Style)gHomeEdit.FindResource("InputTextBox");

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
                btn.MouseEnter += Btn_mouseEnter;
                btn.MouseLeave += Btn_mouseLeave;

                sp.Children.Add(btn);
                _wpMenuLinks.Children.Add(sp);
            }
        }

        public void AddElementsRandomPhrases(WrapPanel wpRandomPrases)
        {
            List<RandomPhraseModel> rpm = new List<RandomPhraseModel>();
            rpm = _apiManage.GetRandomPhrasesFromDB();

            foreach (RandomPhraseModel phrase in rpm)
            {
                StackPanel spRandomPhrases = new StackPanel();
                spRandomPhrases.Name = $"sp{phrase.Id}";
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
                btnChange.MouseEnter += Btn_mouseEnter;
                btnChange.MouseLeave += Btn_mouseLeave;
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
                btnDelete.MouseEnter += Btn_mouseEnter;
                btnDelete.MouseLeave += Btn_mouseLeave;
                spButtons.Children.Add(btnDelete);

                spRandomPhrases.Children.Add(spButtons);
                _wpRandomPrases.Children.Add(spRandomPhrases);
            }
        }

        private string _phrase;
        public string Phrase
        {
            get
            {
                return _phrase;
            }
            set
            {
                _phrase = value;
                OnPropertyChanged(nameof(Phrase));
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
    }
}
