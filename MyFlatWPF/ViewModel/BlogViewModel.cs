using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MyFlatWPF.Commands;
using MyFlatWPF.HelpMethods;

namespace MyFlatWPF.ViewModel
{
    public class BlogViewModel : BaseViewModel
    {
        private WrapPanel _wrapPanel;

        public BlogViewModel(WrapPanel wrapPanel)
        {
            _wrapPanel = wrapPanel;

            GetBlogCards(_wrapPanel);

            OpenBlogDetailsCommand = new OpenBlogDetailsCommand();
        }

        public ICommand OpenBlogDetailsCommand { get; set; }

        private void GetBlogCards(WrapPanel wrapPanel)
        {
            for (int i = 0; i < 6; i++)
            {
                Border border = new Border();
                border.Height = 215;
                border.Width = 190;
                border.BorderBrush = Brushes.Black;
                border.BorderThickness = new Thickness(1, 1, 1, 1);
                //Panel.SetZIndex(border, 5);
                border.Margin = new Thickness(5, 5, 0, 0);

                StackPanel spCard = new StackPanel();
                spCard.Orientation = Orientation.Vertical;
                spCard.Height = 215;
                spCard.Width = 190;
                //Panel.SetZIndex(spCard, 4);

                TextBlock tbId = new TextBlock();
                tbId.Visibility = Visibility.Collapsed;
                tbId.Text = "1";
                //Panel.SetZIndex(tbId, 3);
                spCard.Children.Add(tbId);

                TextBlock tbDateAdded = new TextBlock();
                tbDateAdded.Text = "10.11.2024";
                tbDateAdded.Padding = new Thickness(10, 1, 0, 1);
                tbDateAdded.FontSize = 10;
                //Panel.SetZIndex(tbId, 3);
                spCard.Children.Add(tbDateAdded);

                Image image = new Image();
                //image.Height = 130;
                image.Width = 190;
                image.Margin = new Thickness(0, 0, 0, 0);
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri(@"C:\repos\MyFlatWPF\MyFlatWPF\Images\b1.jpeg", UriKind.Absolute);
                src.EndInit();
                image.Source = src;
                image.Stretch = Stretch.Uniform;
                //Panel.SetZIndex(image, 2);
                spCard.Children.Add(image);

                Button btnProject = new Button();
                btnProject.Height = 20;
                btnProject.Width = 190;
                btnProject.BorderThickness = new System.Windows.Thickness(0, 0, 0, 0);
                btnProject.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ececec"));
                btnProject.BorderBrush = Brushes.Transparent;
                btnProject.MouseEnter += btn_mouseEnter;
                btnProject.MouseLeave += btn_mouseLeave;
                btnProject.FontSize = 14;
                btnProject.FontWeight = FontWeights.SemiBold;
                btnProject.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                btnProject.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                btnProject.Content = "Details";
                btnProject.ToolTip = "Post details";
                btnProject.OverridesDefaultStyle = true;
                spCard.Children.Add(btnProject);
                //Panel.SetZIndex(btnProject, 1);

                TextBlock tbPostDescription = new TextBlock();
                tbPostDescription.Text = "As a builder, we undertake large, complex projects, " +
                    "foster innovation, embrace emerging technologies, " +
                    "and make a difference in the community.";
                tbPostDescription.Padding = new Thickness(2, 1, 2, 1);
                tbPostDescription.FontSize = 8;
                tbPostDescription.Background = Brushes.White;
                tbPostDescription.TextWrapping = TextWrapping.Wrap;
                //Panel.SetZIndex(tbId, 3);
                spCard.Children.Add(tbPostDescription);

                ObjectModel post = new ObjectModel();
                post.TypeObject = "project";
                post.IdObject = tbId.Text;
                OpenBlogDetailsCommand = new SwitchViewCommand(post);
                btnProject.Command = OpenBlogDetailsCommand;

                btnProject.CommandParameter = post;
                btnProject.Cursor = Cursors.Hand;

                
                border.Child = spCard;
                //
                //Panel.SetZIndex(wrapPanel, 6);
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
            ScrollViewer wpParent = (ScrollViewer)borderParent.Parent;
            Style styleButton = (Style)wpParent.FindResource("HoverButtonStyle");

            btn.BorderThickness = new Thickness(0, 0, 0, 0);
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
            btn.Foreground = Brushes.Black;
        }
    }
}
