// File:    Renovation.cs
// Author:  Uros
// Created: Friday, April 17, 2020 4:26:32 PM
// Purpose: Definition of Class Renovation

using System;

namespace Project.Model
{
    public class Renovation : Appointment
    {
        public string Type { get; set; }
        public string Contractor { get; set; }

        public Renovation(string type, string contractor)
        {
            Type = type;
            Contractor = contractor;
        }
    }
}