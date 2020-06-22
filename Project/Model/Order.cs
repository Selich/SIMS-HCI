// File:    Order.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 8:05:24 PM
// Purpose: Definition of Class Order

using System;
using System.Collections.Generic;

namespace Project.Model
{
    public class Order : IIdentifiable<long>
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Supplier { get; set; }
        public List<Equipment> Equipments { get; set; }
        public List<Consumebles> Consumebles { get; set; }
        public Order(long id, DateTime date, string supplier, List<Equipment> equipments, List<Consumebles> consumebles)
        {
            Id = id;
            Date = date;
            Supplier = supplier;
            Equipments = equipments;
            Consumebles = consumebles;
        }

        public Order(DateTime date, string supplier, List<Equipment> equipments, List<Consumebles> consumebles)
        {
            Date = date;
            Supplier = supplier;
            Equipments = equipments;
            Consumebles = consumebles;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}