using iTextSharp.text;
using iTextSharp.text.pdf;
using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project.Utility
{
    class GenerateDoctorReport : IPDFReport<TimeInterval>
    {
        public App app;
        private string rEPORT_RECIPE_PATH;

        public GenerateDoctorReport(string rEPORT_RECIPE_PATH)
        {
            app = Application.Current as App;
            this.rEPORT_RECIPE_PATH = rEPORT_RECIPE_PATH;
        }

        public Report GenerateReport(TimeInterval interval)
        {
            Report report = new Report(rEPORT_RECIPE_PATH, new DateTime(), "DoctorAppointment");
            report.Path = rEPORT_RECIPE_PATH + $@"\DoctorReport{report.Id}.pdf";

            Document doc = new Document(PageSize.A4, 10, 10, 40, 35);

            PdfWriter writer = PdfWriter.GetInstance(
                doc, new FileStream(report.Path, FileMode.Create));

            Font font = FontFactory.GetFont(FontFactory.HELVETICA, 9);


            List<MedicalAppointmentDTO> list = new List<MedicalAppointmentDTO>();

            doc.Open();
            doc.AddTitle("Doctor Appoitment Repport");
            Paragraph par = new Paragraph($"Doctor Appoitments from {interval.Start.ToShortDateString()} to {interval.End.ToShortDateString()}");
            par.Alignment = Element.ALIGN_CENTER;
            par.SetLeading(5, 5);
            par.SpacingAfter = 20;
            doc.Add(par);


            doc.Close();


            return report;
        }
    }
}
