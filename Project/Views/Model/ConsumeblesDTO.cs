// File:    Consumebles.cs
// Author:  Selic
// Created: Saturday, April 18, 2020 7:48:20 PM
// Purpose: Definition of Class Consumebles

using System;

namespace Project.Views.Model
{
   public class ConsumeblesDTO
   {
      public int Quantity {get;set;}
      public string Type {get;set;}
      public string Description {get;set;}
      public string Name {get;set;}
      
      public MedicalAppointmentDTO[] medicalAppointment;
   
   }
}