using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MyFlatWPF.Model
{
    public class StackPanelModel : BindableBase
    {
        private StackPanel _sPanel;

        public StackPanel StackPanel
        {
            get
            {
                return _sPanel;
            }
            set
            {
                SetProperty(ref _sPanel, value);
            }
        }
    }
}
