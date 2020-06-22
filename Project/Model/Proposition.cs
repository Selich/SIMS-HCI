// File:    Proposition.cs
// Author:  Selic
// Created: Saturday, April 18, 2020 12:29:10 AM
// Purpose: Definition of Class Proposition

using System;
using System.Collections.Generic;
using Project.Repositories.Abstract;

namespace Project.Model
{
    public class Proposition : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string State { get; set; }
        public List<Approval> Approval { get; set; }
        public Medicine Medicine { get; set; }
        public Director Director { get; set; }
      
        public Proposition() {}
        public Proposition(string state, List<Approval> approval, Medicine medicine, Director director)
        {
            State = state;
            Approval = approval;
            Medicine = medicine;
            Director = director;
        }

        public Proposition(long id, string state, List<Approval> approval, Medicine medicine, Director director)
        {
            Id = id;
            State = state;
            Approval = approval;
            Medicine = medicine;
            Director = director;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

    }
}