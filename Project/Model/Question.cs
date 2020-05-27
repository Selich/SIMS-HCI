// File:    Question.cs
// Author:  Selic
// Created: Tuesday, April 21, 2020 10:59:49 PM
// Purpose: Definition of Class Question

using System;

namespace Project.Model
{
   public class Question
   {
      public int Id {get;set;}
      public string QuestionText { get; set; }
      public string AnswerText {get;set;}

      public Patient Patient
      {get;set;}
      
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