﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{

        public class ApprovalDTO
        {
            public string Description {get;set;}
            public bool IsApproved {get;set;}
            public DoctorDTO Doctor { get; set; }
    }
}