using MyFlatWPF.Commands;
using MyFlatWPF.Data.Repositories.API;
using MyFlatWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyFlatWPF.ViewModel
{
    public class ViewMainElements : BaseViewModel
    {
        //MenuItem newMenuItem = new MenuItem();
        ICommand _mwvmCommand;

        public ViewMainElements(StackPanel sp)
        {
            _mwvmCommand = (ICommand)sp.DataContext;
            GetTopMenu(sp);

            SwitchViewCommand = _mwvmCommand;

        }

        private void GetTopMenu(StackPanel sp)
        {
            //MainWindowViewModel mwvm = (MainWindowViewModel)sp.DataContext;
            //Border border = new Border();
            //border.Height = 25;
            //border.Width = 40;
            //border.BorderBrush = Brushes.Transparent;
            //border.BorderThickness = new Thickness(0, 0, 0, 0);

            //List<MenuItem> menuItems = new List<MenuItem>();

            List<TopMenuLinkNameModel> tmln = new List<TopMenuLinkNameModel>();
            APIRenderingRepository apiRep = new APIRenderingRepository();
            tmln = apiRep.GetTopMenuLinkNames();

            //MenuItem miPicture = new MenuItem();
            //miPicture.Name = "HomePicture";
            //miPicture.FontSize = 15;
            //miPicture.Height = 24;
            //miPicture.Width = 40;
            //miPicture.Command = SwitchViewCommand;
            //miPicture.CommandParameter = miPicture.Name;
            //miPicture.Padding = new System.Windows.Thickness(5, 0, 2, 2);
            //ImageBrush ib = new ImageBrush(new BitmapImage(new Uri(
            //    "C:\\repos\\MyFlatWPF\\MyFlatWPF\\Images\\kind.png")));
            //miPicture.Background = ib;
            //miPicture.Cursor = Cursors.Hand;
            //miPicture.MouseEnter += menu_mouseEnter;
            //miPicture.MouseLeave += menu_mouseLeave;
            //menuItems.Add(miPicture);

            //MenuItem miManage = new MenuItem();
            //miManage.Name = "miManagement";
            //miManage.Header = "Management";
            //miManage.FontSize = 15;
            //miManage.Height = 24;
            //miManage.Margin = new System.Windows.Thickness(2, 0, 0, 0);
            //miManage.Padding = new System.Windows.Thickness(5, 0, 2, 2);
            //miManage.Background = Brushes.Transparent;
            //miManage.Command = SwitchViewCommand;
            //miManage.CommandParameter = miManage.Name;
            //miManage.Visibility = System.Windows.Visibility.Collapsed;
            //miManage.Cursor = Cursors.Hand;
            //menu.Items.Add(miManage);

            foreach (var linkName in tmln)
            {
                Border border = new Border();
                border.Height = 25;
                //border.Width = 40;
                border.BorderBrush = Brushes.Transparent;
                border.BorderThickness = new Thickness(0, 0, 0, 0);

                Button btnMenu = new Button();
                btnMenu.Name = linkName.LinkName;
                btnMenu.Content = linkName.LinkName;
                btnMenu.Cursor = Cursors.Hand;
                btnMenu.FontSize = 15;
                btnMenu.Foreground = Brushes.Black;
                btnMenu.Height = 24;
                //mi.Padding = new System.Windows.Thickness(5, 0, 2, 2);
                btnMenu.Margin = new System.Windows.Thickness(7, 0, 0, 0);
                btnMenu.BorderThickness = new System.Windows.Thickness(0, 0, 0, 0);
                btnMenu.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#fff"));
                btnMenu.Command = SwitchViewCommand;
                btnMenu.CommandParameter = btnMenu.Name;
                btnMenu.MouseEnter += menu_mouseEnter;
                btnMenu.MouseLeave += menu_mouseLeave;
                //menu.Items.Add(mi);
                border.Child = btnMenu;
                sp.Children.Add(border);

            }

            //border.Child = menu;
        }

        public ICommand SwitchViewCommand { get; set; }

        private void menu_mouseEnter(object sender, MouseEventArgs e)
        {
            if(sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;

                Border btnParent = (Border)btnMenu.Parent;
                StackPanel borderParent = (StackPanel)btnParent.Parent;
                Grid spParent = (Grid)borderParent.Parent;
                Style styleMenuItem = (Style)spParent.FindResource("ButtonStyle");


                btnMenu.Style = styleMenuItem;
                btnMenu.OverridesDefaultStyle = true;
                btnMenu.Cursor = Cursors.Hand;
                btnMenu.FontSize = 15;
                btnMenu.Foreground = Brushes.DodgerBlue;
                btnMenu.Height = 24;
                //mi.Padding = new System.Windows.Thickness(5, 0, 2, 2);
                //mi.Margin = new System.Windows.Thickness(4, 0, 0, 0);
                btnMenu.BorderThickness = new System.Windows.Thickness(0, 0, 0, 0);
                btnMenu.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#fff"));
                //ImageBrush ib = new ImageBrush(new BitmapImage(new Uri(
                //     "C:\\repos\\MyFlatWPF\\MyFlatWPF\\Images\\kind.png")));
                //mi.Background = ib;
            }
        }

        private void menu_mouseLeave(object sender, MouseEventArgs e)
        {
            if(sender is Button)
            {
                Button btnMenu = sender as Button;
                e.Handled = true;

                btnMenu.OverridesDefaultStyle = true;
                btnMenu.Cursor = Cursors.Hand;
                btnMenu.FontSize = 15;
                btnMenu.Foreground = Brushes.Black;
                btnMenu.Height = 24;
                //mi.Padding = new System.Windows.Thickness(5, 0, 2, 2);
                //mi.Margin = new System.Windows.Thickness(4, 0, 0, 0);
                btnMenu.BorderThickness = new System.Windows.Thickness(0, 0, 0, 0);
                btnMenu.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#fff"));
                //mi.Content = newMenuItem.Header;
                //mi.Name = newMenuItem.Name;
                //mi.FontSize = newMenuItem.FontSize;
                //mi.Height = newMenuItem.Height;
                //mi.Foreground = newMenuItem.Foreground;
                //mi.Padding = newMenuItem.Padding;
                //mi.Margin = newMenuItem.Margin;
                //mi.BorderThickness = newMenuItem.BorderThickness;
                //mi.Background = newMenuItem.Background;
                //mi.Command = SwitchViewCommand;
                //mi.CommandParameter = newMenuItem.Name;
                //mi.MouseEnter += menu_mouseEnter;
                //mi.MouseLeave += menu_mouseLeave;
                //ImageBrush ib = new ImageBrush(new BitmapImage(new Uri(
                //     "C:\\repos\\MyFlatWPF\\MyFlatWPF\\Images\\kind.png")));
                //mi.Background = ib;
            }
        }
    }
}
