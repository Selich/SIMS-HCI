// File:    PropositionController.cs
// Author:  Selic
// Created: Friday, May 1, 2020 2:33:33 AM
// Purpose: Definition of Class PropositionController

using System;

namespace Controller
{
   public class PropositionController
   {
      public Model.Proposition CreateProposition(string name, string purpose, string administration, string description, string type)
      {
         throw new NotImplementedException();
      }
      
      public Model.Proposition ApproveProposition(Model.Proposition proposition)
      {
         throw new NotImplementedException();
      }
      
      public Model.Proposition GetAllProposition()
      {
         throw new NotImplementedException();
      }
      
      public Model.Approval GetAllApprovals(int propositionId)
      {
         throw new NotImplementedException();
      }
   
   }
}