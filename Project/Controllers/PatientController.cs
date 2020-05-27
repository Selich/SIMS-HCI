// File:    PatientCotroller.cs
// Author:  Uros
// Created: Monday, May 4, 2020 8:27:25 PM
// Purpose: Definition of Class PatientCotroller

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Project.Controllers;
using Project.Entity;
using Project.Model;
using Project.Services;

namespace Project.Controllers
{
   public class PatientController : IController<Patient, long>
   {
      private IService<Patient, long> _service;
    
      public PatientController(IService<Patient, long> service)
      {
            _service = service;

      }
        public IEnumerable<Patient> GetAll()
        {
            throw new NotImplementedException();
        }

        public Patient Get(long id)
        {
            throw new NotImplementedException();
        }

        public Patient Create(string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, string insuranceNumber, string proffesion, string bloodType, float height, float weight, string email, string password)
            => _service.Create(new Patient(new Address(), firstName, lastName, jmbg, email, telephoneNumber, dateOfBirth, insuranceNumber, proffesion, bloodType, height, weight, email, password));

        internal void Create(PatientDTO patientDTO)
            => _service.Create(new Patient(
                new Address(),
                patientDTO.FirstName, 
                patientDTO.LastName, 
                patientDTO.Jmbg, 
                patientDTO.TelephoneNumber, 
                patientDTO.Gender, 
                patientDTO.DateOfBirth, 
                patientDTO.InsurenceNumber, 
                patientDTO.Profession, 
                patientDTO.BloodType, 
                patientDTO.Height, 
                patientDTO.Weight, 
                patientDTO.Email, 
                patientDTO.Password));
        public Patient Create(Patient entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Patient entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Patient entity)
        {
            throw new NotImplementedException();
        }
      
      public Patient RegisterGuest(long id, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, string insuranceNumber, string proffesion)
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