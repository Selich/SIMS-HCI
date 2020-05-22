// File:    Employee.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:20:36 PM
// Purpose: Definition of Class Employee

using System;

namespace Model
{
   public class EmployeeDTO
   {
      public int id { get; set; }
      private DateTime dateOfBirth;
      public string firstName { get; set; }
      public string lastName { get; set; }
      public string jmbg { get; set; }
      public string telephoneNumber { get; set; }
      private string gender; 
      private double salary;
      public string email {get;set;}
      // TODO: TimeIntervalDTO
      private TimeInterval annualLeave;
      private TimeInterval workingHours;
      /////
   
      public EmployeeDTO() {}
   }
}