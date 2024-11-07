using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MyFlatWPF.Commands;
using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.HelpMethods;
using MyFlatWPF.Model;

namespace MyFlatWPF.ViewModel
{
    public class BlogViewModel : BaseViewModel
    {
        private WrapPanel _wrapPanel;
        APIRenderingRepository _api = new APIRenderingRepository();
        private List<PostModel> Posts { get; set; }
        ImageConverter ic = new ImageConverter();

        public BlogViewModel(WrapPanel wrapPanel)
        {
            _wrapPanel = wrapPanel;

            Posts = GetPosts();

            GetBlogCards(_wrapPanel);

            //OpenPostDetailsCommand = new OpenPostDetailsCommand();
        }

        //public ICommand OpenPostDetailsCommand { get; set; }

        private void GetBlogCards(WrapPanel wrapPanel)
        {
            if(Posts.Count >= 0)
            {
                foreach (PostModel postItem in Posts)
                {
                    Border border = new Border();
                    border.Height = 215;
                    border.Width = 188;
                    border.BorderBrush = Brushes.Black;
                    border.BorderThickness = new Thickness(1, 1, 1, 1);
                    border.Margin = new Thickness(5, 5, 0, 0);

                    StackPanel spCard = new StackPanel();
                    spCard.Orientation = Orientation.Vertical;

                    TextBlock tbId = new TextBlock();
                    tbId.Visibility = Visibility.Collapsed;
                    tbId.Text = postItem.Id.ToString();
                    spCard.Children.Add(tbId);

                    TextBlock tbDateAdded = new TextBlock();
                    tbDateAdded.Text = postItem.PostingDate.ToString("dd MMMM yyyy");
                    tbDateAdded.Padding = new Thickness(10, 1, 0, 1);
                    tbDateAdded.FontSize = 10;
                    tbDateAdded.Background = Brushes.White;
                    spCard.Children.Add(tbDateAdded);

                    Image image = new Image();
                    image.Height = 140;
                    image.Width = 190;
                    image.Margin = new Thickness(0, 0, 0, 0);
                    BitmapImage src = new BitmapImage();
                    src = ic.ByteArrayToImage(postItem.PostImage);
                    image.Source = src;
                    image.Stretch = Stretch.Uniform;
                    image.StretchDirection = StretchDirection.Both;
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
                    btnPost.Content = postItem.PostHeader;
                    btnPost.ToolTip = "Post details";
                    btnPost.OverridesDefaultStyle = true;
                    spCard.Children.Add(btnPost);

                    TextBlock tbPostDescription = new TextBlock();
                    tbPostDescription.Width = 190;
                    tbPostDescription.Height = 40;
                    tbPostDescription.Text = GetSubstring(postItem.PostDescription);
                        //"As a builder, we undertake large, complex projects, " +
                        //"foster innovation, embrace emerging technologies, " +
                        //"and make a difference in the community.";
                    tbPostDescription.Padding = new Thickness(2, 1, 2, 1);
                    tbPostDescription.FontSize = 8;
                    tbPostDescription.Background = Brushes.White;
                    tbPostDescription.TextWrapping = TextWrapping.WrapWithOverflow;
                    spCard.Children.Add(tbPostDescription);

                    ObjectModel post = new ObjectModel();
                    post.TypeObject = "post";
                    post.IdObject = Int32.Parse(tbId.Text);
                    //OpenPostDetailsCommand = new SwitchViewCommand(post);
                    btnPost.Command = new SwitchViewCommand(post);

                    btnPost.CommandParameter = post;
                    btnPost.Cursor = Cursors.Hand;

                    border.Child = spCard;
                    wrapPanel.Children.Add(border);
                }
            }
        }

        private List<PostModel> GetPosts()
        {
            List<PostModel> lpm = new List<PostModel>();
            lpm = _api.GetPostsFromDB();
            return lpm;
        }

        private string GetSubstring(string text)
        {
            if(text.Length <= 150)
            {
                return text;
            }
            else
            {
                return text.Substring(0, 150);
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
