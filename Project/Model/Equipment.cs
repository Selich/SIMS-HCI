// File:    Equipment.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:30:11 PM
// Purpose: Definition of Class Equipment

using System;
using Project.Repositories.Abstract;

namespace Project.Model
{
    public class Equipment : IIdentifiable<long>
    {
        public long Id;
        public string Type { get; set; }
        public string Description;
        public string Name { get; set; }

        public Room Room { get; set; }
        public Equipment() { }

        public Equipment(string type, string description, string name)
        {
            Type = type;
            Description = description;
            Name = name;
        }

        public Equipment(string type, string description, string name,Room room)
        {
            Type = type;
            Description = description;
            Name = name;
            Room = room;
        }
        public Equipment(long id, string type, string description, string name)
        {
            Id = id;
            Type = type;
            Description = description;
            Name = name;
        }
        public Equipment(long id, string type, string description, string name,Room room)
        {
            Id = id;
            Type = type;
            Description = description;
            Name = name;
            Room = room;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}