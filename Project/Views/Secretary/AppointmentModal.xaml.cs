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

namespace Project.Views.Secretary
{
    /// <summary>
    /// Interaction logic for AppointmentModal.xaml
    /// </summary>
    public partial class AppointmentModal : Window
    {
        public AppointmentModal()
        {
            InitializeComponent();
        }

        private void Change_Doctors(object sender, RoutedEventArgs e)
        {
            Doctor_Search_TextBox.Visibility = Visibility.Visible;
            Change_Doctor_Button.Visibility = Visibility.Hidden;
            Cancel_Change_Doctor_Button.Visibility = Visibility.Visible;


        }
        private void Cancel_Change_Doctors(object sender, RoutedEventArgs e)
        {
            Doctor_Search_TextBox.Visibility = Visibility.Hidden;
            Change_Doctor_Button.Visibility = Visibility.Visible;
            Cancel_Change_Doctor_Button.Visibility = Visibility.Hidden;

        }
    }
}
