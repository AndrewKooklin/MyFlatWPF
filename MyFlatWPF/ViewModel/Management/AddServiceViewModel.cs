using MyFlatWPF.Commands.ManagementCommand.ServicesCommand;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyFlatWPF.ViewModel.Management
{
    public class AddServiceViewModel : BaseViewModel
    {
        Style styleButton = new Style();
        Style styleButtonHover = new Style();

        public AddServiceViewModel(Button btnChange,
                                   Button btnCancel)
        {
            Grid grid = (Grid)btnChange.Parent;
            styleButton = (Style)grid.FindResource("ButtonStyle");
            styleButtonHover = (Style)grid.FindResource("ButtonHoverStyle");
            AddServiceCommand = new AddServiceCommand();
            CancelChangeServiceCommand = new CancelChangeServiceCommand();
            AddElementsToGrid(btnChange,
                              btnCancel);
        }

        private ICommand AddServiceCommand { get; set; }
        private ICommand CancelChangeServiceCommand { get; set; }

        private void AddElementsToGrid(Button btnAdd,
                                       Button btnCancel)
        {
            btnAdd.Command = AddServiceCommand;
            btnAdd.MouseEnter += Btn_mouseEnter;
            btnAdd.MouseLeave += Btn_mouseLeave;

            btnCancel.Command = CancelChangeServiceCommand;
            btnCancel.MouseEnter += Btn_mouseEnter;
            btnCancel.MouseLeave += Btn_mouseLeave;

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
