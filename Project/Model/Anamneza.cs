// File:    Anamneza.cs
// Author:  Selic
// Created: Friday, March 20, 2020 10:32:33 PM
// Purpose: Definition of Class Anamneza

using System;

namespace Model
{
   public class Anamneza : Document
   {
      private string name;
      private string type;
      private string description;
      
      public MedicalChart[] medicalChart;
   
   }
}