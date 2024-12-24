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
    public class ServiceEditViewModel : BaseViewModel
    {
        private Grid _grid;
        Style styleBorder = new Style();
        Style styleButton = new Style();
        Style styleButtonHover = new Style();
        Style styleTextBox = new Style();
        APIManagementRepository _api = new APIManagementRepository();
        private ImageConverter _ic = new ImageConverter();

        public ServiceEditViewModel(TextBox tbHeader,
                                    TextBox tbContent,
                                    Button btnChange,
                                    Button btnCancel,
                                    int id)
        {
            Grid grid = (Grid)tbHeader.Parent;
            styleBorder = (Style)grid.FindResource("BorderStyle");
            styleButton = (Style)grid.FindResource("ButtonStyle");
            styleButtonHover = (Style)grid.FindResource("ButtonHoverStyle");
            styleTextBox = (Style)grid.FindResource("InputTextBox");
            ChangeServiceCommand = new ChangeServiceCommand();
            CancelChangeServiceCommand = new CancelChangeServiceCommand();
            AddElementsToGrid(tbHeader,
                              tbContent,
                              btnChange,
                              btnCancel,
                              id);
        }

        private ICommand ChangeServiceCommand { get; set; }
        private ICommand CancelChangeServiceCommand { get; set; }

        private void AddElementsToGrid(TextBox tbHeader,
                                       TextBox tbContent,
                                       Button btnChange,
                                       Button btnCancel,
                                       int id)
        {
            ServiceModel service = GetServiceByIdFromDB(id);

            tbHeader.Text = service.ServiceName;

            tbContent.Text = service.ServiceDescription;

            btnChange.Command = ChangeServiceCommand;
            btnChange.CommandParameter = id;
            btnChange.MouseEnter += Btn_mouseEnter;
            btnChange.MouseLeave += Btn_mouseLeave;

            btnCancel.Command = CancelChangeServiceCommand;
            btnCancel.MouseEnter += Btn_mouseEnter;
            btnCancel.MouseLeave += Btn_mouseLeave;

        }

        private ServiceModel GetServiceByIdFromDB(int id)
        {
            return _api.GetServiceById(id);
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
