// File:    Anamneza.cs
// Author:  Selic
// Created: Friday, March 20, 2020 10:32:33 PM
// Purpose: Definition of Class Anamneza

using System;

namespace Project.Views.Model
{
   public class AnamnesisDTO
   {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public MedicalAppointmentDTO MedicalAppointmentDTO { get; set; }


        public AnamnesisDTO(long Id, string name, string type, string description, MedicalAppointmentDTO medicalAppointmentDTO)
        {
            this.Id = Id;
            Name = name;
            Type = type;
            Description = description;
            this.MedicalAppointmentDTO = medicalAppointmentDTO;
        }

        public AnamnesisDTO()
        {
        }

        public AnamnesisDTO(long Id, string name, string type, string description)
        {
            this.Id = Id;
            Name = name;
            Type = type;
            Description = description;
        }
    }
}