// File:    MedicalAppointment.cs
// Author:  Selic
// Created: Saturday, April 18, 2020 1:03:03 AM
// Purpose: Definition of Class MedicalAppointment

using System;
using System.Windows.Documents;
using Project.Model;

namespace Project.Views.Model
{
    public class MedicalAppointmentDTO : AppoitmentDTO
    {
        public int Id { get; set; }
        public MedicalAppointmentType Type { get; set; }
        public System.Collections.Generic.List<DoctorDTO> Doctors { get; set; }
        public GuestDTO Patient { get; set; }
        public ReviewDTO Review { get; set; }
        public System.Collections.Generic.List<ConsumeblesDTO> Consumebles;

        public MedicalAppointmentDTO() { }


        public MedicalAppointmentDTO(int id, DateTime beginning, DateTime end, RoomDTO room, MedicalAppointmentType type, GuestDTO patient, System.Collections.Generic.List<DoctorDTO> doctors)
        : base(beginning, end, room)
        {
            Id = id;
            Type = type;
            Patient = patient;
            Doctors = doctors;
        }


    }
}