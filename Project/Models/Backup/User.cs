// File:    User.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:12:43 PM
// Purpose: Definition of Class User

using System;

public class User
{
   private DateTime dateOfBirth;
   private string firstName;
   private string lastName;
   private string jmbg;
   private string telephoneNumber;
   private Sex gender;
   
   public User()
   {
      throw new NotImplementedException();
   }
   
   public Feedback[] feedback;
   public Address address;

}