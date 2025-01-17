using MyFlatWPF.ViewModel.Management;
using System.Windows.Controls;

namespace MyFlatWPF.View.ManagementView.BlogView
{
    /// <summary>
    /// Interaction logic for PostsEditView.xaml
    /// </summary>
    public partial class PostsEditView : UserControl
    {
        public PostsEditView()
        {
            InitializeComponent();
            this.DataContext = new PostsEditViewModel(this.wpPosts,
                                                         this.btnAddPost);
        }
    }
}
