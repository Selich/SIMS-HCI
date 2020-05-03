// File:    MedicalChart.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:10:36 PM
// Purpose: Definition of Class MedicalChart

using System;

namespace Model
{
   public class MedicalChart
   {
      private int id;
      private float weight;
      private float height;
      private string bloodType;
      
      public System.Collections.Generic.List<Allergie> allergies;
      
      /// <summary>
      /// Property for collection of Allergie
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Allergie> Allergies
      {
         get
         {
            if (allergies == null)
               allergies = new System.Collections.Generic.List<Allergie>();
            return allergies;
         }
         set
         {
            RemoveAllAllergies();
            if (value != null)
            {
               foreach (Allergie oAllergie in value)
                  AddAllergies(oAllergie);
            }
         }
      }
      
      /// <summary>
      /// Add a new Allergie in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddAllergies(Allergie newAllergie)
      {
         if (newAllergie == null)
            return;
         if (this.allergies == null)
            this.allergies = new System.Collections.Generic.List<Allergie>();
         if (!this.allergies.Contains(newAllergie))
            this.allergies.Add(newAllergie);
      }
      
      /// <summary>
      /// Remove an existing Allergie from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveAllergies(Allergie oldAllergie)
      {
         if (oldAllergie == null)
            return;
         if (this.allergies != null)
            if (this.allergies.Contains(oldAllergie))
               this.allergies.Remove(oldAllergie);
      }
      
      /// <summary>
      /// Remove all instances of Allergie from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllAllergies()
      {
         if (allergies != null)
            allergies.Clear();
      }
      public System.Collections.Generic.List<Anamneza> preconditions;
      
      /// <summary>
      /// Property for collection of Anamneza
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Anamneza> Preconditions
      {
         get
         {
            if (preconditions == null)
               preconditions = new System.Collections.Generic.List<Anamneza>();
            return preconditions;
         }
         set
         {
            RemoveAllPreconditions();
            if (value != null)
            {
               foreach (Anamneza oAnamneza in value)
                  AddPreconditions(oAnamneza);
            }
         }
      }
      
      /// <summary>
      /// Add a new Anamneza in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddPreconditions(Anamneza newAnamneza)
      {
         if (newAnamneza == null)
            return;
         if (this.preconditions == null)
            this.preconditions = new System.Collections.Generic.List<Anamneza>();
         if (!this.preconditions.Contains(newAnamneza))
            this.preconditions.Add(newAnamneza);
      }
      
      /// <summary>
      /// Remove an existing Anamneza from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemovePreconditions(Anamneza oldAnamneza)
      {
         if (oldAnamneza == null)
            return;
         if (this.preconditions != null)
            if (this.preconditions.Contains(oldAnamneza))
               this.preconditions.Remove(oldAnamneza);
      }
      
      /// <summary>
      /// Remove all instances of Anamneza from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllPreconditions()
      {
         if (preconditions != null)
            preconditions.Clear();
      }
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
            newDocument.MedicalChart = this;
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
               oldDocument.MedicalChart = null;
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
               oldDocument.MedicalChart = null;
            tmpDocuments.Clear();
         }
      }
   
   }
}