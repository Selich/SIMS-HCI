// File:    TimeInterval.cs
// Author:  Selic
// Created: Tuesday, April 14, 2020 5:18:01 PM
// Purpose: Definition of Class TimeInterval

using System;

namespace Project.Model
{
   public class TimeInterval
   {
      private DateTime start;
      private DateTime end;

      public TimeInterval() {}
      public TimeInterval(DateTime start, DateTime end){
         this.start = start;
         this.end = end;
      }
   
   }
}