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

            OpenPostDetailsCommand = new OpenPostDetailsCommand();
        }

        public ICommand OpenPostDetailsCommand { get; set; }

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
                tbDateAdded.Background = Brushes.White;
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

                Button btnPost = new Button();
                btnPost.Height = 20;
                btnPost.Width = 190;
                btnPost.BorderThickness = new Thickness(0, 0, 0, 0);
                btnPost.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ececec"));
                btnPost.BorderBrush = Brushes.Transparent;
                btnPost.MouseEnter += btn_mouseEnter;
                btnPost.MouseLeave += btn_mouseLeave;
                btnPost.FontSize = 14;
                btnPost.FontWeight = FontWeights.SemiBold;
                btnPost.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#2235ef"));
                btnPost.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                btnPost.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                btnPost.Content = "Details";
                btnPost.ToolTip = "Post details";
                btnPost.OverridesDefaultStyle = true;
                spCard.Children.Add(btnPost);
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
                post.TypeObject = "post";
                post.IdObject = Int32.Parse(tbId.Text);
                OpenPostDetailsCommand = new SwitchViewCommand(post);
                btnPost.Command = OpenPostDetailsCommand;

                btnPost.CommandParameter = post;
                btnPost.Cursor = Cursors.Hand;

                
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
            btn.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#2235ef")); ;
        }
    }
}
