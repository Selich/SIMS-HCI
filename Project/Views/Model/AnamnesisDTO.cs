// File:    Anamneza.cs
// Author:  Selic
// Created: Friday, March 20, 2020 10:32:33 PM
// Purpose: Definition of Class Anamneza

using System;

namespace Project.Views.Model
{
   public class AnamnesisDTO
   {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public AnamnesisDTO(string name, string type, string description)
        {
            Name = name;
            Type = type;
            Description = description;
        }

        public AnamnesisDTO()
        {
        }
    }
}