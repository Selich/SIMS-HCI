﻿using Project.Model;
using Project.Model.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Utility
{
    public interface IPDFReport<E> where E : class
    {
        Report GenerateReport(E entity);

    }
}
