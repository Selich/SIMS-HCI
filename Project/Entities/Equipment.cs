// File:    Equipment.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:30:11 PM
// Purpose: Definition of Class Equipment

using System;

namespace Model
{
   public class Equipment
   {
      public int id;
      public string type { get; set; }
      public string description;
      public string name { get; set; }
      
      public Order[] orders;
   
   }
}