using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MyFlatWPF.ViewModel
{
    public class ServicesViewModel : BaseViewModel
    {
        private StackPanel _stackPanel;

        public ServicesViewModel(StackPanel stackPanel)
        {
            _stackPanel = stackPanel;

            GetServiceCards(_stackPanel);
        }

        private void GetServiceCards(StackPanel stackPanel)
        {
            for (int i = 0; i < 6; i++)
            {
                Expander exp = new Expander();



                stackPanel.Children.Add(exp);
            }
        }
    }
}
