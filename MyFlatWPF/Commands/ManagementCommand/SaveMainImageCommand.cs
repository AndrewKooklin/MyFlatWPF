using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.HelpMethods;
using MyFlatWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand
{
    public class SaveMainImageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private APIManagementRepository _api = new APIManagementRepository();
        private ImageConverter _ic = new ImageConverter();

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            if(parameter == null)
            {
                return;
            }
            else 
            {
                var elements = (SaveImageParameters)parameter;

                if (elements.NewImage is Image)
                {
                    Image newImage = (Image)elements.NewImage;
                    TextBlock tbImageName = (TextBlock)elements.Text;
                    if (StaticImage.NewImage == null)
                    {
                        return;
                    }
                    else
                    {
                        HomePagePlaceholderModel _hpphm = new HomePagePlaceholderModel();
                        _hpphm.MainPicture = StaticImage.NewImage;
                        bool result = await _api.ChangeMainImage(_hpphm);
                        if (result)
                        {
                            newImage.Source = null;
                            newImage.Source = _ic.ByteArrayToImage(StaticImage.NewImage);
                            tbImageName.Text = "Image not choosed";
                            StaticImage.NewImage = null;
                        }
                    }
                }
            }
            
            
        }
    }
}
