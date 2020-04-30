// File:    PatientReport.cs
// Author:  Selic
// Created: Tuesday, April 21, 2020 11:21:31 PM
// Purpose: Definition of Class PatientReport

using System;

public class PatientReport
{
   private string path;
   private DateTime date;
   private string type;
   
   public static PatientReport GenerateReport(string type, TimeInterval interval)
   {
      throw new NotImplementedException();
   }
   
   public RegistredPatient registredPatient;
   
   /// <summary>
   /// Property for RegistredPatient
   /// </summary>
   /// <pdGenerated>Default opposite class property</pdGenerated>
   public RegistredPatient RegistredPatient
   {
      get
      {
         return registredPatient;
      }
      set
      {
         if (this.registredPatient == null || !this.registredPatient.Equals(value))
         {
            if (this.registredPatient != null)
            {
               RegistredPatient oldRegistredPatient = this.registredPatient;
               this.registredPatient = null;
               oldRegistredPatient.RemoveReports(this);
            }
            if (value != null)
            {
               this.registredPatient = value;
               this.registredPatient.AddReports(this);
            }
         }
      }
   }

}