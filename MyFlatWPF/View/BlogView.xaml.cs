using MyFlatWPF.ViewModel;
using System.Windows.Controls;

namespace MyFlatWPF.View
{
    /// <summary>
    /// Interaction logic for BlogView.xaml
    /// </summary>
    public partial class BlogView : UserControl
    {
        public BlogView()
        {
            InitializeComponent();
            this.DataContext = new BlogViewModel(this.wpBlog);
        }
    }
}
