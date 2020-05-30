using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity
{

        public class ApprovalDTO
        {
            public string Description;
            public bool IsApproved;
            public DoctorDTO Doctor { get; set; }
    }
}
