using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyFlatWPF.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void OnYourNameChanged(object sender, TextChangedEventArgs e)
        {
            if(sender is TextBox name)
            {
                if (string.IsNullOrEmpty(name.Text))
                {
                    name.Background = (ImageBrush)FindResource("YourName");
                }
                else
                {
                    name.Background = null;
                }
            }
        }

        private void OnYourEmailChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox email)
            {
                if (string.IsNullOrEmpty(email.Text))
                {
                    email.Background = (ImageBrush)FindResource("YourEmail");
                }
                else
                {
                    email.Background = null;
                }
            }
        }
    }
}
