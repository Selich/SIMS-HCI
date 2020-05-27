// File:    Prescription.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:30:56 PM
// Purpose: Definition of Class Prescription

using System;

namespace Project.Model
{
   public class Prescription
   {
      public int Id {get;set;}
      public int Dosage {get;set;}
      public string Usage {get;set;}
      public string Period {get;set;}
      public int HospitalID {get;set;}
      public DateTime Date {get;set;}

      public Guest Patient { get; set; }
   
   }
}