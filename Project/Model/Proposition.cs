// File:    Proposition.cs
// Author:  Selic
// Created: Saturday, April 18, 2020 12:29:10 AM
// Purpose: Definition of Class Proposition

using System;

namespace Model
{
   public class Proposition
   {
      private string state;
      
      public System.Collections.Generic.List<Approval> approval;
      
      /// <summary>
      /// Property for collection of Approval
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Approval> Approval
      {
         get
         {
            if (approval == null)
               approval = new System.Collections.Generic.List<Approval>();
            return approval;
         }
         set
         {
            RemoveAllApproval();
            if (value != null)
            {
               foreach (Approval oApproval in value)
                  AddApproval(oApproval);
            }
         }
      }
      
      /// <summary>
      /// Add a new Approval in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddApproval(Approval newApproval)
      {
         if (newApproval == null)
            return;
         if (this.approval == null)
            this.approval = new System.Collections.Generic.List<Approval>();
         if (!this.approval.Contains(newApproval))
            this.approval.Add(newApproval);
      }
      
      /// <summary>
      /// Remove an existing Approval from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveApproval(Approval oldApproval)
      {
         if (oldApproval == null)
            return;
         if (this.approval != null)
            if (this.approval.Contains(oldApproval))
               this.approval.Remove(oldApproval);
      }
      
      /// <summary>
      /// Remove all instances of Approval from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllApproval()
      {
         if (approval != null)
            approval.Clear();
      }
      public Medicine medicine;
      public Director director;
      
      /// <summary>
      /// Property for Director
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public Director Director
      {
         get
         {
            return director;
         }
         set
         {
            if (this.director == null || !this.director.Equals(value))
            {
               if (this.director != null)
               {
                  Director oldDirector = this.director;
                  this.director = null;
                  oldDirector.RemovePropositions(this);
               }
               if (value != null)
               {
                  this.director = value;
                  this.director.AddPropositions(this);
               }
            }
         }
      }
   
   }
}