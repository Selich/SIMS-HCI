// File:    Patient.cs
// Author:  Selic
// Created: Friday, April 17, 2020 2:46:58 PM
// Purpose: Definition of Class Patient

using System;

namespace Model
{
    public class Patient : User
    {
        private string insurenceNumber;
        private string profession;
        private string bloodType;
        private float height;
        private float weight;
        public string email
        {get;set;}
      private int id;

      public Patient(){ }
      public Patient(string firstName, string lastName): base(firstName,lastName) { }
      
      public void AddMedicalCondition()
      {
         throw new NotImplementedException();
      }
      
      public void AddAllergies()
      {
         throw new NotImplementedException();
      }
      
      
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
      public System.Collections.Generic.List<Prescription> prescription;
      
      /// <summary>
      /// Property for collection of Prescription
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Prescription> Prescription
      {
         get
         {
            if (prescription == null)
               prescription = new System.Collections.Generic.List<Prescription>();
            return prescription;
         }
         set
         {
            RemoveAllPrescription();
            if (value != null)
            {
               foreach (Prescription oPrescription in value)
                  AddPrescription(oPrescription);
            }
         }
      }
      
      /// <summary>
      /// Add a new Prescription in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddPrescription(Prescription newPrescription)
      {
         if (newPrescription == null)
            return;
         if (this.prescription == null)
            this.prescription = new System.Collections.Generic.List<Prescription>();
         if (!this.prescription.Contains(newPrescription))
         {
            this.prescription.Add(newPrescription);
            newPrescription.Patient = this;
         }
      }
      
      /// <summary>
      /// Remove an existing Prescription from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemovePrescription(Prescription oldPrescription)
      {
         if (oldPrescription == null)
            return;
         if (this.prescription != null)
            if (this.prescription.Contains(oldPrescription))
            {
               this.prescription.Remove(oldPrescription);
               oldPrescription.Patient = null;
            }
      }
      
      /// <summary>
      /// Remove all instances of Prescription from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllPrescription()
      {
         if (prescription != null)
         {
            System.Collections.ArrayList tmpPrescription = new System.Collections.ArrayList();
            foreach (Prescription oldPrescription in prescription)
               tmpPrescription.Add(oldPrescription);
            prescription.Clear();
            foreach (Prescription oldPrescription in tmpPrescription)
               oldPrescription.Patient = null;
            tmpPrescription.Clear();
         }
      }
   
   }
}