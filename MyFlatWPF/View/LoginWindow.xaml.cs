﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyFlatWPF.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginWindow_Loaded(object sender, RoutedEventArgs e)
        {
            tbEMail.Text = MyFlatWPF.Properties.Settings.Default.EMail;
            tbPassword.Password = MyFlatWPF.Properties.Settings.Default.Password;
        }
    }
}
