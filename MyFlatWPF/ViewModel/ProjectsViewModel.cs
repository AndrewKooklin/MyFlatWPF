﻿using System;
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

        private StackPanel _stackPanel;

        public ProjectsViewModel(StackPanel stackPanel)
        {
            _stackPanel = stackPanel;

            GetProjectCards(_stackPanel);

            OpenProjectDetailsCommand = new OpenProjectDetailsCommand();
        }

        

        public ICommand GetProjectCardsCommand { get; set; }

        public ICommand OpenProjectDetailsCommand { get; set; }

        public void GetProjectCards(StackPanel stackPanel)
        {
            WrapPanel wpProject = new WrapPanel();
            wpProject.Orientation = Orientation.Horizontal;
            //wpProject.Margin = new System.Windows.Thickness(0, 0, 5, 0);

            for (int i = 0; i < 6; i++)
            {
                Border border = new Border();
                border.Height = 120;
                border.BorderBrush = Brushes.Black;
                border.BorderThickness = new Thickness(1,1,1,1);
                //border.Margin = new System.Windows.Thickness(10, 10, 0, 0);

                StackPanel spCard = new StackPanel();
                spCard.Orientation = Orientation.Vertical;
                spCard.Height = 120;
                spCard.Margin = new System.Windows.Thickness(10, 10, 0, 0);
                spCard.Children.Add(border);

                StackPanel spCardProj = new StackPanel();
                spCardProj.Orientation = Orientation.Vertical;

                TextBlock tbId = new TextBlock();
                tbId.Visibility = System.Windows.Visibility.Collapsed;
                tbId.Text = "1";
                spCard.Children.Add(tbId);

                Image image = new Image();
                //image.Height = 130;
                image.Width = 148;
                image.Margin = new System.Windows.Thickness(0, 0, 0, 0);
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
                btnProject.FontWeight = FontWeights.SemiBold;
                btnProject.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                btnProject.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                btnProject.Content = "Details";
                //MainWindow mainWindow = App.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                //OpenProjectDetailsCommand = new SwitchViewCommand((MainWindowViewModel)mainWindow.DataContext);
                btnProject.Command = OpenProjectDetailsCommand;
                ObjectModel project = new ObjectModel();
                project.TypeObject = "project";
                project.IdObject = tbId.Text;
                btnProject.CommandParameter = project;
                btnProject.Cursor = Cursors.Hand;

                spCardProj.Children.Add(btnProject);
                
                border.Child = spCardProj;
                wpProject.Children.Add(spCard);
            }
            stackPanel.Children.Add(wpProject);
        }
    }
}
