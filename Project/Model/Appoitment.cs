// File:    Appoitment.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:31:07 PM
// Purpose: Definition of Class Appoitment

using System;

namespace Project.Model
{
   public class Appoitment
   {
      public DateTime beginning
      {get;set;}
      public DateTime end
      {get;set;}
      
      public Room room;
      public Appoitment() {}
      public Appoitment(DateTime beggining, DateTime end, Room room){
         this.beginning = beginning;
         this.end = end;
         this.room = room;
      }
   
   }
}