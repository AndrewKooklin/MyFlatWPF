using MyFlatWPF.Commands.ManagementCommand.ServicesCommand;
using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.HelpMethods;
using MyFlatWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyFlatWPF.ViewModel.Management
{
    public class ServicesEditViewModel : BaseViewModel
    {
        WrapPanel _wpEditServices;
        APIRenderingRepository _api = new APIRenderingRepository();
        APIManagementRepository _apiManage = new APIManagementRepository();
        Style styleButton = new Style();
        Style styleHoverButton = new Style();
        Style styleCircleButton = new Style();
        Style styleHoverCircleButton = new Style();
        private ImageConverter _ic = new ImageConverter();
        public ServicesEditViewModel(WrapPanel wpEditServices,
                                     Button btnAdd)
        {
            _wpEditServices = wpEditServices;
            OpenAddServiceCommand = new OpenAddServiceCommand();
            OpenChangeServiceCommand = new OpenChangeServiceCommand();
            DeleteServiceCommand = new DeleteServiceCommand();
            AddElementsWrapPanel(_wpEditServices);
            btnAdd.Command = OpenAddServiceCommand;
            btnAdd.MouseEnter += Btn_mouseEnter;
            btnAdd.MouseLeave += Btn_mouseLeave;

        }


        private ICommand OpenAddServiceCommand { get; set; }

        private ICommand OpenChangeServiceCommand { get; set; }

        private ICommand DeleteServiceCommand { get; set; }

        private void AddElementsWrapPanel(WrapPanel wpEditServices)
        {
            List<ServiceModel> ls = new List<ServiceModel>();
            ls = _api.GetServicesFromDB();

            foreach (ServiceModel service in ls)
            {
                StackPanel sp = new StackPanel();
                sp.Orientation = Orientation.Vertical;
                sp.HorizontalAlignment = HorizontalAlignment.Left;
                //sp.Width = 130;
                sp.Margin = new Thickness(0, 10, 0, 10);

                Grid gServicesEdit = (Grid)wpEditServices.Parent;
                styleButton = (Style)gServicesEdit.FindResource("ButtonStyle");
                styleHoverButton = (Style)gServicesEdit.FindResource("ButtonHoverStyle");
                styleCircleButton = (Style)gServicesEdit.FindResource("ButtonCircleStyle");
                styleHoverCircleButton = (Style)gServicesEdit.FindResource("HoverButtonCircleStyle");

                StackPanel spService = new StackPanel();
                spService.Orientation = Orientation.Horizontal;
                spService.HorizontalAlignment = HorizontalAlignment.Left;
                spService.Margin = new Thickness(0, 0, 0, 5);

                Border border = new Border();
                border.BorderThickness = new Thickness(1, 1, 1, 1);
                border.BorderBrush = Brushes.Blue;
                
                TextBlock tblock = new TextBlock();
                tblock.OverridesDefaultStyle = true;
                tblock.Text = service.ServiceName;
                tblock.HorizontalAlignment = HorizontalAlignment.Center;
                tblock.Width = 150;
                tblock.FontSize = 12;
                tblock.FontWeight = FontWeights.DemiBold;
                tblock.Background = Brushes.LightSkyBlue;
                tblock.Padding = new Thickness(5, 5, 5, 5);
                border.Child = tblock;
                spService.Children.Add(border);

                Button btnOpenChange = new Button();
                btnOpenChange.Content = "🖉";
                btnOpenChange.ToolTip = "Change service";
                btnOpenChange.OverridesDefaultStyle = true;
                btnOpenChange.HorizontalAlignment = HorizontalAlignment.Left;
                btnOpenChange.Margin = new Thickness(5, 0, 0, 0);
                btnOpenChange.Style = styleCircleButton;
                btnOpenChange.MouseEnter += BtnCircle_mouseEnter;
                btnOpenChange.MouseLeave += BtnCircle_mouseLeave;
                btnOpenChange.Command = OpenChangeServiceCommand;
                btnOpenChange.CommandParameter = service.Id;
                spService.Children.Add(btnOpenChange);

                Button btnDelete = new Button();
                btnDelete.Content = "✖";
                btnDelete.ToolTip = "Delete service";
                btnDelete.OverridesDefaultStyle = true;
                btnDelete.HorizontalAlignment = HorizontalAlignment.Left;
                btnDelete.Margin = new Thickness(5, 0, 0, 0);
                btnDelete.Style = styleCircleButton;
                btnDelete.MouseEnter += BtnCircle_mouseEnter;
                btnDelete.MouseLeave += BtnCircle_mouseLeave;
                btnDelete.Command = DeleteServiceCommand;
                btnDelete.CommandParameter = service.Id;
                spService.Children.Add(btnDelete);

                sp.Children.Add(spService);
                wpEditServices.Children.Add(sp);
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
