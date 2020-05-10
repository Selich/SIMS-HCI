// File:    PatientCotroller.cs
// Author:  Uros
// Created: Monday, May 4, 2020 8:27:25 PM
// Purpose: Definition of Class PatientCotroller

using System;

namespace Controller
{
   public class PatientCotroller
   {
      public Model.RegistredPatient RegisterPatient(string firstName, string lastName, string jmbg, string email, string telephoneNumber, string gender, DateTime dateOfBirth, string insuranceNumber, string proffesion, string password)
      {
         throw new NotImplementedException();
      }
      
      public Model.Patient RegisterGuest(int firstName, string firstName2, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, string insuranceNumber, string proffesion)
      {
         throw new NotImplementedException();
      }
      
      public Model.Patient GetPatient(string jmbg)
      {
         throw new NotImplementedException();
      }
      
      public Model.Anamneza AddPrecondition(string name, string type, string description)
      {
         throw new NotImplementedException();
      }
      
      public float AddWeight(float weight)
      {
         throw new NotImplementedException();
      }
      
      public float AddHeight(float height)
      {
         throw new NotImplementedException();
      }
      
   
   }
}