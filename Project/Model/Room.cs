// File:    Room.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:33:59 PM
// Purpose: Definition of Class Room

using System;

namespace Project.Model
{
   public class Room
   {
      public int id { get; set; }
      public RoomType type{get;set;}
      public string ward {get;set;}
      public string floor {get;set;}

      public Room () {}
      public Room (int id, RoomType type, string ward, string floor) {
         this.id = id;
         this.type = type;
         this.ward = ward;
         this.floor = floor;

      }
      
      public System.Collections.Generic.List<Equipment> equipment;
      
      /// <summary>
      /// Property for collection of Equipment
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Equipment> Equipment
      {
         get
         {
            if (equipment == null)
               equipment = new System.Collections.Generic.List<Equipment>();
            return equipment;
         }
         set
         {
            RemoveAllEquipment();
            if (value != null)
            {
               foreach (Equipment oEquipment in value)
                  AddEquipment(oEquipment);
            }
         }
      }
      
      /// <summary>
      /// Add a new Equipment in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddEquipment(Equipment newEquipment)
      {
         if (newEquipment == null)
            return;
         if (this.equipment == null)
            this.equipment = new System.Collections.Generic.List<Equipment>();
         if (!this.equipment.Contains(newEquipment))
            this.equipment.Add(newEquipment);
      }
      
      /// <summary>
      /// Remove an existing Equipment from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveEquipment(Equipment oldEquipment)
      {
         if (oldEquipment == null)
            return;
         if (this.equipment != null)
            if (this.equipment.Contains(oldEquipment))
               this.equipment.Remove(oldEquipment);
      }
      
      /// <summary>
      /// Remove all instances of Equipment from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllEquipment()
      {
         if (equipment != null)
            equipment.Clear();
      }
      public Appointment[] appointments;
      public Hospital hospital;
      
      /// <summary>
      /// Property for Hospital
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public Hospital Hospital
      {
         get
         {
            return hospital;
         }
         set
         {
            if (this.hospital == null || !this.hospital.Equals(value))
            {
               if (this.hospital != null)
               {
                  Hospital oldHospital = this.hospital;
                  this.hospital = null;
                  oldHospital.RemoveRooms(this);
               }
               if (value != null)
               {
                  this.hospital = value;
                  this.hospital.AddRooms(this);
               }
            }
         }
      }
   
   }
}