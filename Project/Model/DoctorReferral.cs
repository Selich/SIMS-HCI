// File:    DoctorReferral.cs
// Author:  Selic
// Created: Friday, April 17, 2020 2:13:16 PM
// Purpose: Definition of Class DoctorReferral

using System;

namespace Model
{
   public class DoctorReferral : Document
   {
      private string type;
      private DateTime date;
      public MedicalAppointment medicalAppointment;
   
   }
}