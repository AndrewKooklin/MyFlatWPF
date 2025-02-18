﻿using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace MyFlatWPF.HelpMethods
{
    public class ImageConverter
    {
        public BitmapImage ByteArrayToImage(byte[] byteArray)
        {
            BitmapImage bi = new BitmapImage();
            if (byteArray == null)
            {
                return bi;
            }
            bi.BeginInit();
            bi.StreamSource = new MemoryStream(byteArray);
            bi.EndInit();
            return bi;
        }

        public byte[] ImageToByteArray(string path)
        {
            FileStream _fs;
            byte[] imageBytes;
                using(_fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    imageBytes = new byte[_fs.Length];
                    _fs.Read(imageBytes, 0, Convert.ToInt32(_fs.Length));
                }
            return imageBytes;
        }
    }
}
