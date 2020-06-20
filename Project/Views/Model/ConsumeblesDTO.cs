// File:    Consumebles.cs
// Author:  Selic
// Created: Saturday, April 18, 2020 7:48:20 PM
// Purpose: Definition of Class Consumebles

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Emit;

namespace Project.Views.Model
{
    public class ConsumabelsDTO : INotifyPropertyChanged
    {
        private int quantity { get; set; }
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                if (value != quantity)
                {
                    quantity = value;
                    OnPropertyChanged("Quantity");
                }
            }
        }

        public string Type { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public List<MedicalAppointmentDTO> medicalAppointment { get; set; }
        public ConsumabelsDTO() { }

        public ConsumabelsDTO(string name, string type, string description, int quantitiy)
        {
            Name = name;
            Type = type;
            Description = description;
            Quantity = quantitiy;
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}