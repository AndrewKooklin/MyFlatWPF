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
                App.HomeWiew.tbServerError.Text = "";
                App.HomeWiew.tbOrderSaved.Text = "";

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

        private void OnSelectedChanged(object sender, SelectionChangedEventArgs e)
        {
            if(sender is ComboBox cb)
            {
                ComboBoxItem cbItem = (ComboBoxItem)cb.SelectedItem;
                string serviceName = cbItem.Content.ToString();
                App.HomeWiew.cbiService.Content = serviceName;
            }
        }
    }
}
