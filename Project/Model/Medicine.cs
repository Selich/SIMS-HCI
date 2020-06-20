// File:    Medicine.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:29:51 PM
// Purpose: Definition of Class Medicine

using System;
using System.Collections.Generic;
using Project.Repositories.Abstract;

namespace Project.Model
{
    public class Medicine : Consumebles , IIdentifiable<long>
    {
        public long Id { get; set; }
        public string Purpose { get; set; }
        public string Administration { get; set; }
        public bool Approved { get; set; }
        public Medicine (): base() {}

        public Medicine(long id, string purpose, string administration, bool approved, long quantity, string type, string description, string name)
        : base(quantity, type, description, name)
        {
            Id = id;
            Purpose = purpose;
            Administration = administration;
            Approved = approved;
        }
        public Medicine(string purpose, string administration, bool approved, long quantity, string type, string description, string name)
        : base(quantity, type, description, name)
        {
            Purpose = purpose;
            Administration = administration;
            Approved = approved;
        }

        public System.Collections.Generic.List<Medicine> alternatives;
        public System.Collections.Generic.List<Medicine> Alternatives
        {
            get
            {
                if (alternatives == null)
                    alternatives = new System.Collections.Generic.List<Medicine>();
                return alternatives;
            }
            set
            {
                RemoveAllAlternatives();
                if (value != null)
                {
                    foreach (Medicine oMedicine in value)
                        AddAlternatives(oMedicine);
                }
            }
        }

        /// <summary>
        /// Add a new Medicine in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddAlternatives(Medicine newMedicine)
        {
            if (newMedicine == null)
                return;
            if (this.alternatives == null)
                this.alternatives = new System.Collections.Generic.List<Medicine>();
            if (!this.alternatives.Contains(newMedicine))
                this.alternatives.Add(newMedicine);
        }

        /// <summary>
        /// Remove an existing Medicine from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveAlternatives(Medicine oldMedicine)
        {
            if (oldMedicine == null)
                return;
            if (this.alternatives != null)
                if (this.alternatives.Contains(oldMedicine))
                    this.alternatives.Remove(oldMedicine);
        }

        /// <summary>
        /// Remove all instances of Medicine from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllAlternatives()
        {
            if (alternatives != null)
                alternatives.Clear();
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

    }
}