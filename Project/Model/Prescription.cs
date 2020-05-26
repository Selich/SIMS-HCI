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
      private int Dosage {get;set;}
      ;
      private string Usage {get;set;}
      private string Period {get;set;}
      private int HospitalID {get;set;}
      private DateTime Date {get;set;}
      
      public Guest patient;
      
      /// <summary>
      /// Property for Patient
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public Guest Patient
      {
         get
         {
            return patient;
         }
         set
         {
            if (this.patient == null || !this.patient.Equals(value))
            {
               if (this.patient != null)
               {
                  Guest oldPatient = this.patient;
                  this.patient = null;
                  oldPatient.RemovePrescription(this);
               }
               if (value != null)
               {
                  this.patient = value;
                  this.patient.AddPrescription(this);
               }
            }
         }
      }
   
   }
}