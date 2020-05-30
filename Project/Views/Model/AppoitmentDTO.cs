// File:    Appoitment.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:31:07 PM
// Purpose: Definition of Class Appoitment

using System;

namespace Project.Entity
{
   public class AppoitmentDTO
   {
      public DateTime beginning
      {get;set;}
      public DateTime end
      {get;set;}
      
      public RoomDTO room;
      public AppoitmentDTO() {}
      public AppoitmentDTO(DateTime beggining, DateTime end, RoomDTO room){
         this.beginning = beginning;
         this.end = end;
         this.room = room;
      }
   
   }
}