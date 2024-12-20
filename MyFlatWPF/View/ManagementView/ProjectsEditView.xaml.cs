using MyFlatWPF.ViewModel.Management;
using System.Windows.Controls;

namespace MyFlatWPF.View.ManagementView
{
    /// <summary>
    /// Interaction logic for ProjectsEditView.xaml
    /// </summary>
    public partial class ProjectsEditView : UserControl
    {
        public ProjectsEditView()
        {
            InitializeComponent();
            this.DataContext = new ProjectsEditViewModel(this.wpProjects,
                                                         this.btnAddProject);
        }
    }
}
