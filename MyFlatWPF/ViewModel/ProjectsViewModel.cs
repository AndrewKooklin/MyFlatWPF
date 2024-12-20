using System;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using MyFlatWPF.Model;
using Prism.Commands;
using System.Windows.Media;
using System.Windows;
using MyFlatWPF.Commands;
using MyFlatWPF.HelpMethods;
using MyFlatWPF.Data.Repositories.API;

namespace MyFlatWPF.ViewModel
{
    public class ProjectsViewModel : BaseViewModel
    {
        APIRenderingRepository _api = new APIRenderingRepository();
        List<ProjectModel> lpm = new List<ProjectModel>();
        ImageConverter ic = new ImageConverter();

        public ProjectsViewModel()
        {

        }

        private WrapPanel _wrapPanel;

        public ProjectsViewModel(WrapPanel wrapPanel)
        {
            _wrapPanel = wrapPanel;
            lpm = GetProjects();

            GetProjectCards(_wrapPanel);
        }

        public ICommand GetProjectCardsCommand { get; set; }

        public ICommand OpenProjectDetailsCommand { get; set; }

        public void GetProjectCards(WrapPanel wrapPanel)
        {
            foreach (ProjectModel pm in lpm)
            {
                Border border = new Border();
                border.Height = 140;
                border.Width = 180;
                border.BorderBrush = Brushes.Black;
                border.BorderThickness = new Thickness(1,1,1,1);
                Panel.SetZIndex(border, 5);
                border.Margin = new System.Windows.Thickness(10, 10, 0, 0);

                StackPanel spCard = new StackPanel();
                spCard.Orientation = Orientation.Vertical;
                spCard.Height = 140;
                spCard.Width = 180;
                Panel.SetZIndex(spCard, 4);
                
                TextBlock tbId = new TextBlock();
                tbId.Visibility = System.Windows.Visibility.Collapsed;
                tbId.Text = pm.Id.ToString();
                Panel.SetZIndex(tbId, 3);
                spCard.Children.Add(tbId);

                Image image = new Image();
                //image.Height = 130;
                image.Width = 180;
                image.Margin = new System.Windows.Thickness(0, 0, 0, 0);
                BitmapImage src = new BitmapImage();
                src = ic.ByteArrayToImage(pm.ProjectImage);
                image.Source = src;
                image.Stretch = System.Windows.Media.Stretch.Uniform;
                Panel.SetZIndex(image, 2);
                spCard.Children.Add(image);

                Button btnProject = new Button();
                btnProject.Height = 31;
                btnProject.Width = 180;
                btnProject.BorderThickness = new Thickness(0, 0, 0, 0);
                btnProject.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ececec"));
                btnProject.BorderBrush = Brushes.Transparent;
                btnProject.MouseEnter += btn_mouseEnter;
                btnProject.MouseLeave += btn_mouseLeave;
                btnProject.FontSize = 14;
                btnProject.FontWeight = FontWeights.SemiBold;
                btnProject.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#2235ef"));
                btnProject.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                btnProject.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                btnProject.Content = pm.ProjectHeader;
                btnProject.ToolTip = "Project details";
                btnProject.OverridesDefaultStyle = true;
                //Panel.SetZIndex(btnProject, 1);

                ObjectModel project = new ObjectModel();
                project.TypeObject = "project";
                project.IdObject = Int32.Parse(tbId.Text);
                OpenProjectDetailsCommand = new SwitchViewCommand(project);
                btnProject.Command = OpenProjectDetailsCommand;
                
                btnProject.CommandParameter = project;
                btnProject.Cursor = Cursors.Hand;

                spCard.Children.Add(btnProject);
                border.Child = spCard;
                //
                Panel.SetZIndex(wrapPanel, 6);
                wrapPanel.Children.Add(border);
            }
        }

        private void btn_mouseEnter(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            e.Handled = true;
            StackPanel btnParent = (StackPanel)btn.Parent;
            Border spParent = (Border)btnParent.Parent;
            WrapPanel borderParent = (WrapPanel)spParent.Parent;
            Grid wpParent = (Grid)borderParent.Parent;
            Style styleButton = (Style)wpParent.FindResource("HoverButtonStyle");

            btn.BorderThickness = new System.Windows.Thickness(0, 0, 0, 0);
            btn.OverridesDefaultStyle = true;
            btn.Style = styleButton;
            btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#34b4ff"));
            btn.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#34b4ff"));
            btn.Foreground = Brushes.White;
        }

        private void btn_mouseLeave(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            e.Handled = true;
            btn.BorderThickness = new Thickness(0, 0, 0, 0);
            btn.OverridesDefaultStyle = true;
            btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ececec"));
            btn.BorderBrush = Brushes.Transparent;
            btn.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#2235ef"));
        }

        private List<ProjectModel> GetProjects()
        {
            List<ProjectModel> lp = new List<ProjectModel>();
            lp = _api.GetProjectsFromDB();
            return lp;
        }
    }
}
