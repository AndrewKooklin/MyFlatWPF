﻿using System;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using MyFlatWPF.HelpMethods;

namespace MyFlatWPF.Commands.ManagementCommand
{
    public class ChooseMainImageCommand : ICommand
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
            if(result == true)
            {
                string filePath = dialog.FileName;
                byte[] image = _ic.ImageToByteArray(filePath);
                StaticImage.NewMainImage = image;
                if(parameter is TextBlock)
                {
                    TextBlock tbImageName = (TextBlock)parameter;
                    tbImageName.Text = $"Choosed : \"{dialog.SafeFileName}\"";
                }
            }
        }
    }
}
