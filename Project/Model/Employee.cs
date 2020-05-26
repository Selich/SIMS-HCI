// File:    Employee.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:20:36 PM
// Purpose: Definition of Class Employee

using System;

namespace Project.Model
{
   public class Employee : User
   {
      public int id { get; set; }
      private double salary;
      private TimeInterval annualLeave;
      private TimeInterval workingHours;
      public string email
      {get;set;}
      private string password;
      
      public Hospital hospital;
   
      public Employee() {}
      public Employee(string firstName, string lastName): base(firstName,lastName) {}
   }
}