// File:    Employee.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:20:36 PM
// Purpose: Definition of Class Employee

using System;

namespace Project.Model
{
   public class Employee : User
   {
      public double Salary { get; set; }
      private TimeInterval AnnualLeave { get; set; }
      private TimeInterval WorkingHours { get; set; }
      public string Email {get;set;}
      private string Password {get;set;}
      
      public Hospital Hospital { get; set; }
   
      public Employee() {}
      public Employee(long id, Address address,string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, double salary, TimeInterval annualLeave, TimeInterval workingHours, string email, string password): 
            base( id,  address, firstName,  lastName,  jmbg,  telephoneNumber,  gender,  dateOfBirth) {
            Salary = salary;
            AnnualLeave = annualLeave;
            WorkingHours = workingHours;
            Email = email;
            Password = password;
      }

        public Employee(Address address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, double salary, TimeInterval annualLeave, TimeInterval workingHours, string email, string password)
        {
            Address = address;
            FirstName = firstName;
            LastName = lastName;
            Jmbg = jmbg;
            TelephoneNumber = telephoneNumber;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Salary = salary;
            AnnualLeave = annualLeave;
            WorkingHours = workingHours;
            Email = email;
            Password = password;
        }
    }
}