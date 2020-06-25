using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{

    public class Approval
    {
        public Proposition Proposition { get; set; }
        public long Id { get; set; }

        public Approval(long Id)
        {
            this.Id = Id;
        }

        public Approval(long Id, string description, bool isApproved, Doctor doctor, Proposition proposition)
        {
            this.Id = Id;
            Description = description;
            IsApproved = isApproved;
            Doctor = doctor;
            this.Proposition = proposition;
        }

        public string Description {get;set;}
        public bool IsApproved {get;set;}
        public Doctor Doctor {get;set;}
    }
}
