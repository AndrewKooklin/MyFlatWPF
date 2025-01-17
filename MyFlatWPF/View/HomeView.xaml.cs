using System.Windows.Controls;
using System.Windows.Media;

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
                App.HomeView.tbServerError.Text = "";
                App.HomeView.tbOrderSaved.Text = "";

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

        private void OnYourMobileChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox mobile)
            {
                if (string.IsNullOrEmpty(mobile.Text))
                {
                    mobile.Background = (ImageBrush)FindResource("YourMobile");
                }
                else
                {
                    mobile.Background = null;
                }
            }
        }

        private void OnYourMessageChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox message)
            {
                if (string.IsNullOrEmpty(message.Text))
                {
                    message.Background = (ImageBrush)FindResource("YourMessage");
                }
                else
                {
                    message.Background = null;
                }
            }
        }
    }
}
