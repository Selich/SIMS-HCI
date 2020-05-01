// File:    Patient.cs
// Author:  Selic
// Created: Friday, April 17, 2020 2:46:58 PM
// Purpose: Definition of Class Patient

using System;

public class Patient : User
{
   private string insurenceNumber;
   private string profession;
   
   
   public System.Collections.Generic.List<MedicalAppointment> appointments;
   
   /// <summary>
   /// Property for collection of MedicalAppointment
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<MedicalAppointment> Appointments
   {
      get
      {
         if (appointments == null)
            appointments = new System.Collections.Generic.List<MedicalAppointment>();
         return appointments;
      }
      set
      {
         RemoveAllAppointments();
         if (value != null)
         {
            foreach (MedicalAppointment oMedicalAppointment in value)
               AddAppointments(oMedicalAppointment);
         }
      }
   }
   
   /// <summary>
   /// Add a new MedicalAppointment in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddAppointments(MedicalAppointment newMedicalAppointment)
   {
      if (newMedicalAppointment == null)
         return;
      if (this.appointments == null)
         this.appointments = new System.Collections.Generic.List<MedicalAppointment>();
      if (!this.appointments.Contains(newMedicalAppointment))
      {
         this.appointments.Add(newMedicalAppointment);
         newMedicalAppointment.Patient = this;
      }
   }
   
   /// <summary>
   /// Remove an existing MedicalAppointment from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveAppointments(MedicalAppointment oldMedicalAppointment)
   {
      if (oldMedicalAppointment == null)
         return;
      if (this.appointments != null)
         if (this.appointments.Contains(oldMedicalAppointment))
         {
            this.appointments.Remove(oldMedicalAppointment);
            oldMedicalAppointment.Patient = null;
         }
   }
   
   /// <summary>
   /// Remove all instances of MedicalAppointment from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllAppointments()
   {
      if (appointments != null)
      {
         System.Collections.ArrayList tmpAppointments = new System.Collections.ArrayList();
         foreach (MedicalAppointment oldMedicalAppointment in appointments)
            tmpAppointments.Add(oldMedicalAppointment);
         appointments.Clear();
         foreach (MedicalAppointment oldMedicalAppointment in tmpAppointments)
            oldMedicalAppointment.Patient = null;
         tmpAppointments.Clear();
      }
   }
   public MedicalChart medicalChart;

}