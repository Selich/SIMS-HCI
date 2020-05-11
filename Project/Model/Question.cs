// File:    Question.cs
// Author:  Selic
// Created: Tuesday, April 21, 2020 10:59:49 PM
// Purpose: Definition of Class Question

using System;

namespace Model
{
   public class Question
   {
      public int id
      {get;set;}
      public string question
      {get;set;}
      public string answer
      {get;set;}

      public RegistredPatient registredPatient;
      
      public Secretary secretary;
      
      /// <summary>
      /// Property for Secretary
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public Secretary Secretary
      {
         get
         {
            return secretary;
         }
         set
         {
            if (this.secretary == null || !this.secretary.Equals(value))
            {
               if (this.secretary != null)
               {
                  Secretary oldSecretary = this.secretary;
                  this.secretary = null;
                  oldSecretary.RemoveQuestions(this);
               }
               if (value != null)
               {
                  this.secretary = value;
                  this.secretary.AddQuestions(this);
               }
            }
         }
      }
   
   }
}