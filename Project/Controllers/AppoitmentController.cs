// File:    AppoitmentController.cs
// Author:  Uros
// Created: Monday, May 4, 2020 10:01:44 PM
// Purpose: Definition of Class AppoitmentController

using System;

namespace Controller
{
   public class AppoitmentController
   {
      public Model.MedicalAppointment ScheduleMedicalAppoitment(Model.MedicalAppointmentType type, DateTime period)
      {
         throw new NotImplementedException();
      }
      
      public Model.MedicalAppointment GetMedicalAppotment(int appotmentId)
      {
         throw new NotImplementedException();
      }
      
      public Model.MedicalAppointment GetAllMedicalAppoitmentsPatinet(DateTime beggining, DateTime end, string patientJMBG)
      {
         throw new NotImplementedException();
      }
      
      public Model.MedicalAppointment GetAllMedicalAppoitmentsDoctor(DateTime beggining, DateTime end, string doctorJMBG)
      {
         throw new NotImplementedException();
      }
   
   }
}