﻿using Project.Model;
using Project.Repositories;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for ProfileModal.xaml
    /// </summary>
    public partial class ProfileModal : Window
    {

        public ProfileModal(MedicalAppointmentDTO dataContext)
        {
            DataContext = dataContext;
            InitializeComponent();
        }
        public ProfileModal(PatientDTO dataContext)
        {
            DataContext = dataContext;
            InitializeComponent();
        }

        private void HandleEsc(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Escape)
            Close();
    }
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            Profile_FirstName.IsEnabled = true;
            Profile_LastName.IsEnabled = true;
            Profile_Email.IsEnabled = true;
            Profile_Address.IsEnabled = true;
            Profile_TelephoneNumber.IsEnabled = true;
            Obustavi.Visibility = Visibility.Visible;
            Izmeni.Visibility = Visibility.Hidden;
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Profile_FirstName.IsEnabled = false;
            Profile_LastName.IsEnabled = false;
            Profile_Email.IsEnabled = false;
            Profile_Address.IsEnabled = false;
            Profile_TelephoneNumber.IsEnabled = false;
            Obustavi.Visibility = Visibility.Hidden;
            Izmeni.Visibility = Visibility.Visible;

        }

        private void listAppointments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
