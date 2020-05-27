// File:    AppoitmentController.cs
// Author:  Uros
// Created: Monday, May 4, 2020 10:01:44 PM
// Purpose: Definition of Class AppoitmentController

using System;
using Project.Model;

namespace Project.Controller
{
   public class AppoitmentController
   {
      public MedicalAppointment ScheduleMedicalAppoitment(string type, DateTime period)
      {
         throw new NotImplementedException();
      }
      
      public MedicalAppointment GetMedicalAppotment(int appotmentId)
      {
         throw new NotImplementedException();
      }
      
      public MedicalAppointment GetAllMedicalAppoitmentsPatinet(DateTime beggining, DateTime end, string patientJMBG)
      {
         throw new NotImplementedException();
      }
      
      public MedicalAppointment GetAllMedicalAppoitmentsDoctor(DateTime beggining, DateTime end, string doctorJMBG)
      {
         throw new NotImplementedException();
      }
   
   }
}