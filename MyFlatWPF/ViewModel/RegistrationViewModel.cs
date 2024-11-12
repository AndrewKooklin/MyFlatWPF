using MyFlatWPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFlatWPF.ViewModel
{
    class RegistrationViewModel : BaseViewModel
    {
        public RegistrationViewModel()
        {
            
        }

        public ICommand RegisterCommand { get; set; }
    }
}
