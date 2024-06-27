using MyFlatWPF.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MyFlatWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MyFlatWindow MyFlatWindow = new MyFlatWindow(); 

        protected override void OnStartup(StartupEventArgs e)
        {
            App.MyFlatWindow.Show();

            base.OnStartup(e);
        }
    }
}
