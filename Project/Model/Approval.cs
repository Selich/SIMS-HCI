using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{

    public class Approval
    {
        public string Description {get;set;}
        public bool IsApproved {get;set;}
        public Doctor Doctor {get;set;}
        public Prescription Prescription { get; set; }
    }
}
