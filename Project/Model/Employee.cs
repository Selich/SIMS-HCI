// File:    Employee.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:20:36 PM
// Purpose: Definition of Class Employee

using System;

namespace Model
{
   public class Employee : User
   {
      private double salary;
      private TimeInterval annualLeave;
      private TimeInterval workingHours;
      private string email;
      private string password;
      
      public Hospital hospital;
   
   }
}