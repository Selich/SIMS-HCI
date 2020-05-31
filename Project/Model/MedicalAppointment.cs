// File:    MedicalAppointment.cs
// Author:  Selic
// Created: Saturday, April 18, 2020 1:03:03 AM
// Purpose: Definition of Class MedicalAppointment

using System;
using System.Windows.Documents;

namespace Project.Model
{
    public class MedicalAppointment : Appointment
    {
        public MedicalAppointmentType Type { get; set; }
        public System.Collections.Generic.List<Doctor> Doctors;
        public Patient Patient;
        public System.Collections.Generic.List<Consumebles> Consumebles;
        public Review Review;
        public System.Collections.Generic.List<Anamnesis> Anamnesis;

        public MedicalAppointment() { }

        public MedicalAppointment(int id, DateTime beginning, DateTime end, Room room, MedicalAppointmentType type, Patient patient, System.Collections.Generic.List<Doctor> doctors)
        : base(id, beginning, end, room)
        {
            Type = type;
            Patient = patient;
            Doctors = doctors;
        }

    }
}
