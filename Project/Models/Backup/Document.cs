// File:    Document.cs
// Author:  Selic
// Created: Friday, April 17, 2020 3:28:18 PM
// Purpose: Definition of Class Document

using System;

public class Document
{
   private DateTime creationTime;
   
   public MedicalAppointment medicalAppointment;
   
   /// <summary>
   /// Property for MedicalAppointment
   /// </summary>
   /// <pdGenerated>Default opposite class property</pdGenerated>
   public MedicalAppointment MedicalAppointment
   {
      get
      {
         return medicalAppointment;
      }
      set
      {
         if (this.medicalAppointment == null || !this.medicalAppointment.Equals(value))
         {
            if (this.medicalAppointment != null)
            {
               MedicalAppointment oldMedicalAppointment = this.medicalAppointment;
               this.medicalAppointment = null;
               oldMedicalAppointment.RemoveDocuments(this);
            }
            if (value != null)
            {
               this.medicalAppointment = value;
               this.medicalAppointment.AddDocuments(this);
            }
         }
      }
   }
   public MedicalChart medicalChart;
   
   /// <summary>
   /// Property for MedicalChart
   /// </summary>
   /// <pdGenerated>Default opposite class property</pdGenerated>
   public MedicalChart MedicalChart
   {
      get
      {
         return medicalChart;
      }
      set
      {
         if (this.medicalChart == null || !this.medicalChart.Equals(value))
         {
            if (this.medicalChart != null)
            {
               MedicalChart oldMedicalChart = this.medicalChart;
               this.medicalChart = null;
               oldMedicalChart.RemoveDocuments(this);
            }
            if (value != null)
            {
               this.medicalChart = value;
               this.medicalChart.AddDocuments(this);
            }
         }
      }
   }

}