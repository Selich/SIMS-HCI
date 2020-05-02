// File:    Doctor.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:10:35 PM
// Purpose: Definition of Class Doctor

using System;

public class Doctor : Employee
{
   private string medicalRole;
   
   public System.Collections.Generic.List<Review> review;
   
   /// <summary>
   /// Property for collection of Review
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<Review> Review
   {
      get
      {
         if (review == null)
            review = new System.Collections.Generic.List<Review>();
         return review;
      }
      set
      {
         RemoveAllReview();
         if (value != null)
         {
            foreach (Review oReview in value)
               AddReview(oReview);
         }
      }
   }
   
   /// <summary>
   /// Add a new Review in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddReview(Review newReview)
   {
      if (newReview == null)
         return;
      if (this.review == null)
         this.review = new System.Collections.Generic.List<Review>();
      if (!this.review.Contains(newReview))
         this.review.Add(newReview);
   }
   
   /// <summary>
   /// Remove an existing Review from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveReview(Review oldReview)
   {
      if (oldReview == null)
         return;
      if (this.review != null)
         if (this.review.Contains(oldReview))
            this.review.Remove(oldReview);
   }
   
   /// <summary>
   /// Remove all instances of Review from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllReview()
   {
      if (review != null)
         review.Clear();
   }
   public System.Collections.Generic.List<Approval> approval;
   
   /// <summary>
   /// Property for collection of Approval
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<Approval> Approval
   {
      get
      {
         if (approval == null)
            approval = new System.Collections.Generic.List<Approval>();
         return approval;
      }
      set
      {
         RemoveAllApproval();
         if (value != null)
         {
            foreach (Approval oApproval in value)
               AddApproval(oApproval);
         }
      }
   }
   
   /// <summary>
   /// Add a new Approval in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddApproval(Approval newApproval)
   {
      if (newApproval == null)
         return;
      if (this.approval == null)
         this.approval = new System.Collections.Generic.List<Approval>();
      if (!this.approval.Contains(newApproval))
      {
         this.approval.Add(newApproval);
         newApproval.Doctor = this;
      }
   }
   
   /// <summary>
   /// Remove an existing Approval from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveApproval(Approval oldApproval)
   {
      if (oldApproval == null)
         return;
      if (this.approval != null)
         if (this.approval.Contains(oldApproval))
         {
            this.approval.Remove(oldApproval);
            oldApproval.Doctor = null;
         }
   }
   
   /// <summary>
   /// Remove all instances of Approval from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllApproval()
   {
      if (approval != null)
      {
         System.Collections.ArrayList tmpApproval = new System.Collections.ArrayList();
         foreach (Approval oldApproval in approval)
            tmpApproval.Add(oldApproval);
         approval.Clear();
         foreach (Approval oldApproval in tmpApproval)
            oldApproval.Doctor = null;
         tmpApproval.Clear();
      }
   }
   public System.Collections.Generic.List<MedicalAppointment> appointments;
   
   /// <summary>
   /// Property for collection of MedicalAppointment
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<MedicalAppointment> Appointments
   {
      get
      {
         if (appointments == null)
            appointments = new System.Collections.Generic.List<MedicalAppointment>();
         return appointments;
      }
      set
      {
         RemoveAllAppointments();
         if (value != null)
         {
            foreach (MedicalAppointment oMedicalAppointment in value)
               AddAppointments(oMedicalAppointment);
         }
      }
   }
   
   /// <summary>
   /// Add a new MedicalAppointment in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddAppointments(MedicalAppointment newMedicalAppointment)
   {
      if (newMedicalAppointment == null)
         return;
      if (this.appointments == null)
         this.appointments = new System.Collections.Generic.List<MedicalAppointment>();
      if (!this.appointments.Contains(newMedicalAppointment))
         this.appointments.Add(newMedicalAppointment);
   }
   
   /// <summary>
   /// Remove an existing MedicalAppointment from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveAppointments(MedicalAppointment oldMedicalAppointment)
   {
      if (oldMedicalAppointment == null)
         return;
      if (this.appointments != null)
         if (this.appointments.Contains(oldMedicalAppointment))
            this.appointments.Remove(oldMedicalAppointment);
   }
   
   /// <summary>
   /// Remove all instances of MedicalAppointment from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllAppointments()
   {
      if (appointments != null)
         appointments.Clear();
   }
   public System.Collections.Generic.List<DoctorReferral> doctorReferral;
   
   /// <summary>
   /// Property for collection of DoctorReferral
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<DoctorReferral> DoctorReferral
   {
      get
      {
         if (doctorReferral == null)
            doctorReferral = new System.Collections.Generic.List<DoctorReferral>();
         return doctorReferral;
      }
      set
      {
         RemoveAllDoctorReferral();
         if (value != null)
         {
            foreach (DoctorReferral oDoctorReferral in value)
               AddDoctorReferral(oDoctorReferral);
         }
      }
   }
   
   /// <summary>
   /// Add a new DoctorReferral in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddDoctorReferral(DoctorReferral newDoctorReferral)
   {
      if (newDoctorReferral == null)
         return;
      if (this.doctorReferral == null)
         this.doctorReferral = new System.Collections.Generic.List<DoctorReferral>();
      if (!this.doctorReferral.Contains(newDoctorReferral))
      {
         this.doctorReferral.Add(newDoctorReferral);
         newDoctorReferral.ReferredDoctor = this;
      }
   }
   
   /// <summary>
   /// Remove an existing DoctorReferral from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveDoctorReferral(DoctorReferral oldDoctorReferral)
   {
      if (oldDoctorReferral == null)
         return;
      if (this.doctorReferral != null)
         if (this.doctorReferral.Contains(oldDoctorReferral))
         {
            this.doctorReferral.Remove(oldDoctorReferral);
            oldDoctorReferral.ReferredDoctor = null;
         }
   }
   
   /// <summary>
   /// Remove all instances of DoctorReferral from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllDoctorReferral()
   {
      if (doctorReferral != null)
      {
         System.Collections.ArrayList tmpDoctorReferral = new System.Collections.ArrayList();
         foreach (DoctorReferral oldDoctorReferral in doctorReferral)
            tmpDoctorReferral.Add(oldDoctorReferral);
         doctorReferral.Clear();
         foreach (DoctorReferral oldDoctorReferral in tmpDoctorReferral)
            oldDoctorReferral.ReferredDoctor = null;
         tmpDoctorReferral.Clear();
      }
   }

}