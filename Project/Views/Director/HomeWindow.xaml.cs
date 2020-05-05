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

namespace Project.Views.Director
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
        }

        private void OpenSettingsModal(object sender, RoutedEventArgs e)
        {
            SettingsModal modal = new SettingsModal();
            modal.ShowDialog();
        }

        private void OpenBugReportModal(object sender, RoutedEventArgs e)
        {
            BugReportModal modal = new BugReportModal();
            modal.ShowDialog();
        }

        private void ChangeProfile(object sender, RoutedEventArgs e)
        {
            Save_btn.Visibility = Visibility.Visible; ;
            Cancel_btn.Visibility = Visibility.Visible; ;
            Change_btn.Visibility = Visibility.Hidden; 
        }

        private void CancelProfileChanges(object sender, RoutedEventArgs e)
        {
            Save_btn.Visibility = Visibility.Hidden; ;
            Cancel_btn.Visibility = Visibility.Hidden; ;
            Change_btn.Visibility = Visibility.Visible;
        }

        private void ConfirmProfileChanges(object sender, RoutedEventArgs e)
        {
            Save_btn.Visibility = Visibility.Hidden; ;
            Cancel_btn.Visibility = Visibility.Hidden; ;
            Change_btn.Visibility = Visibility.Visible;
        }

        private void OpenEmployeeDataModal(object sender, RoutedEventArgs e)
        {
            EmployeeDataModal modal = new EmployeeDataModal();
            modal.ShowDialog();
        }

        private void OpenEmployeeDetails(object sender, RoutedEventArgs e)
        {
            EmployeesGrid.Visibility = Visibility.Collapsed;
            EmployeeDetailsGrid.Visibility = Visibility.Visible;
        }

        private void OpenEmplyees(object sender, RoutedEventArgs e)
        {
            EmployeeDetailsGrid.Visibility = Visibility.Collapsed;
            EmployeesGrid.Visibility = Visibility.Visible;
        }

       
        private void OpenRooms(object sender, RoutedEventArgs e)
        {
            RoomDetails.Visibility = Visibility.Collapsed;
            Rooms.Visibility = Visibility.Visible;
        }

        private void OpenRoomDetails(object sender, RoutedEventArgs e)
        {
            Rooms.Visibility = Visibility.Collapsed;
            RoomDetails.Visibility = Visibility.Visible;
        }
    }
}
