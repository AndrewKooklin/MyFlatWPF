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

namespace MyFlatWPF.ViewModel
{
    public class ProjectsViewModel : BaseViewModel
    {
        public ProjectsViewModel()
        {

        }

        private StackPanel _stackPanel;

        public ProjectsViewModel(StackPanel stackPanel)
        {
            _stackPanel = stackPanel;

            GetProjectCards(_stackPanel);
        }

        

        public ICommand GetProjectCardsCommand { get; set; }

        public ICommand OpenProjectDetailsCommand { get; set; }

        public void GetProjectCards(StackPanel stackPanel)
        {
            WrapPanel wpProject = new WrapPanel();
            wpProject.Orientation = Orientation.Horizontal;
            wpProject.Margin = new System.Windows.Thickness(20, 10, 0, 10);

            for (int i = 0; i < 6; i++)
            {
                Border border = new Border();
                border.BorderBrush = Brushes.Black;
                border.BorderThickness = new Thickness(1,1,1,1);

                StackPanel spCard = new StackPanel();
                spCard.Orientation = Orientation.Vertical;
                spCard.Height = 165;
                spCard.Margin = new System.Windows.Thickness(10, 10, 0, 0);
                spCard.Children.Add(border);

                StackPanel spCardProj = new StackPanel();
                spCardProj.Orientation = Orientation.Vertical;

                //TextBlock tbId = new TextBlock();
                //tbId.Visibility = System.Windows.Visibility.Collapsed;
                //tbId.Text = "Id Project";
                //spCard.Children.Add(tbId);

                Image image = new Image();
                image.Height = 130;
                image.Width = 150;
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri(@"C:\repos\MyFlatWPF\MyFlatWPF\Images\i1.jpg", UriKind.Absolute);
                src.EndInit();
                image.Source = src;
                image.Stretch = System.Windows.Media.Stretch.Uniform;

                spCardProj.Children.Add(image);

                Button btnProject = new Button();
                btnProject.Height = 30;
                btnProject.Width = 150;
                btnProject.Background = Brushes.Transparent;
                btnProject.BorderBrush = Brushes.Transparent;
                btnProject.FontSize = 14;
                btnProject.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                btnProject.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                btnProject.Content = "Details";
                btnProject.Command = OpenProjectDetailsCommand;
                //btnProject.CommandParameter = tbId.Text;
                btnProject.Cursor = Cursors.Hand;

                spCardProj.Children.Add(btnProject);
                
                border.Child = spCardProj;
                wpProject.Children.Add(spCard);
            }
            stackPanel.Children.Add(wpProject);
        }
    }
}
