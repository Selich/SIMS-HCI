// File:    Doctor.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:10:35 PM
// Purpose: Definition of Class Doctor

using System;
using System.Collections.Generic;

namespace Project.Model
{
   public class Doctor : Employee
   {
        
      public string Password { get; set; }
      public string MedicalRole { get; set; }
      
      public List<Approval> Approval {get; set;}
      public List<MedicalAppointment> Appointments {get;set;}
      
      public Doctor() {}

      public Doctor(long id) 
        {
            Id = id;
        }
      
   }
}