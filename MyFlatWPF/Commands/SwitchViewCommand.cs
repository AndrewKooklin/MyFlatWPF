﻿using MyFlatWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFlatWPF.Commands
{
    public class SwitchViewCommand : ICommand
    {
        private MainWindowViewModel _mainWindowViewModel;

        public event EventHandler CanExecuteChanged;

        public SwitchViewCommand(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter == null)
            {
                return;
            }

            switch (parameter.ToString())
            {
                case "miHomePicture":
                case "miHome":
                    {
                        App.HomeWiew.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowViewModel.CurrentView = App.HomeWiew;
                        break;
                    }
                case "miManagement":
                    {
                        App.ManagementWindow.Show();
                        App.mainWindow.Close();
                        break;
                    }
                case "miProjects":
                    {
                        App.ProjectsWiew.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowViewModel.CurrentView = App.ProjectsWiew;
                        break;
                    }
                case "miServices":
                    {
                        App.ServicesWiew.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowViewModel.CurrentView = App.ServicesWiew;
                        break;
                    }
                case "miBlog":
                    {
                        App.BlogWiew.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowViewModel.CurrentView = App.BlogWiew;
                        break;
                    }
                case "miContacts":
                    {
                        App.ContactsWiew.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowViewModel.CurrentView = App.ContactsWiew;
                        break;
                    }
                default: break;
            }
        }
    }
}