// File:    Scheduling.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 8:00:20 PM
// Purpose: Definition of Interface Scheduling

using System;

namespace Model
{
   public interface Scheduling
   {
      bool Cancel();
      
      bool Modify();
   
   }
}