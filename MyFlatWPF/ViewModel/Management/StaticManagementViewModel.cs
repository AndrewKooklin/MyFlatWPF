using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFlatWPF.ViewModel.Management
{
    public class StaticManagementViewModel
    {
        public static ManagementWindowViewModel ManagementViewModel { get; set; }

        public static HomeEditViewModel EditViewModel { get; set; }
    }
}
