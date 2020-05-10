// File:    EmployeeController.cs
// Author:  Selic
// Created: Thursday, April 30, 2020 10:17:54 PM
// Purpose: Definition of Class EmployeeController

using System;

namespace Controller
{
   public class EmployeeController
   {
      public Model.Employee RegisterEmployee(string firstName, string lastName, string jmbg, string telephoneNumber, Model.Sex gender, string email, string password, string role, string number, string street, string city, string country, string postCode)
      {
         throw new NotImplementedException();
      }
      
      public void SetSalary(double salary, String jmbg)
      {
         throw new NotImplementedException();
      }
      
      public void SetAnnualLeave(Model.TimeInterval period)
      {
         throw new NotImplementedException();
      }
      
      public void SetWorkingHours(Model.TimeInterval hours)
      {
         throw new NotImplementedException();
      }
      
      public Model.Employee UpdateEmployee(Model.Employee employee)
      {
         throw new NotImplementedException();
      }
      
      public Model.Employee DeleteEmployee(Model.Employee employee)
      {
         throw new NotImplementedException();
      }
   
   }
}