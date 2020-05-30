// File:    Appoitment.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:31:07 PM
// Purpose: Definition of Class Appoitment

using System;

namespace Project.Model
{
   public class Appoitment
   {
      public DateTime Beginning
      {get;set;}
      public DateTime End
      {get;set;}
      
      public Room Room;
      public Appoitment() {}
      public Appoitment(DateTime beginning, DateTime end, Room room){
         Beginning = beginning;
         End = end;
         Room = room;
      }
   
   }
}