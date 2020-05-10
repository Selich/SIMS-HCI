// File:    User.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:12:43 PM
// Purpose: Definition of Class User

using System;

namespace Model
{
   public class User
   {
      private DateTime dateOfBirth;
      public string firstName
        { get; set; }
      public string lastName
        { get; set; }
      public string jmbg
        { get; set; }
      public string telephoneNumber
        { get; set; }
      private Sex gender;
      
      public Feedback[] feedback;
      public Address address;
      
      public System.Collections.Generic.List<Report> report;
      
      /// <summary>
      /// Property for collection of Report
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Report> Report
      {
         get
         {
            if (report == null)
               report = new System.Collections.Generic.List<Report>();
            return report;
         }
         set
         {
            RemoveAllReport();
            if (value != null)
            {
               foreach (Report oReport in value)
                  AddReport(oReport);
            }
         }
      }
      
      /// <summary>
      /// Add a new Report in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddReport(Report newReport)
      {
         if (newReport == null)
            return;
         if (this.report == null)
            this.report = new System.Collections.Generic.List<Report>();
         if (!this.report.Contains(newReport))
            this.report.Add(newReport);
      }
      
      /// <summary>
      /// Remove an existing Report from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveReport(Report oldReport)
      {
         if (oldReport == null)
            return;
         if (this.report != null)
            if (this.report.Contains(oldReport))
               this.report.Remove(oldReport);
      }
      
      /// <summary>
      /// Remove all instances of Report from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllReport()
      {
         if (report != null)
            report.Clear();
      }
   
   }
}