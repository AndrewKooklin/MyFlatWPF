using MyFlatWPF.Commands.ManagementCommand.ContactsCommand;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyFlatWPF.ViewModel.Management
{
    public class AddLinkViewModel : BaseViewModel
    {
        Style styleButton = new Style();
        Style styleButtonHover = new Style();

        public AddLinkViewModel(Button btnChooseImage,
                                Button btnAdd,
                                Button btnCancel)
        {
            Grid grid = (Grid)btnChooseImage.Parent;
            styleButton = (Style)grid.FindResource("ButtonStyle");
            styleButtonHover = (Style)grid.FindResource("ButtonHoverStyle");
            ChooseAddLinkImageCommand = new ChooseAddLinkImageCommand();
            AddLinkCommand = new AddLinkCommand();
            CancelChangeLinkCommand = new CancelChangeLinkCommand();
            AddElementsToGrid(btnChooseImage,
                              btnAdd,
                              btnCancel);
        }

        private ICommand ChooseAddLinkImageCommand { get; set; }
        private ICommand AddLinkCommand { get; set; }
        private ICommand CancelChangeLinkCommand { get; set; }

        private void AddElementsToGrid(Button btnChooseImage,
                                       Button btnAdd,
                                       Button btnCancel)
        {

            btnChooseImage.Command = ChooseAddLinkImageCommand;
            btnChooseImage.MouseEnter += Btn_mouseEnter;
            btnChooseImage.MouseLeave += Btn_mouseLeave;

            btnAdd.Command = AddLinkCommand;
            btnAdd.MouseEnter += Btn_mouseEnter;
            btnAdd.MouseLeave += Btn_mouseLeave;

            btnCancel.Command = CancelChangeLinkCommand;
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
