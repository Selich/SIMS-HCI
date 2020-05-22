// File:    Address.cs
// Author:  Selic
// Created: Tuesday, April 14, 2020 5:08:10 PM
// Purpose: Definition of Class Address

using System;

namespace Model
{
   public class Address
   {
      public int id {get;set;}
      private string number;
      private string street;
      private string city;
      private string country;
      private string postCode;
      
      public User[] user;

      public Address(){

      }
      public Address(int id,string number, string street, string city, string country, string postCode){
         this.id = id;
         this.number = number;
         this.street = street;
         this.city = city;
         this.country = country;
         this.postCode = postCode;

      }
   
   }
}