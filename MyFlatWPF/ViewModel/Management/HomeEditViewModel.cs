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
        WrapPanel _wrapPanel;
        APIManagementRepository _api = new APIManagementRepository();

        public HomeEditViewModel()
        {

            ChangeNameLinkCommand = new ChangeNameLinkCommand();
            AddElementsTopMenuLinks(_wrapPanel);
        }

        public HomeEditViewModel(WrapPanel wrapPpanel)
        {
            _wrapPanel = wrapPpanel;
            ChangeNameLinkCommand = new ChangeNameLinkCommand();
            AddElementsTopMenuLinks(_wrapPanel);
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

                TextBox tbox = new TextBox();
                tbox.Width = 100;
                tbox.FontSize = 12;
                sp.Children.Add(tbox);

                Border brd = new Border();
                brd.Width = 20;
                brd.Height = 20;

                Button btn = new Button();
                btn.Background = Brushes.LightSkyBlue;
                btn.Command = ChangeNameLinkCommand;
                btn.CommandParameter = link.Id;

                brd.Child = btn;
                sp.Children.Add(brd);
                _wrapPanel.Children.Add(sp);
            }
        }

        private List<TopMenuLinkNameModel> GetTopLinks()
        {
            return _api.GetTopLinks();
        }
    }
}
