// File:    DoctorReferral.cs
// Author:  Selic
// Created: Friday, April 17, 2020 2:13:16 PM
// Purpose: Definition of Class DoctorReferral

using System;

public class DoctorReferral : Document
{
   private string type;
   private DateTime date;
   
   public Doctor referredDoctor;
   
   /// <summary>
   /// Property for Doctor
   /// </summary>
   /// <pdGenerated>Default opposite class property</pdGenerated>
   public Doctor ReferredDoctor
   {
      get
      {
         return referredDoctor;
      }
      set
      {
         if (this.referredDoctor == null || !this.referredDoctor.Equals(value))
         {
            if (this.referredDoctor != null)
            {
               Doctor oldDoctor = this.referredDoctor;
               this.referredDoctor = null;
               oldDoctor.RemoveDoctorReferral(this);
            }
            if (value != null)
            {
               this.referredDoctor = value;
               this.referredDoctor.AddDoctorReferral(this);
            }
         }
      }
   }

}