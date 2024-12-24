using Microsoft.Win32;
using MyFlatWPF.HelpMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.PostsCommand
{
    public class ChoosePostImageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private ImageConverter _ic = new ImageConverter();

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = ".jpg";
            dialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|" +
                            "PNG Files (*.png)|*.png|" +
                            "JPG Files (*.jpg)|*.jpg|" +
                            "GIF Files (*.gif)|*.gif|" +
                            "WEBP Files (*.webp)|*.webp";
            dialog.Multiselect = false;
            Nullable<bool> result = dialog.ShowDialog();
            if (result == true)
            {
                string filePath = dialog.FileName;
                byte[] image = _ic.ImageToByteArray(filePath);
                StaticImage.NewPostImage = image;
                if (parameter is TextBlock)
                {
                    TextBlock tbImageName = (TextBlock)parameter;
                    tbImageName.Text = $"Choosed : \"{dialog.SafeFileName}\"";
                    App.PostEditView.iPostImage.Source = 
                        _ic.ByteArrayToImage(StaticImage.NewPostImage);
                }
            }
        }
    }
}
