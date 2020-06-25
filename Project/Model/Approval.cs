using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{

    public class Approval
    {
        private Proposition proposition;

        public Approval(string description, bool isApproved, Doctor doctor, Proposition proposition)
        {
            Description = description;
            IsApproved = isApproved;
            Doctor = doctor;
            this.proposition = proposition;
        }

        public string Description {get;set;}
        public bool IsApproved {get;set;}
        public Doctor Doctor {get;set;}
        public Prescription Prescription { get; set; }
    }
}
