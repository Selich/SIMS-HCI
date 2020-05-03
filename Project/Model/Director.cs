// File:    Director.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:10:36 PM
// Purpose: Definition of Class Director

using System;

namespace Model
{
   public class Director : Employee
   {
      
      public System.Collections.ArrayList propositions;
      
      /// <summary>
      /// Property for collection of Proposition
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.ArrayList Propositions
      {
         get
         {
            if (propositions == null)
               propositions = new System.Collections.ArrayList();
            return propositions;
         }
         set
         {
            RemoveAllPropositions();
            if (value != null)
            {
               foreach (Proposition oProposition in value)
                  AddPropositions(oProposition);
            }
         }
      }
      
      /// <summary>
      /// Add a new Proposition in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddPropositions(Proposition newProposition)
      {
         if (newProposition == null)
            return;
         if (this.propositions == null)
            this.propositions = new System.Collections.ArrayList();
         if (!this.propositions.Contains(newProposition))
         {
            this.propositions.Add(newProposition);
            newProposition.Director = this;
         }
      }
      
      /// <summary>
      /// Remove an existing Proposition from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemovePropositions(Proposition oldProposition)
      {
         if (oldProposition == null)
            return;
         if (this.propositions != null)
            if (this.propositions.Contains(oldProposition))
            {
               this.propositions.Remove(oldProposition);
               oldProposition.Director = null;
            }
      }
      
      /// <summary>
      /// Remove all instances of Proposition from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllPropositions()
      {
         if (propositions != null)
         {
            System.Collections.ArrayList tmpPropositions = new System.Collections.ArrayList();
            foreach (Proposition oldProposition in propositions)
               tmpPropositions.Add(oldProposition);
            propositions.Clear();
            foreach (Proposition oldProposition in tmpPropositions)
               oldProposition.Director = null;
            tmpPropositions.Clear();
         }
      }
   
   }
}