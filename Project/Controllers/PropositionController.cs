// File:    PropositionController.cs
// Author:  Selic
// Created: Friday, May 1, 2020 2:33:33 AM
// Purpose: Definition of Class PropositionController

using System;
using Project.Model;


namespace Controller
{
   public class PropositionController
   {
      public Proposition CreateProposition(string name, string purpose, string administration, string description, string type)
      {
         throw new NotImplementedException();
      }
      
      public Proposition ApproveProposition(Proposition proposition)
      {
         throw new NotImplementedException();
      }
      
      public Proposition GetAllProposition()
      {
         throw new NotImplementedException();
      }
      
      public Approval GetAllApprovals(int propositionId)
      {
         throw new NotImplementedException();
      }
   
   }
}