﻿using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Project.Views.Controls
{
    public class Calendar : Control
    {
        static Calendar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Calendar), new FrameworkPropertyMetadata(typeof(Calendar)));

            CommandManager.RegisterClassCommandBinding(typeof(Calendar), new CommandBinding(NextDay, new ExecutedRoutedEventHandler(OnExecutedNextDay), new CanExecuteRoutedEventHandler(OnCanExecuteNextDay)));
            CommandManager.RegisterClassCommandBinding(typeof(Calendar), new CommandBinding(PreviousDay, new ExecutedRoutedEventHandler(OnExecutedPreviousDay), new CanExecuteRoutedEventHandler(OnCanExecutePreviousDay)));
        }

        #region AddAppointment

        public static readonly RoutedEvent AddAppointmentEvent =
            CalendarTimeslotItem.AddAppointmentEvent.AddOwner(typeof(CalendarDay));

        public event RoutedEventHandler AddAppointment
        {
            add
            {
                AddHandler(AddAppointmentEvent, value);
            }
            remove
            {
                RemoveHandler(AddAppointmentEvent, value);
            }
        }

        #endregion

        #region Appointments

        public static readonly DependencyProperty AppointmentsProperty =
            DependencyProperty.Register("MedicalAppointments", typeof(IEnumerable<MedicalAppointment>), typeof(Calendar),
            new FrameworkPropertyMetadata(null, new PropertyChangedCallback(Calendar.OnAppointmentsChanged)));

        public IEnumerable<MedicalAppointment> MedicalAppointments
        {
            get { return (IEnumerable<MedicalAppointment>)GetValue(AppointmentsProperty); }
            set { SetValue(AppointmentsProperty, value); }
        }

        private static void OnAppointmentsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Calendar)d).OnAppointmentsChanged(e);
        }

        protected virtual void OnAppointmentsChanged(DependencyPropertyChangedEventArgs e)
        {
            FilterAppointments();
        }

        #endregion

        #region CurrentDate

        public static readonly DependencyProperty CurrentDateProperty =
            DependencyProperty.Register("CurrentDate", typeof(DateTime), typeof(Calendar),
                new FrameworkPropertyMetadata((DateTime)DateTime.Now,
                    new PropertyChangedCallback(OnCurrentDateChanged)));

        public DateTime CurrentDate
        {
            get { return (DateTime)GetValue(CurrentDateProperty); }
            set { SetValue(CurrentDateProperty, value); }
        }

        private static void OnCurrentDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Calendar)d).OnCurrentDateChanged(e);
        }

        protected virtual void OnCurrentDateChanged(DependencyPropertyChangedEventArgs e)
        {
            FilterAppointments();
        }

        #endregion

        private void FilterAppointments()
        {
            DateTime byDate = CurrentDate;
            CalendarDay day = this.GetTemplateChild("day") as CalendarDay;
            day.ItemsSource = MedicalAppointments.ByDate(byDate);

            TextBlock dayHeader = this.GetTemplateChild("dayHeader") as TextBlock;
            dayHeader.Text = byDate.DayOfWeek.ToString();
        }

        #region NextDay/PreviousDay

        public static readonly RoutedCommand NextDay = new RoutedCommand("NextDay", typeof(Calendar));
        public static readonly RoutedCommand PreviousDay = new RoutedCommand("PreviousDay", typeof(Calendar));

        private static void OnCanExecuteNextDay(object sender, CanExecuteRoutedEventArgs e)
        {
            ((Calendar)sender).OnCanExecuteNextDay(e);
        }

        private static void OnExecutedNextDay(object sender, ExecutedRoutedEventArgs e)
        {
            ((Calendar)sender).OnExecutedNextDay(e);
        }

        protected virtual void OnCanExecuteNextDay(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = false;
        }

        protected virtual void OnExecutedNextDay(ExecutedRoutedEventArgs e)
        {
            CurrentDate += TimeSpan.FromDays(1);
            e.Handled = true;
        }

        private static void OnCanExecutePreviousDay(object sender, CanExecuteRoutedEventArgs e)
        {
            ((Calendar)sender).OnCanExecutePreviousDay(e);
        }

        private static void OnExecutedPreviousDay(object sender, ExecutedRoutedEventArgs e)
        {
            ((Calendar)sender).OnExecutedPreviousDay(e);
        }

        protected virtual void OnCanExecutePreviousDay(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = false;
        }

        protected virtual void OnExecutedPreviousDay(ExecutedRoutedEventArgs e)
        {
            CurrentDate -= TimeSpan.FromDays(1);
            e.Handled = true;
        }

        #endregion
    }
}
