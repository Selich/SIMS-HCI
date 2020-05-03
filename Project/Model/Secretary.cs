// File:    Secretary.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:10:34 PM
// Purpose: Definition of Class Secretary

using System;

namespace Model
{
   public class Secretary : Employee
   {
      
      public System.Collections.Generic.List<Question> questions;
      
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
         {
            this.questions.Add(newQuestion);
            newQuestion.Secretary = this;
         }
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
            {
               this.questions.Remove(oldQuestion);
               oldQuestion.Secretary = null;
            }
      }
      
      /// <summary>
      /// Remove all instances of Question from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllQuestions()
      {
         if (questions != null)
         {
            System.Collections.ArrayList tmpQuestions = new System.Collections.ArrayList();
            foreach (Question oldQuestion in questions)
               tmpQuestions.Add(oldQuestion);
            questions.Clear();
            foreach (Question oldQuestion in tmpQuestions)
               oldQuestion.Secretary = null;
            tmpQuestions.Clear();
         }
      }
   
   }
}