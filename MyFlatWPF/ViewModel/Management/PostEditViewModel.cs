using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.HelpMethods;
using MyFlatWPF.Model;
using MyFlatWPF.Commands.ManagementCommand.PostsCommand;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyFlatWPF.ViewModel.Management
{
    public class PostEditViewModel : BaseViewModel
    {
        Style styleButton = new Style();
        Style styleButtonHover = new Style();
        APIManagementRepository _api = new APIManagementRepository();
        private ImageConverter _ic = new ImageConverter();

        public PostEditViewModel(TextBox tbHeader,
                                    TextBox tbContent,
                                    Image image,
                                    Button btnChooseImage,
                                    TextBlock tblImageName,
                                    Button btnChange,
                                    Button btnCancel,
                                    int id)
        {
            Grid grid = (Grid)tbHeader.Parent;
            styleButton = (Style)grid.FindResource("ButtonStyle");
            styleButtonHover = (Style)grid.FindResource("ButtonHoverStyle");
            ChoosePostImageCommand = new ChoosePostImageCommand();
            ChangePostCommand = new ChangePostCommand();
            CancelChangePostCommand = new CancelChangePostCommand();
            AddElementsToGrid(tbHeader,
                              tbContent,
                              image,
                              btnChooseImage,
                              tblImageName,
                              btnChange,
                              btnCancel,
                              id);
        }

        private ICommand ChoosePostImageCommand { get; set; }
        private ICommand ChangePostCommand { get; set; }
        private ICommand CancelChangePostCommand { get; set; }

        private void AddElementsToGrid(TextBox tbHeader,
                                       TextBox tbContent,
                                       Image image,
                                       Button btnChooseImage,
                                       TextBlock tblImageName,
                                       Button btnChange,
                                       Button btnCancel,
                                       int id)
        {
            PostModel project = GetPostByIdFromDB(id);

            tbHeader.Text = project.PostHeader;

            tbContent.Text = project.PostDescription;

            image.Source = _ic.ByteArrayToImage(project.PostImage);

            btnChooseImage.Command = ChoosePostImageCommand;
            btnChooseImage.CommandParameter = tblImageName;
            btnChooseImage.MouseEnter += Btn_mouseEnter;
            btnChooseImage.MouseLeave += Btn_mouseLeave;

            btnChange.Command = ChangePostCommand;
            btnChange.CommandParameter = id;
            btnChange.MouseEnter += Btn_mouseEnter;
            btnChange.MouseLeave += Btn_mouseLeave;

            btnCancel.Command = CancelChangePostCommand;
            btnCancel.MouseEnter += Btn_mouseEnter;
            btnCancel.MouseLeave += Btn_mouseLeave;
        }

        private PostModel GetPostByIdFromDB(int id)
        {
            return _api.GetPostById(id);
        }

        private void Btn_mouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;
                btnMenu.Style = styleButtonHover;
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
    }
}
