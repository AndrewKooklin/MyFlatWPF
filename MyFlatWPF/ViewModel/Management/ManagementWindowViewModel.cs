﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using MyFlatWPF.Commands.ManagementCommand;

namespace MyFlatWPF.ViewModel.Management
{
    public class ManagementWindowViewModel : BaseViewModel
    {
        public ManagementWindowViewModel()
        {
            CurrentManagementView = App.OrdersByServicesView;
            SwitchManagementView = new SwitchManagementViewCommand(this);
        }

        public ICommand SwitchManagementView { get; set; }

        private UserControl _currentManagementView;

        public UserControl CurrentManagementView
        {
            get
            {
                return _currentManagementView;
            }
            set
            {
                _currentManagementView = value;
                OnPropertyChanged(nameof(CurrentManagementView));
            }
        }
    }
}