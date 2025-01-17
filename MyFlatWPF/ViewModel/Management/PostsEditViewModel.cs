using MyFlatWPF.Commands.ManagementCommand.PostsCommand;
using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.HelpMethods;
using MyFlatWPF.Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyFlatWPF.ViewModel.Management
{
    public class PostsEditViewModel : BaseViewModel
    {
        WrapPanel _wpEditPosts;
        APIRenderingRepository _api = new APIRenderingRepository();
        Style styleButton = new Style();
        Style styleHoverButton = new Style();
        Style styleCircleButton = new Style();
        Style styleHoverCircleButton = new Style();
        private ImageConverter _ic = new ImageConverter();
        public PostsEditViewModel(WrapPanel wpEditPosts,
                                     Button btnAdd)
        {
            _wpEditPosts = wpEditPosts;
            OpenAddPostCommand = new OpenAddPostCommand();
            OpenChangePostCommand = new OpenChangePostCommand();
            DeletePostCommand = new DeletePostCommand();
            AddElementsWrapPanel(_wpEditPosts);
            btnAdd.Command = OpenAddPostCommand;
            btnAdd.MouseEnter += Btn_mouseEnter;
            btnAdd.MouseLeave += Btn_mouseLeave;
        }


        private ICommand OpenAddPostCommand { get; set; }

        private ICommand OpenChangePostCommand { get; set; }

        private ICommand DeletePostCommand { get; set; }

        private void AddElementsWrapPanel(WrapPanel wpEditProjects)
        {
            Grid gProjectsEdit = (Grid)wpEditProjects.Parent;
            styleButton = (Style)gProjectsEdit.FindResource("ButtonStyle");
            styleHoverButton = (Style)gProjectsEdit.FindResource("ButtonHoverStyle");
            styleCircleButton = (Style)gProjectsEdit.FindResource("ButtonCircleStyle");
            styleHoverCircleButton = (Style)gProjectsEdit.FindResource("HoverButtonCircleStyle");

            List<PostModel> lposts = new List<PostModel>();
            lposts = _api.GetPostsFromDB();

            foreach (PostModel post in lposts)
            {
                StackPanel sp = new StackPanel();
                sp.Orientation = Orientation.Vertical;
                sp.HorizontalAlignment = HorizontalAlignment.Left;
                sp.Width = 130;
                sp.Margin = new Thickness(0, 10, 5, 0);

                Image img = new Image();
                img.Source = _ic.ByteArrayToImage(post.PostImage);
                img.Width = 130;
                img.Height = 100;
                img.Stretch = Stretch.Fill;
                sp.Children.Add(img);

                TextBlock tblock = new TextBlock();
                tblock.OverridesDefaultStyle = true;
                tblock.Text = post.PostHeader;
                tblock.HorizontalAlignment = HorizontalAlignment.Center;
                tblock.Width = 130;
                tblock.FontSize = 12;
                tblock.FontWeight = FontWeights.DemiBold;
                tblock.Background = Brushes.LightGray;
                tblock.Padding = new Thickness(5, 5, 0, 5);
                sp.Children.Add(tblock);

                StackPanel spButtons = new StackPanel();
                spButtons.Name = $"sp{post.Id}";
                spButtons.Orientation = Orientation.Horizontal;
                spButtons.HorizontalAlignment = HorizontalAlignment.Right;

                Button btnOpenChange = new Button();
                btnOpenChange.Content = "🖉";
                btnOpenChange.ToolTip = "Change post";
                btnOpenChange.OverridesDefaultStyle = true;
                btnOpenChange.HorizontalAlignment = HorizontalAlignment.Right;
                btnOpenChange.Margin = new Thickness(0, 5, 1, 0);
                btnOpenChange.Style = styleCircleButton;
                btnOpenChange.MouseEnter += BtnCircle_mouseEnter;
                btnOpenChange.MouseLeave += BtnCircle_mouseLeave;
                btnOpenChange.Command = OpenChangePostCommand;
                btnOpenChange.CommandParameter = post.Id;
                spButtons.Children.Add(btnOpenChange);

                Button btnDelete = new Button();
                btnDelete.Content = "✖";
                btnDelete.ToolTip = "Delete post";
                btnDelete.OverridesDefaultStyle = true;
                btnDelete.HorizontalAlignment = HorizontalAlignment.Right;
                btnDelete.Margin = new Thickness(5, 5, 1, 0);
                btnDelete.Style = styleCircleButton;
                btnDelete.MouseEnter += BtnCircle_mouseEnter;
                btnDelete.MouseLeave += BtnCircle_mouseLeave;
                btnDelete.Command = DeletePostCommand;
                btnDelete.CommandParameter = post.Id;
                spButtons.Children.Add(btnDelete);

                sp.Children.Add(spButtons);
                wpEditProjects.Children.Add(sp);
            }
        }

        private void Btn_mouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;
                btnMenu.Style = styleHoverButton;
                btnMenu.OverridesDefaultStyle = true;
                btnMenu.Cursor = Cursors.Hand;
                btnMenu.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#0082ff"));
            }
        }

        private void Btn_mouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;
                btnMenu.Style = styleButton;
                btnMenu.OverridesDefaultStyle = true;
                btnMenu.Cursor = Cursors.Hand;
                btnMenu.Background = Brushes.DeepSkyBlue;
            }
        }

        private void BtnCircle_mouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;
                btnMenu.Style = styleHoverCircleButton;
                btnMenu.OverridesDefaultStyle = true;
                btnMenu.Cursor = Cursors.Hand;
                btnMenu.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#0082ff"));
            }
        }

        private void BtnCircle_mouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;
                btnMenu.Style = styleCircleButton;
                btnMenu.OverridesDefaultStyle = true;
                btnMenu.Cursor = Cursors.Hand;
                btnMenu.Background = Brushes.DeepSkyBlue;
            }
        }
    }
}
