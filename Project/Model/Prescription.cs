// File:    Prescription.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:30:56 PM
// Purpose: Definition of Class Prescription

using System;

namespace Model
{
   public class Prescription
   {
      private int id;
      private int dosage;
      private string usage;
      private string period;
      private int hospitalID;
      private DateTime date;
      
      public Patient patient;
      
      /// <summary>
      /// Property for Patient
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public Patient Patient
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
                  Patient oldPatient = this.patient;
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