using MyFlatWPF.Commands.ManagementCommand.ProjectCommand;
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
    public class AddProjectViewModel : BaseViewModel
    {
        private Grid _grid;
        Style styleBorder = new Style();
        Style styleButton = new Style();
        Style styleButtonHover = new Style();
        Style styleTextBox = new Style();

        public AddProjectViewModel(Button btnChooseImage,
                                   Button btnChange,
                                   Button btnCancel)
        {
            Grid grid = (Grid)btnChooseImage.Parent;
            styleBorder = (Style)grid.FindResource("BorderStyle");
            styleButton = (Style)grid.FindResource("ButtonStyle");
            styleButtonHover = (Style)grid.FindResource("ButtonHoverStyle");
            styleTextBox = (Style)grid.FindResource("InputTextBox");
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
