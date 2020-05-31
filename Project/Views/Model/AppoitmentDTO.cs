// File:    Appoitment.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:31:07 PM
// Purpose: Definition of Class Appoitment

using System;

namespace Project.Views.Model
{
   public class AppoitmentDTO
   {
      public DateTime Beginning
      {get;set;}
      public DateTime End
      {get;set;}
      
      public RoomDTO Room;
      public AppoitmentDTO() {}
      public AppoitmentDTO(DateTime beginning, DateTime end, RoomDTO room){
         Beginning = beginning;
         End = end;
         Room = room;
      }
   
   }
}