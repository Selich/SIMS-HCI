// File:    Order.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 8:05:24 PM
// Purpose: Definition of Class Order

using System;

public class Order
{
   private DateTime date;
   private string supplier;
   
   public System.Collections.Generic.List<Equipment> equipments;
   
   /// <summary>
   /// Property for collection of Equipment
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<Equipment> Equipments
   {
      get
      {
         if (equipments == null)
            equipments = new System.Collections.Generic.List<Equipment>();
         return equipments;
      }
      set
      {
         RemoveAllEquipments();
         if (value != null)
         {
            foreach (Equipment oEquipment in value)
               AddEquipments(oEquipment);
         }
      }
   }
   
   /// <summary>
   /// Add a new Equipment in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddEquipments(Equipment newEquipment)
   {
      if (newEquipment == null)
         return;
      if (this.equipments == null)
         this.equipments = new System.Collections.Generic.List<Equipment>();
      if (!this.equipments.Contains(newEquipment))
         this.equipments.Add(newEquipment);
   }
   
   /// <summary>
   /// Remove an existing Equipment from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveEquipments(Equipment oldEquipment)
   {
      if (oldEquipment == null)
         return;
      if (this.equipments != null)
         if (this.equipments.Contains(oldEquipment))
            this.equipments.Remove(oldEquipment);
   }
   
   /// <summary>
   /// Remove all instances of Equipment from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllEquipments()
   {
      if (equipments != null)
         equipments.Clear();
   }
   public System.Collections.Generic.List<Consumebles> consumebles;
   
   /// <summary>
   /// Property for collection of Consumebles
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<Consumebles> Consumebles
   {
      get
      {
         if (consumebles == null)
            consumebles = new System.Collections.Generic.List<Consumebles>();
         return consumebles;
      }
      set
      {
         RemoveAllConsumebles();
         if (value != null)
         {
            foreach (Consumebles oConsumebles in value)
               AddConsumebles(oConsumebles);
         }
      }
   }
   
   /// <summary>
   /// Add a new Consumebles in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddConsumebles(Consumebles newConsumebles)
   {
      if (newConsumebles == null)
         return;
      if (this.consumebles == null)
         this.consumebles = new System.Collections.Generic.List<Consumebles>();
      if (!this.consumebles.Contains(newConsumebles))
         this.consumebles.Add(newConsumebles);
   }
   
   /// <summary>
   /// Remove an existing Consumebles from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveConsumebles(Consumebles oldConsumebles)
   {
      if (oldConsumebles == null)
         return;
      if (this.consumebles != null)
         if (this.consumebles.Contains(oldConsumebles))
            this.consumebles.Remove(oldConsumebles);
   }
   
   /// <summary>
   /// Remove all instances of Consumebles from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllConsumebles()
   {
      if (consumebles != null)
         consumebles.Clear();
   }

}