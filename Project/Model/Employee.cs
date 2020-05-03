// File:    Employee.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:20:36 PM
// Purpose: Definition of Class Employee

using System;

namespace Model
{
   public class Employee : User
   {
      public double salary {get;set;}
      public TimeInterval annualLeave {get;set;}
      public TimeInterval workingHours {get;set;}
      public string email {get;set;}
      public string password {get;set;}
      
      public Report[] report;
      public Hospital hospital;
   
   }
}