using Microsoft.Win32;
using MyFlatWPF.HelpMethods;
using System;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand.ProjectCommand
{
    public class ChooseAddProjectImageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private ImageConverter _ic = new ImageConverter();
        OpenFileDialog dialog;
        byte[] image;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            dialog = new OpenFileDialog();
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
                image = _ic.ImageToByteArray(filePath);
                StaticImage.NewProjectImage = image;
                App.AddProjectView.iProjectImage.Source = _ic.ByteArrayToImage(StaticImage.NewProjectImage);
                App.AddProjectView.tblImageName.Text = $"Choosed : \"{dialog.SafeFileName}\"";
            }
        }
    }
}
