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
        public static new MainWindow mainWindow = new MainWindow();

        protected override void OnStartup(StartupEventArgs e)
        {
            
            App.mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
