using MyFlatWPF.Commands.ManagementCommand.ProjectCommand;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyFlatWPF.ViewModel.Management
{
    public class AddProjectViewModel : BaseViewModel
    {
        Style styleButton = new Style();
        Style styleButtonHover = new Style();

        public AddProjectViewModel(Button btnChooseImage,
                                   Button btnChange,
                                   Button btnCancel)
        {
            Grid grid = (Grid)btnChooseImage.Parent;
            styleButton = (Style)grid.FindResource("ButtonStyle");
            styleButtonHover = (Style)grid.FindResource("ButtonHoverStyle");
            ChooseAddProjectImageCommand = new ChooseAddProjectImageCommand();
            AddProjectCommand = new AddProjectCommand();
            CancelChangeProjectCommand = new CancelChangeProjectCommand();
            AddElementsToGrid(btnChooseImage,
                              btnChange,
                              btnCancel);
        }

        private ICommand ChooseAddProjectImageCommand { get; set; }
        private ICommand AddProjectCommand { get; set; }
        private ICommand CancelChangeProjectCommand { get; set; }

        private void AddElementsToGrid(Button btnChooseImage,
                                       Button btnAdd,
                                       Button btnCancel)
        {
            btnChooseImage.Command = ChooseAddProjectImageCommand;
            btnChooseImage.MouseEnter += Btn_mouseEnter;
            btnChooseImage.MouseLeave += Btn_mouseLeave;

            btnAdd.Command = AddProjectCommand;
            btnAdd.MouseEnter += Btn_mouseEnter;
            btnAdd.MouseLeave += Btn_mouseLeave;

            btnCancel.Command = CancelChangeProjectCommand;
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
