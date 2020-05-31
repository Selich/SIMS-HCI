// File:    Appoitment.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:31:07 PM
// Purpose: Definition of Class Appoitment

using System;

namespace Project.Model
{
   public class Appointment { 
      public long Id { get; set; }
      public DateTime Beginning
      {get;set;}
      public DateTime End
      {get;set;}
      
      public Room Room;
      public Appointment() {}
      public Appointment(long id,DateTime beginning, DateTime end, Room room){
            Id = id;
         Beginning = beginning;
         End = end;
         Room = room;
      }
      public Appointment(DateTime beginning, DateTime end, Room room){
         Beginning = beginning;
         End = end;
         Room = room;
      }
   
   }
}