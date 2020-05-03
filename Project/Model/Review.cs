// File:    Review.cs
// Author:  Uros
// Created: Friday, April 17, 2020 5:21:46 PM
// Purpose: Definition of Class Review

using System;

namespace Model
{
   public class Review
   {
      private int rating;
      private string discription;
      
      public System.Collections.Generic.List<RegistredPatient> registredPatient;
      
      /// <summary>
      /// Property for collection of RegistredPatient
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<RegistredPatient> RegistredPatient
      {
         get
         {
            if (registredPatient == null)
               registredPatient = new System.Collections.Generic.List<RegistredPatient>();
            return registredPatient;
         }
         set
         {
            RemoveAllRegistredPatient();
            if (value != null)
            {
               foreach (RegistredPatient oRegistredPatient in value)
                  AddRegistredPatient(oRegistredPatient);
            }
         }
      }
      
      /// <summary>
      /// Add a new RegistredPatient in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddRegistredPatient(RegistredPatient newRegistredPatient)
      {
         if (newRegistredPatient == null)
            return;
         if (this.registredPatient == null)
            this.registredPatient = new System.Collections.Generic.List<RegistredPatient>();
         if (!this.registredPatient.Contains(newRegistredPatient))
         {
            this.registredPatient.Add(newRegistredPatient);
            newRegistredPatient.Review = this;
         }
      }
      
      /// <summary>
      /// Remove an existing RegistredPatient from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveRegistredPatient(RegistredPatient oldRegistredPatient)
      {
         if (oldRegistredPatient == null)
            return;
         if (this.registredPatient != null)
            if (this.registredPatient.Contains(oldRegistredPatient))
            {
               this.registredPatient.Remove(oldRegistredPatient);
               oldRegistredPatient.Review = null;
            }
      }
      
      /// <summary>
      /// Remove all instances of RegistredPatient from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllRegistredPatient()
      {
         if (registredPatient != null)
         {
            System.Collections.ArrayList tmpRegistredPatient = new System.Collections.ArrayList();
            foreach (RegistredPatient oldRegistredPatient in registredPatient)
               tmpRegistredPatient.Add(oldRegistredPatient);
            registredPatient.Clear();
            foreach (RegistredPatient oldRegistredPatient in tmpRegistredPatient)
               oldRegistredPatient.Review = null;
            tmpRegistredPatient.Clear();
         }
      }
   
   }
}