using Project.Model;
using Project.Services;
using Project.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class ReportController
    {

        public ReportController() {

        }

        public void Generate(string type, string fileType, TimeInterval time) {
            Report report = null;
            switch (fileType)
            {
                case "pdf":
                    report = PDFReportFactory.Generate(type);
                    break;
                default:
                    report = PDFReportFactory.Generate(type);
                    break;

            }



        }


    }
}
