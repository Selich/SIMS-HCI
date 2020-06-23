using Project.Model;
using Project.Model.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services.Generators
{
    public interface IReportGenerator<E> where E : class
    {
        //IPDFReport
        Report Generate(E entity);
        // GenerateReport

    }
}
