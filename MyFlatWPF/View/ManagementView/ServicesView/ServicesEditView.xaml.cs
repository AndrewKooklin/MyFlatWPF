﻿using MyFlatWPF.ViewModel.Management;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyFlatWPF.View.ManagementView.ServicesView
{
    /// <summary>
    /// Interaction logic for ServicesEditView.xaml
    /// </summary>
    public partial class ServicesEditView : UserControl
    {
        public ServicesEditView()
        {
            InitializeComponent();
            this.DataContext = new ServicesEditViewModel(this.wpServices,
                                                         this.btnAddService);
        }
    }
}
