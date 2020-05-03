// File:    Approval.cs
// Author:  Selic
// Created: Saturday, April 18, 2020 12:54:58 AM
// Purpose: Definition of Class Approval

using System;

namespace Model
{
   public class Approval
   {
      private string description;
      private bool isApproved;
      
      public void Approve()
      {
         throw new NotImplementedException();
      }
      
      public Doctor doctor;
      
      /// <summary>
      /// Property for Doctor
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public Doctor Doctor
      {
         get
         {
            return doctor;
         }
         set
         {
            if (this.doctor == null || !this.doctor.Equals(value))
            {
               if (this.doctor != null)
               {
                  Doctor oldDoctor = this.doctor;
                  this.doctor = null;
                  oldDoctor.RemoveApproval(this);
               }
               if (value != null)
               {
                  this.doctor = value;
                  this.doctor.AddApproval(this);
               }
            }
         }
      }
   
   }
}