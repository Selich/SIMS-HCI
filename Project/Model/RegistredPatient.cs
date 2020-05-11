// File:    RegistredPatient.cs
// Author:  Selic
// Created: Friday, April 17, 2020 2:53:38 PM
// Purpose: Definition of Class RegistredPatient

using System;

namespace Model
{
   public class RegistredPatient : Patient
   {
      private string email;
      private string password;
      
      public void SubmitQuestion()
      {
         throw new NotImplementedException();
      }

      public System.Collections.Generic.List<Question> questions;
      public RegistredPatient() { }
      public RegistredPatient(string firstName, string lastName) : base(firstName,lastName) { }
      
      /// <summary>
      /// Property for collection of Question
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Question> Questions
      {
         get
         {
            if (questions == null)
               questions = new System.Collections.Generic.List<Question>();
            return questions;
         }
         set
         {
            RemoveAllQuestions();
            if (value != null)
            {
               foreach (Question oQuestion in value)
                  AddQuestions(oQuestion);
            }
         }
      }
      
      /// <summary>
      /// Add a new Question in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddQuestions(Question newQuestion)
      {
         if (newQuestion == null)
            return;
         if (this.questions == null)
            this.questions = new System.Collections.Generic.List<Question>();
         if (!this.questions.Contains(newQuestion))
            this.questions.Add(newQuestion);
      }
      
      /// <summary>
      /// Remove an existing Question from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveQuestions(Question oldQuestion)
      {
         if (oldQuestion == null)
            return;
         if (this.questions != null)
            if (this.questions.Contains(oldQuestion))
               this.questions.Remove(oldQuestion);
      }
      
      /// <summary>
      /// Remove all instances of Question from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllQuestions()
      {
         if (questions != null)
            questions.Clear();
      }
   
   }
}