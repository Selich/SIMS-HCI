// File:    Medicine.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:29:51 PM
// Purpose: Definition of Class Medicine

using System;

public class Medicine : Consumebles
{
   private int id;
   private string purpose;
   private string administration;
   private bool approved;
   
   public Prescription[] prescription;
   public Proposition proposition;
   public System.Collections.Generic.List<Medicine> alternatives;
   
   /// <summary>
   /// Property for collection of Medicine
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<Medicine> Alternatives
   {
      get
      {
         if (alternatives == null)
            alternatives = new System.Collections.Generic.List<Medicine>();
         return alternatives;
      }
      set
      {
         RemoveAllAlternatives();
         if (value != null)
         {
            foreach (Medicine oMedicine in value)
               AddAlternatives(oMedicine);
         }
      }
   }
   
   /// <summary>
   /// Add a new Medicine in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddAlternatives(Medicine newMedicine)
   {
      if (newMedicine == null)
         return;
      if (this.alternatives == null)
         this.alternatives = new System.Collections.Generic.List<Medicine>();
      if (!this.alternatives.Contains(newMedicine))
         this.alternatives.Add(newMedicine);
   }
   
   /// <summary>
   /// Remove an existing Medicine from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveAlternatives(Medicine oldMedicine)
   {
      if (oldMedicine == null)
         return;
      if (this.alternatives != null)
         if (this.alternatives.Contains(oldMedicine))
            this.alternatives.Remove(oldMedicine);
   }
   
   /// <summary>
   /// Remove all instances of Medicine from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllAlternatives()
   {
      if (alternatives != null)
         alternatives.Clear();
   }

}