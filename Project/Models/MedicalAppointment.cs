// File:    MedicalAppointment.cs
// Author:  Selic
// Created: Saturday, April 18, 2020 1:03:03 AM
// Purpose: Definition of Class MedicalAppointment

using System;

public class MedicalAppointment : Appoitment
{
   public System.Collections.Generic.List<Document> documents;
   /// <summary>
   /// Property for collection of Document
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<Document> Documents
   {
      get
      {
         if (documents == null)
            documents = new System.Collections.Generic.List<Document>();
         return documents;
      }
      set
      {
         RemoveAllDocuments();
         if (value != null)
         {
            foreach (Document oDocument in value)
               AddDocuments(oDocument);
         }
      }
   }
   public Doctor[] doctors;

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
               oldPatient.RemoveAppointments(this);
            }
            if (value != null)
            {
               this.patient = value;
               this.patient.AddAppointments(this);
            }
         }
      }
   }
   
   
   /// <summary>
   /// Add a new Document in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddDocuments(Document newDocument)
   {
      if (newDocument == null)
         return;
      if (this.documents == null)
         this.documents = new System.Collections.Generic.List<Document>();
      if (!this.documents.Contains(newDocument))
      {
         this.documents.Add(newDocument);
         newDocument.MedicalAppointment = this;
      }
   }
   
   /// <summary>
   /// Remove an existing Document from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveDocuments(Document oldDocument)
   {
      if (oldDocument == null)
         return;
      if (this.documents != null)
         if (this.documents.Contains(oldDocument))
         {
            this.documents.Remove(oldDocument);
            oldDocument.MedicalAppointment = null;
         }
   }
   
   /// <summary>
   /// Remove all instances of Document from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllDocuments()
   {
      if (documents != null)
      {
         System.Collections.ArrayList tmpDocuments = new System.Collections.ArrayList();
         foreach (Document oldDocument in documents)
            tmpDocuments.Add(oldDocument);
         documents.Clear();
         foreach (Document oldDocument in tmpDocuments)
            oldDocument.MedicalAppointment = null;
         tmpDocuments.Clear();
      }
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

}