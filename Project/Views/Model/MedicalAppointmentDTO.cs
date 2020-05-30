// File:    MedicalAppointment.cs
// Author:  Selic
// Created: Saturday, April 18, 2020 1:03:03 AM
// Purpose: Definition of Class MedicalAppointment

using System;
using System.Windows.Documents;

namespace Project.Entity
{
    public class MedicalAppointmentDTO : AppoitmentDTO
    {
        public int id
        { get; set; }
        public Model.MedicalAppointmentType type
        { get; set; }
        public System.Collections.Generic.List<DoctorDTO> Doctors { get; set; }
        private GuestDTO patient { get; set; }
      
      public MedicalAppointmentDTO(){}
    
      public ReviewDTO review { get; set; }


        //public MedicalAppointmentDTO(int id, DateTime beginning, DateTime end, RoomDTO room, MedicalAppointmentType type, GuestDTO patient, System.Collections.Generic.List<DoctorDTO> doctors) 
        //: base(beginning, end, room){
        //   this.id = id;
        //   this.type = type;
        //   this.patient = patient;
        //   this.Doctors = doctors;
        //}

        public System.Collections.Generic.List<ConsumeblesDTO> consumebles;
      
      /// <summary>
      /// Property for collection of Consumebles
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<ConsumeblesDTO> Consumebles
      {
         get
         {
            if (consumebles == null)
               consumebles = new System.Collections.Generic.List<ConsumeblesDTO>();
            return consumebles;
         }
         set
         {
            RemoveAllConsumebles();
            if (value != null)
            {
               foreach (ConsumeblesDTO oConsumebles in value)
                  AddConsumebles(oConsumebles);
            }
         }
      }
      
      /// <summary>
      /// Add a new Consumebles in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddConsumebles(ConsumeblesDTO newConsumebles)
      {
         if (newConsumebles == null)
            return;
         if (this.consumebles == null)
            this.consumebles = new System.Collections.Generic.List<ConsumeblesDTO>();
         if (!this.consumebles.Contains(newConsumebles))
            this.consumebles.Add(newConsumebles);
      }
      
      /// <summary>
      /// Remove an existing Consumebles from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveConsumebles(ConsumeblesDTO oldConsumebles)
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
      public System.Collections.Generic.List<AnamnezaDTO> anamneza;
      
      /// <summary>
      /// Property for collection of Anamneza
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<AnamnezaDTO> Anamneza
      {
         get
         {
            if (anamneza == null)
               anamneza = new System.Collections.Generic.List<AnamnezaDTO>();
            return anamneza;
         }
         set
         {
            RemoveAllAnamneza();
            if (value != null)
            {
               foreach (AnamnezaDTO oAnamneza in value)
                  AddAnamneza(oAnamneza);
            }
         }
      }
      
      /// <summary>
      /// Add a new Anamneza in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddAnamneza(AnamnezaDTO newAnamneza)
      {
         if (newAnamneza == null)
            return;
         if (this.anamneza == null)
            this.anamneza = new System.Collections.Generic.List<AnamnezaDTO>();
         if (!this.anamneza.Contains(newAnamneza))
            this.anamneza.Add(newAnamneza);
      }
      
      /// <summary>
      /// Remove an existing Anamneza from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveAnamneza(AnamnezaDTO oldAnamneza)
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

   }
}