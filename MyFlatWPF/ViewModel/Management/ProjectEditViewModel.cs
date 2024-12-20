﻿using MyFlatWPF.Commands.ManagementCommand.ProjectCommand;
using MyFlatWPF.Data.Repositories.API;
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
    public class ProjectEditViewModel : BaseViewModel
    {
        private Grid _grid;
        Style styleBorder = new Style();
        Style styleButton = new Style();
        Style styleButtonHover = new Style();
        Style styleTextBox = new Style();
        APIManagementRepository _api = new APIManagementRepository();

        public ProjectEditViewModel(TextBox tbHeader,
                                    TextBox tbContent,
                                    Button btnChooseImage,
                                    TextBlock tblImageName,
                                    Button btnChange,
                                    Button btnCancel,
                                    int id)
        {
            Grid grid = (Grid)tbHeader.Parent;
            styleBorder = (Style)grid.FindResource("BorderStyle");
            styleButton = (Style)grid.FindResource("ButtonStyle");
            styleButtonHover = (Style)grid.FindResource("ButtonHoverStyle");
            styleTextBox = (Style)grid.FindResource("InputTextBox");
            ChooseProjectImageCommand = new ChooseProjectImageCommand();
            ChangeProjectCommand = new ChangeProjectCommand();
            AddElementsToGrid(tbHeader,
                              tbContent,
                              btnChooseImage,
                              tblImageName,
                              btnChange,
                              btnCancel,
                              id);
        }

        private ICommand ChooseProjectImageCommand { get; set; }
        private ICommand ChangeProjectCommand { get; set; }

        private void AddElementsToGrid(TextBox tbHeader,
                                       TextBox tbContent,
                                       Button btnChooseImage,
                                       TextBlock tblImageName,
                                       Button btnChange,
                                       Button btnCancel,
                                       int id)
        {
            ProjectModel project = GetProjectByIdFromDB(id);

            tbHeader.Text = project.ProjectHeader;

            tbContent.Text = project.ProjectDescription;

            btnChooseImage.Command = ChooseProjectImageCommand;
            btnChooseImage.CommandParameter = tblImageName;

            btnChange.Command = ChangeProjectCommand;
            btnChange.CommandParameter = id;
            btnChange.MouseEnter += Btn_mouseEnter;
            btnChange.MouseLeave += Btn_mouseLeave;

            btnCancel.MouseEnter += Btn_mouseEnter;
            btnCancel.MouseLeave += Btn_mouseLeave;

        }

        private ProjectModel GetProjectByIdFromDB(int id)
        {
            return _api.GetProjectById(id);
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
