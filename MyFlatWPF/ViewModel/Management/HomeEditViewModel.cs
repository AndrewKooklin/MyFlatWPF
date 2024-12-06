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

namespace MyFlatWPF.ViewModel.Management
{
    public class HomeEditViewModel : BaseViewModel
    {
        WrapPanel _wpMenuLinks;
        WrapPanel _wpRandomPrases;
        APIManagementRepository _api = new APIManagementRepository();

        public HomeEditViewModel()
        {

            ChangeNameLinkCommand = new ChangeNameLinkCommand();
            AddElementsTopMenuLinks(_wpMenuLinks);
        }

        public HomeEditViewModel(WrapPanel wpMenuLinks, 
                                 WrapPanel wpRandomPrases)
        {
            _wpMenuLinks = wpMenuLinks;
            _wpRandomPrases = wpRandomPrases;
            ChangeNameLinkCommand = new ChangeNameLinkCommand();
            AddElementsTopMenuLinks(_wpMenuLinks);
            AddElementsRandomPhrases(_wpRandomPrases);
        }

        private ICommand ChangeNameLinkCommand { get; set; }

        public void AddElementsTopMenuLinks(WrapPanel wrapPanel)
        {
            List<TopMenuLinkNameModel> ltml = new List<TopMenuLinkNameModel>();
            ltml = GetTopLinks();

            foreach(TopMenuLinkNameModel link in ltml)
            {
                StackPanel sp = new StackPanel();
                sp.Orientation = Orientation.Vertical;
                sp.HorizontalAlignment = HorizontalAlignment.Right;
                sp.Margin = new Thickness(5, 0, 0, 0);

                StackPanel spMenuLinksParent = (StackPanel)_wpMenuLinks.Parent;
                Grid gHomeEdit = (Grid)spMenuLinksParent.Parent;
                Style btnStyle = (Style)gHomeEdit.FindResource("ButtonStyle");
                Style tbInput = (Style)gHomeEdit.FindResource("InputTextBox");

                TextBox tbox = new TextBox();
                tbox.OverridesDefaultStyle = true;
                tbox.Style = tbInput;
                tbox.Text = link.LinkName;
                //tbox.HorizontalAlignment = HorizontalAlignment.Right;
                tbox.Width = 80;
                tbox.FontSize = 12;
                sp.Children.Add(tbox);

                //Border brd = new Border();
                //brd.Width = 20;
                //brd.Height = 20;
                

                Button btn = new Button();
                btn.Content = "Change";
                btn.ToolTip = "Change name";
                btn.OverridesDefaultStyle = true;
                btn.HorizontalAlignment = HorizontalAlignment.Right;
                btn.Margin = new Thickness(0, 5, 1, 0);
                btn.Style = btnStyle;
                btn.Command = ChangeNameLinkCommand;
                btn.CommandParameter = link.Id;

                //brd.Child = btn;
                sp.Children.Add(btn);
                _wpMenuLinks.Children.Add(sp);
            }
        }

        private List<TopMenuLinkNameModel> GetTopLinks()
        {
            return _api.GetTopLinks();
        }


        private void AddElementsRandomPhrases(WrapPanel wpRandomPrases)
        {
            List<RandomPhraseModel> rpm = new List<RandomPhraseModel>();
            rpm = GetRandomPhrases();

            foreach (RandomPhraseModel phrase in rpm)
            {
                StackPanel spRandomPhrases = new StackPanel();
                spRandomPhrases.Orientation = Orientation.Vertical;
                spRandomPhrases.HorizontalAlignment = HorizontalAlignment.Right;
                spRandomPhrases.Margin = new Thickness(5, 0, 0, 0);

                StackPanel spMenuLinksParent = (StackPanel)_wpMenuLinks.Parent;
                Grid gHomeEdit = (Grid)spMenuLinksParent.Parent;
                Style btnStyle = (Style)gHomeEdit.FindResource("ButtonStyle");
                Style tbInput = (Style)gHomeEdit.FindResource("InputTextBox");

                TextBox tbox = new TextBox();
                tbox.OverridesDefaultStyle = true;
                tbox.Style = tbInput;
                tbox.Text = phrase.Phrase;
                tbox.Width = 80;
                tbox.FontSize = 12;
                spRandomPhrases.Children.Add(tbox);

                Button btn = new Button();
                btn.Content = "Change";
                btn.ToolTip = "Change phrase";
                btn.OverridesDefaultStyle = true;
                btn.HorizontalAlignment = HorizontalAlignment.Right;
                btn.Margin = new Thickness(0, 5, 1, 0);
                btn.Style = btnStyle;
                btn.Command = ChangeNameLinkCommand;
                btn.CommandParameter = phrase.Id;

                spRandomPhrases.Children.Add(btn);
                _wpRandomPrases.Children.Add(sp);
            }
        }

        private List<RandomPhraseModel> GetRandomPhrases()
        {
            return _api.GetRandomPhrasesFromDB();
        }
    }
}
