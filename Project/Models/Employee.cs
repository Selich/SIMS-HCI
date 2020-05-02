// File:    Employee.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:20:36 PM
// Purpose: Definition of Class Employee

using System;

public class Employee : RegistredUser
{
   private double salary;
   private TimeInterval annualLeave;
   private TimeInterval workingHours;
   
   public Report[] report;
   public Hospital hospital;

}