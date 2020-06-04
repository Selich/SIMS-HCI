// File:    Consumebles.cs
// Author:  Selic
// Created: Saturday, April 18, 2020 7:48:20 PM
// Purpose: Definition of Class Consumebles

using System;
using System.Reflection.Emit;

namespace Project.Views.Model
{
   public class ConsumabelsDTO
   {
      public int Quantity {get;set;}
      public string Type {get;set;}
      public string Description {get;set;}
      public string Name {get;set;}
      
      public MedicalAppointmentDTO[] medicalAppointment;

      public ConsumabelsDTO() { }

      public ConsumabelsDTO(string name,string type, string description,int quantitiy) 
      {
            this.Name = name;
            this.Type = type;
            this.Description = description;
            this.Quantity = quantitiy;
            
      }

   }
}