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

namespace MyFlatWPF.ViewModel
{
    public class ProjectsViewModel : BaseViewModel
    {
        public ProjectsViewModel()
        {

        }

        private WrapPanel _wrapPanel;

        public ProjectsViewModel(WrapPanel wrapPanel)
        {
            _wrapPanel = wrapPanel;

            GetProjectCards(_wrapPanel);

            OpenProjectDetailsCommand = new OpenProjectDetailsCommand();
        }

        public ICommand GetProjectCardsCommand { get; set; }

        public ICommand OpenProjectDetailsCommand { get; set; }

        public void GetProjectCards(WrapPanel wrapPanel)
        {
            for (int i = 0; i < 6; i++)
            {
                Border border = new Border();
                border.Height = 128;
                border.Width = 160;
                border.BorderBrush = Brushes.Black;
                border.BorderThickness = new Thickness(1,1,1,1);
                Panel.SetZIndex(border, 5);
                border.Margin = new System.Windows.Thickness(10, 10, 0, 0);

                StackPanel spCard = new StackPanel();
                spCard.Orientation = Orientation.Vertical;
                spCard.Height = 128;
                spCard.Width = 160;
                Panel.SetZIndex(spCard, 4);
                
                TextBlock tbId = new TextBlock();
                tbId.Visibility = System.Windows.Visibility.Collapsed;
                tbId.Text = "1";
                Panel.SetZIndex(tbId, 3);
                spCard.Children.Add(tbId);

                Image image = new Image();
                //image.Height = 130;
                image.Width = 160;
                image.Margin = new System.Windows.Thickness(0, 0, 0, 0);
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri(@"C:\repos\MyFlatWPF\MyFlatWPF\Images\i1.jpg", UriKind.Absolute);
                src.EndInit();
                image.Source = src;
                image.Stretch = System.Windows.Media.Stretch.Uniform;
                Panel.SetZIndex(image, 2);
                spCard.Children.Add(image);

                Button btnProject = new Button();
                btnProject.Height = 31;
                btnProject.Width = 160;
                btnProject.BorderThickness = new System.Windows.Thickness(0, 0, 0, 0);
                btnProject.Background = Brushes.Transparent;
                btnProject.BorderBrush = Brushes.Transparent;
                btnProject.MouseEnter += btn_mouseEnter;
                btnProject.MouseLeave += btn_mouseLeave;
                btnProject.FontSize = 14;
                btnProject.FontWeight = FontWeights.SemiBold;
                btnProject.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                btnProject.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                btnProject.Content = "Details";
                btnProject.OverridesDefaultStyle = true;
                Panel.SetZIndex(btnProject, 1);

                ObjectModel project = new ObjectModel();
                project.TypeObject = "project";
                project.IdObject = tbId.Text;
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
            btn.BorderThickness = new System.Windows.Thickness(0, 0, 0, 0);
            btn.OverridesDefaultStyle = true;
            btn.Background = Brushes.Transparent;
            btn.BorderBrush = Brushes.Transparent;
            btn.Foreground = Brushes.Black;
        }
    }
}
