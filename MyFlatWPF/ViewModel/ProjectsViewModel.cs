using System;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MyFlatWPF.ViewModel
{
    public class ProjectsViewModel : BaseViewModel
    {
        public ProjectsViewModel()
        {
            CommonDescription = "As a builder, we undertake large, complex projects, foster innovation," +
                                "\nemerging technologies, and make a difference in the community.";

            GetProjectCards();
        }

        public ProjectsViewModel(StackPanel stackPanel)
        {

        }


        public string CommonDescription { get; set; }

        public ICommand OpenProjectDetails { get; set; }

        public void GetProjectCards()
        {
            for(int i = 0; i < 7; i++)
            {
                WrapPanel wpProject = new WrapPanel();
                wpProject.Orientation = Orientation.Vertical;
                wpProject.Margin = new System.Windows.Thickness(20, 10, 0, 10);

                TextBlock tbId = new TextBlock();
                tbId.Visibility = System.Windows.Visibility.Collapsed;
                tbId.Text = "Id Project";
                
                Image image = new Image();
                image.Height = 50;
                image.Width = 80;
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri("C:\\repos\\MyFlatWPF\\MyFlatWPF\\Images\\i1.jpg", UriKind.Relative);
                src.EndInit();
                image.Source = src;
                image.Stretch = System.Windows.Media.Stretch.Uniform;

                wpProject.Children.Add(image);

                Button btnProject = new Button();
                btnProject.Height = 20;
                btnProject.Width = 80;
                btnProject.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                btnProject.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                btnProject.Content = "Details";
                btnProject.Command = OpenProjectDetails;
                btnProject.CommandParameter = tbId.Text;
                btnProject.Cursor = Cursors.Hand;

                wpProject.Children.Add(btnProject);


                //App.ProjectsWiew.spProjects.Children.Add(wpProject);
            }
        }
    }
}
