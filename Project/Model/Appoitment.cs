// File:    Appoitment.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:31:07 PM
// Purpose: Definition of Class Appoitment

using System;

namespace Model
{
   public class Appoitment
   {
      public DateTime begining
      {get;set;}
      public DateTime end
      {get;set;}
      
      public Room room;
   
   }
}