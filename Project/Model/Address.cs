// File:    Address.cs
// Author:  Selic
// Created: Tuesday, April 14, 2020 5:08:10 PM
// Purpose: Definition of Class Address

using System;

namespace Model
{
   public class Address
   {
      public string number {get;set;}
      public string street {get;set;}
      public string city {get;set;}
      public string country {get;set;}
      public string postCode {get;set;}
      
      public User[] user;
   
   }
}