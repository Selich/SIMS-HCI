// File:    Room.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:33:59 PM
// Purpose: Definition of Class Room

using System;
using System.Collections.Generic;
using Project.Model;

namespace Project.Views.Model
{
   public class RoomDTO
   {
      public int Id { get; set; }
      public RoomType Type{get;set;}
      public string Ward {get;set;}
      public string Floor {get;set;}
      
      public List<EquipmentDTO> Equipment { get; set; }
      public List<AppointmentDTO> Appointments { get; set; }

      public RoomDTO() {}
      public RoomDTO(int id, RoomType type, string ward, string floor) {
         Id = id;
         Type = type;
         Ward = ward;
         Floor = floor;

      }
   
   }
}