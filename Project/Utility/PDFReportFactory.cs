using Project.Model;
using Project.Model.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Utility
{
    class PDFReportFactory
    {
        public static Report Generate(string type)
        {
            Report report = null;
            switch (type)
            {
                default:
                    return new RoomReport("path", new DateTime());

            }
        }

    }
}
