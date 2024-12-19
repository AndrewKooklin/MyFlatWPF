using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.HelpMethods;
using MyFlatWPF.Model;
using MyFlatWPF.Commands.ManagementCommand.ProjectsCommand;
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
    public class ProjectsEditViewModel : BaseViewModel
    {
        WrapPanel _wpEditProjects;
        APIRenderingRepository _api = new APIRenderingRepository();
        APIManagementRepository _apiManage = new APIManagementRepository();
        Style styleCircleButton = new Style();
        Style styleTextBox = new Style();
        private ImageConverter _ic = new ImageConverter();
        public ProjectsEditViewModel(WrapPanel wpEditProjects)
        {
            _wpEditProjects = wpEditProjects;
            OpenChangeProjectCommand = new OpenChangeProjectCommand();
            DeleteProjectCommand = new DeleteProjectCommand();
            AddElementsWrapPanel(_wpEditProjects);

        }

        private ICommand OpenChangeProjectCommand { get; set; }

        private ICommand DeleteProjectCommand { get; set; }

        private void AddElementsWrapPanel(WrapPanel wpEditProjects)
        {
            List<ProjectModel> lp = new List<ProjectModel>();
            lp = _api.GetProjectsFromDB();

            foreach (ProjectModel project in lp)
            {
                StackPanel sp = new StackPanel();
                sp.Orientation = Orientation.Vertical;
                sp.HorizontalAlignment = HorizontalAlignment.Left;
                sp.Width = 130;
                sp.Height = 100;
                sp.Margin = new Thickness(0, 0, 5, 0);

                StackPanel spMenuLinksParent = (StackPanel)wpEditProjects.Parent;
                Grid gHomeEdit = (Grid)spMenuLinksParent.Parent;
                styleCircleButton = (Style)gHomeEdit.FindResource("ButtonCircleStyle");
                styleTextBox = (Style)gHomeEdit.FindResource("InputTextBox");

                Image img = new Image();
                img.Source = _ic.ByteArrayToImage(project.ProjectImage);
                img.Width = 130;
                img.Height = 100;
                img.Stretch = Stretch.Fill;

                TextBlock tblock = new TextBlock();
                tblock.OverridesDefaultStyle = true;
                tblock.Text = project.ProjectHeader;
                tblock.HorizontalAlignment = HorizontalAlignment.Center;
                tblock.Width = 100;
                tblock.FontSize = 12;
                tblock.FontWeight = FontWeights.DemiBold;
                sp.Children.Add(tblock);

                StackPanel spButtons = new StackPanel();
                spButtons.Name = $"sp{project.Id}";
                spButtons.Orientation = Orientation.Horizontal;
                spButtons.HorizontalAlignment = HorizontalAlignment.Right;

                Button btnOpenChange = new Button();
                btnOpenChange.Content = "&#128393;";
                btnOpenChange.ToolTip = "Change project";
                btnOpenChange.OverridesDefaultStyle = true;
                btnOpenChange.HorizontalAlignment = HorizontalAlignment.Right;
                btnOpenChange.Margin = new Thickness(0, 5, 1, 0);
                btnOpenChange.Style = styleCircleButton;
                btnOpenChange.Command = OpenChangeProjectCommand;
                btnOpenChange.CommandParameter = project.Id;
                spButtons.Children.Add(btnOpenChange);

                Button btnDelete = new Button();
                btnDelete.Content = "&#10060;";
                btnDelete.ToolTip = "Delete project";
                btnDelete.OverridesDefaultStyle = true;
                btnDelete.HorizontalAlignment = HorizontalAlignment.Right;
                btnDelete.Margin = new Thickness(5, 5, 1, 0);
                btnDelete.Style = styleCircleButton;
                btnDelete.Command = DeleteProjectCommand;
                btnDelete.CommandParameter = project.Id;
                spButtons.Children.Add(btnDelete);

                sp.Children.Add(spButtons);
                wpEditProjects.Children.Add(sp);
            }
        }
    }
}
