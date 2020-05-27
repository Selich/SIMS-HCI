// File:    MedicalAppointment.cs
// Author:  Selic
// Created: Saturday, April 18, 2020 1:03:03 AM
// Purpose: Definition of Class MedicalAppointment

using System;
using System.Windows.Documents;

namespace Project.Model
{
    public class MedicalAppointment : Appoitment
    {
        public int id
        { get; set; }
        public MedicalAppointmentType type
        { get; set; }
        public System.Collections.Generic.List<Doctor> doctors;
        public Guest patient;
      
      public MedicalAppointment(){}

      public MedicalAppointment(int id, DateTime beginning, DateTime end, Room room, MedicalAppointmentType type, Guest patient, System.Collections.Generic.List<Doctor> doctors) 
      : base(beginning, end, room){
         this.id = id;
         this.type = type;
         this.patient = patient;
         this.doctors = doctors;
      }
      
      public System.Collections.Generic.List<Consumebles> consumebles;
      
      /// <summary>
      /// Property for collection of Consumebles
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Consumebles> Consumebles
      {
         get
         {
            if (consumebles == null)
               consumebles = new System.Collections.Generic.List<Consumebles>();
            return consumebles;
         }
         set
         {
            RemoveAllConsumebles();
            if (value != null)
            {
               foreach (Consumebles oConsumebles in value)
                  AddConsumebles(oConsumebles);
            }
         }
      }
      
      /// <summary>
      /// Add a new Consumebles in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddConsumebles(Consumebles newConsumebles)
      {
         if (newConsumebles == null)
            return;
         if (this.consumebles == null)
            this.consumebles = new System.Collections.Generic.List<Consumebles>();
         if (!this.consumebles.Contains(newConsumebles))
            this.consumebles.Add(newConsumebles);
      }
      
      /// <summary>
      /// Remove an existing Consumebles from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveConsumebles(Consumebles oldConsumebles)
      {
         if (oldConsumebles == null)
            return;
         if (this.consumebles != null)
            if (this.consumebles.Contains(oldConsumebles))
               this.consumebles.Remove(oldConsumebles);
      }
      
      /// <summary>
      /// Remove all instances of Consumebles from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllConsumebles()
      {
         if (consumebles != null)
            consumebles.Clear();
      }
      public Review review;
      public System.Collections.Generic.List<Anamneza> anamneza;
      
      /// <summary>
      /// Property for collection of Anamneza
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Anamneza> Anamneza
      {
         get
         {
            if (anamneza == null)
               anamneza = new System.Collections.Generic.List<Anamneza>();
            return anamneza;
         }
         set
         {
            RemoveAllAnamneza();
            if (value != null)
            {
               foreach (Anamneza oAnamneza in value)
                  AddAnamneza(oAnamneza);
            }
         }
      }
      
      /// <summary>
      /// Add a new Anamneza in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddAnamneza(Anamneza newAnamneza)
      {
         if (newAnamneza == null)
            return;
         if (this.anamneza == null)
            this.anamneza = new System.Collections.Generic.List<Anamneza>();
         if (!this.anamneza.Contains(newAnamneza))
            this.anamneza.Add(newAnamneza);
      }
      
      /// <summary>
      /// Remove an existing Anamneza from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveAnamneza(Anamneza oldAnamneza)
      {
         if (oldAnamneza == null)
            return;
         if (this.anamneza != null)
            if (this.anamneza.Contains(oldAnamneza))
               this.anamneza.Remove(oldAnamneza);
      }
      
      /// <summary>
      /// Remove all instances of Anamneza from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllAnamneza()
      {
         if (anamneza != null)
            anamneza.Clear();
      }
        /// <summary>
        /// Property for Patient
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public Guest Patient;
   }
}