﻿using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.HelpMethods;
using MyFlatWPF.Model;
using MyFlatWPF.View.ManagementView;
using MyFlatWPF.ViewModel.Management;
using System;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.ProjectCommand
{
    public class ChangeProjectCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        APIManagementRepository _api = new APIManagementRepository();
        private ImageConverter _ic = new ImageConverter();

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            if(parameter == null)
            {
                return;
            }
            else
            {
                int id = (Int32)parameter;
                ProjectModel project = new ProjectModel();
                project.Id = id;
                project.ProjectHeader = App.ProjectEditView.tbHeaderEdit.Text;
                project.ProjectDescription = App.ProjectEditView.tbContentEdit.Text;
                project.ProjectImage = StaticImage.NewProjectImage;
                bool result = await _api.ChangeProject(project);
                if (result)
                {
                    App.ProjectEditView.tbHeaderEdit.Text = "";
                    App.ProjectEditView.iProjectImage.Source = null;
                    App.ProjectEditView.tbContentEdit.Text = "";
                    App.ProjectEditView.tblImageName.Text = "Image not choosed";
                    StaticImage.NewProjectImage = null;

                    App.ProjectsEditView = null;
                    App.ProjectsEditView = new ProjectsEditView();
                    App.ProjectsEditView.Visibility = System.Windows.Visibility.Visible;
                    StaticManagementViewModel.ManagementViewModel.CurrentManagementView =
                        App.ProjectsEditView;
                }
            }
        }
    }
}
