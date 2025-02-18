﻿using MyFlatWPF.Commands.ManagementCommand.PostsCommand;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyFlatWPF.ViewModel.Management
{
    public class AddPostViewModel : BaseViewModel
    {
        Style styleButton = new Style();
        Style styleButtonHover = new Style();

        public AddPostViewModel(Button btnChooseImage,
                                   Button btnChange,
                                   Button btnCancel)
        {
            Grid grid = (Grid)btnChooseImage.Parent;
            styleButton = (Style)grid.FindResource("ButtonStyle");
            styleButtonHover = (Style)grid.FindResource("ButtonHoverStyle");
            ChooseAddPostImageCommand = new ChooseAddPostImageCommand();
            AddPostCommand = new AddPostCommand();
            CancelChangePostCommand = new CancelChangePostCommand();
            AddElementsToGrid(btnChooseImage,
                              btnChange,
                              btnCancel);
        }

        private ICommand ChooseAddPostImageCommand { get; set; }
        private ICommand AddPostCommand { get; set; }
        private ICommand CancelChangePostCommand { get; set; }

        private void AddElementsToGrid(Button btnChooseImage,
                                       Button btnAdd,
                                       Button btnCancel)
        {

            btnChooseImage.Command = ChooseAddPostImageCommand;
            btnChooseImage.MouseEnter += Btn_mouseEnter;
            btnChooseImage.MouseLeave += Btn_mouseLeave;

            btnAdd.Command = AddPostCommand;
            btnAdd.MouseEnter += Btn_mouseEnter;
            btnAdd.MouseLeave += Btn_mouseLeave;

            btnCancel.Command = CancelChangePostCommand;
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
