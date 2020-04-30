// File:    RegistredPatient.cs
// Author:  Selic
// Created: Friday, April 17, 2020 2:53:38 PM
// Purpose: Definition of Class RegistredPatient

using System;

public class RegistredPatient : Patient
{
   private string email;
   private string password;
   
   public void SubmitQuestion()
   {
      throw new NotImplementedException();
   }
   
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
   public System.Collections.Generic.List<PatientReport> reports;
   
   /// <summary>
   /// Property for collection of PatientReport
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<PatientReport> Reports
   {
      get
      {
         if (reports == null)
            reports = new System.Collections.Generic.List<PatientReport>();
         return reports;
      }
      set
      {
         RemoveAllReports();
         if (value != null)
         {
            foreach (PatientReport oPatientReport in value)
               AddReports(oPatientReport);
         }
      }
   }
   
   /// <summary>
   /// Add a new PatientReport in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddReports(PatientReport newPatientReport)
   {
      if (newPatientReport == null)
         return;
      if (this.reports == null)
         this.reports = new System.Collections.Generic.List<PatientReport>();
      if (!this.reports.Contains(newPatientReport))
      {
         this.reports.Add(newPatientReport);
         newPatientReport.RegistredPatient = this;
      }
   }
   
   /// <summary>
   /// Remove an existing PatientReport from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveReports(PatientReport oldPatientReport)
   {
      if (oldPatientReport == null)
         return;
      if (this.reports != null)
         if (this.reports.Contains(oldPatientReport))
         {
            this.reports.Remove(oldPatientReport);
            oldPatientReport.RegistredPatient = null;
         }
   }
   
   /// <summary>
   /// Remove all instances of PatientReport from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllReports()
   {
      if (reports != null)
      {
         System.Collections.ArrayList tmpReports = new System.Collections.ArrayList();
         foreach (PatientReport oldPatientReport in reports)
            tmpReports.Add(oldPatientReport);
         reports.Clear();
         foreach (PatientReport oldPatientReport in tmpReports)
            oldPatientReport.RegistredPatient = null;
         tmpReports.Clear();
      }
   }
   public Review review;
   
   /// <summary>
   /// Property for Review
   /// </summary>
   /// <pdGenerated>Default opposite class property</pdGenerated>
   public Review Review
   {
      get
      {
         return review;
      }
      set
      {
         if (this.review == null || !this.review.Equals(value))
         {
            if (this.review != null)
            {
               Review oldReview = this.review;
               this.review = null;
               oldReview.RemoveRegistredPatient(this);
            }
            if (value != null)
            {
               this.review = value;
               this.review.AddRegistredPatient(this);
            }
         }
      }
   }

}