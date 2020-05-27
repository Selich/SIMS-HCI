// File:    PatientCotroller.cs
// Author:  Uros
// Created: Monday, May 4, 2020 8:27:25 PM
// Purpose: Definition of Class PatientCotroller

using System;
using Project.Model;

namespace Controller
{
   public class PatientCotroller
   {
      public Patient RegisterPatient(string firstName, string lastName, string jmbg, string email, string telephoneNumber, string gender, DateTime dateOfBirth, string insuranceNumber, string proffesion, string password)
      {
         throw new NotImplementedException();
      }
      
      public Patient RegisterGuest(int firstName, string firstName2, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, string insuranceNumber, string proffesion)
      {
         throw new NotImplementedException();
      }
      
      public Patient GetPatient(int id)
      {
         throw new NotImplementedException();
      }
      
      public Anamneza AddPrecondition(string name, string type, string description)
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