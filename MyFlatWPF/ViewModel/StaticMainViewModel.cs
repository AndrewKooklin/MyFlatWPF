using MyFlatWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFlatWPF.ViewModel
{
    public class StaticMainViewModel
    {
        public static MainWindowViewModel MainViewModel { get; set; }

        public static List<string> RandomPhrases { get; set; }
    }
}
