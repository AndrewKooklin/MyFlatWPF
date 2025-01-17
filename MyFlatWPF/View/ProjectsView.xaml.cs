using MyFlatWPF.ViewModel;
using System.Windows.Controls;

namespace MyFlatWPF.View
{
    /// <summary>
    /// Interaction logic for ProjectsView.xaml
    /// </summary>
    public partial class ProjectsView : UserControl
    {
        public ProjectsView()
        {
            InitializeComponent();
            this.DataContext = new ProjectsViewModel(this.wpProjects);
        }
    }
}
