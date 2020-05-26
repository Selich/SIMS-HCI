// File:    Hospital.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 8:23:57 PM
// Purpose: Definition of Class Hospital

using System;

namespace Project.Model
{
   public class Hospital
   {
      private string name;
      
      public System.Collections.Generic.List<Medicine> medicines;
      
      /// <summary>
      /// Property for collection of Medicine
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Medicine> Medicines
      {
         get
         {
            if (medicines == null)
               medicines = new System.Collections.Generic.List<Medicine>();
            return medicines;
         }
         set
         {
            RemoveAllMedicines();
            if (value != null)
            {
               foreach (Medicine oMedicine in value)
                  AddMedicines(oMedicine);
            }
         }
      }
      
      /// <summary>
      /// Add a new Medicine in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddMedicines(Medicine newMedicine)
      {
         if (newMedicine == null)
            return;
         if (this.medicines == null)
            this.medicines = new System.Collections.Generic.List<Medicine>();
         if (!this.medicines.Contains(newMedicine))
            this.medicines.Add(newMedicine);
      }
      
      /// <summary>
      /// Remove an existing Medicine from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveMedicines(Medicine oldMedicine)
      {
         if (oldMedicine == null)
            return;
         if (this.medicines != null)
            if (this.medicines.Contains(oldMedicine))
               this.medicines.Remove(oldMedicine);
      }
      
      /// <summary>
      /// Remove all instances of Medicine from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllMedicines()
      {
         if (medicines != null)
            medicines.Clear();
      }
      public Employee[] employees;
      public Address address;
      public System.Collections.Generic.List<Room> rooms;
      
      /// <summary>
      /// Property for collection of Room
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Room> Rooms
      {
         get
         {
            if (rooms == null)
               rooms = new System.Collections.Generic.List<Room>();
            return rooms;
         }
         set
         {
            RemoveAllRooms();
            if (value != null)
            {
               foreach (Room oRoom in value)
                  AddRooms(oRoom);
            }
         }
      }
      
      /// <summary>
      /// Add a new Room in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddRooms(Room newRoom)
      {
         if (newRoom == null)
            return;
         if (this.rooms == null)
            this.rooms = new System.Collections.Generic.List<Room>();
         if (!this.rooms.Contains(newRoom))
         {
            this.rooms.Add(newRoom);
            newRoom.Hospital = this;
         }
      }
      
      /// <summary>
      /// Remove an existing Room from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveRooms(Room oldRoom)
      {
         if (oldRoom == null)
            return;
         if (this.rooms != null)
            if (this.rooms.Contains(oldRoom))
            {
               this.rooms.Remove(oldRoom);
               oldRoom.Hospital = null;
            }
      }
      
      /// <summary>
      /// Remove all instances of Room from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllRooms()
      {
         if (rooms != null)
         {
            System.Collections.ArrayList tmpRooms = new System.Collections.ArrayList();
            foreach (Room oldRoom in rooms)
               tmpRooms.Add(oldRoom);
            rooms.Clear();
            foreach (Room oldRoom in tmpRooms)
               oldRoom.Hospital = null;
            tmpRooms.Clear();
         }
      }
      public System.Collections.Generic.List<MedicalConsumables> consumables;
      
      /// <summary>
      /// Property for collection of MedicalConsumables
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<MedicalConsumables> Consumables
      {
         get
         {
            if (consumables == null)
               consumables = new System.Collections.Generic.List<MedicalConsumables>();
            return consumables;
         }
         set
         {
            RemoveAllConsumables();
            if (value != null)
            {
               foreach (MedicalConsumables oMedicalConsumables in value)
                  AddConsumables(oMedicalConsumables);
            }
         }
      }
      
      /// <summary>
      /// Add a new MedicalConsumables in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddConsumables(MedicalConsumables newMedicalConsumables)
      {
         if (newMedicalConsumables == null)
            return;
         if (this.consumables == null)
            this.consumables = new System.Collections.Generic.List<MedicalConsumables>();
         if (!this.consumables.Contains(newMedicalConsumables))
            this.consumables.Add(newMedicalConsumables);
      }
      
      /// <summary>
      /// Remove an existing MedicalConsumables from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveConsumables(MedicalConsumables oldMedicalConsumables)
      {
         if (oldMedicalConsumables == null)
            return;
         if (this.consumables != null)
            if (this.consumables.Contains(oldMedicalConsumables))
               this.consumables.Remove(oldMedicalConsumables);
      }
      
      /// <summary>
      /// Remove all instances of MedicalConsumables from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllConsumables()
      {
         if (consumables != null)
            consumables.Clear();
      }
   
   }
}