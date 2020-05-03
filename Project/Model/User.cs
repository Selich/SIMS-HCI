// File:    User.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:12:43 PM
// Purpose: Definition of Class User

using System;

namespace Model
{
   public class User
   {
      public DateTime dateOfBirth {get; set;}
      public string firstName {get;set;}
      public string lastName {get;set;}
      public string jmbg {get;set;}
      public string telephoneNumber{get;set;}
      public Sex gender {get;set;}
      
      
      public Feedback[] feedback;
      public Address address;
   
   }
}