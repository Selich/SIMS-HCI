// File:    MedicalAppointmentController.cs
// Author:  Selic
// Created: Thursday, May 7, 2020 7:52:18 PM
// Purpose: Definition of Class MedicalAppointmentController

using System;
using Project.Model;

namespace Controller
{
   public class MedicalAppointmentController
   {
      public MedicalAppointmentController EditMedicalAppointment(string type, DateTime date, TimeSpan time, Array doctorsID, int patientID, int roomID)
      {
         throw new NotImplementedException();
      }
      
      public MedicalAppointment GetAllMedicalAppoitmentsDoctor(DateTime beggining, DateTime end, string doctorJMBG)
      {
         throw new NotImplementedException();
      }
      
      public MedicalAppointment GetAllMedicalAppoitmentsPatinet(DateTime beggining, DateTime end, string patientJMBG)
      {
         throw new NotImplementedException();
      }
      
      public MedicalAppointment GetMedicalAppotment(int appotmentId)
      {
         throw new NotImplementedException();
      }
      
      public MedicalAppointment ScheduleMedicalAppoitment(MedicalAppointmentType type, DateTime period)
      {
         throw new NotImplementedException();
      }
   
   }
}