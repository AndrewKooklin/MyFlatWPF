using MyFlatWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFlatWPF.ViewModel
{
    public class StaticViewModel
    {
        public static MainWindowViewModel MainViewModel { get; set; }

        public static HomeViewModel HomeViewModel { get; set; }

        public static ProjectsViewModel ProjectsViewModel { get; set; }
    }
}
