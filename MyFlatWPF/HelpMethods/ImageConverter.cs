using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MyFlatWPF.HelpMethods
{
    public class ImageConverter
    {
        public BitmapImage ByteArrayToImage(byte[] byteArray)
        {
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = new MemoryStream(byteArray);
            bi.EndInit();
            return bi;
        }

        //public byte[] ImageToByteArray(Image image)
        //{

            
        //}
    }
}
