using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace Project.Utility
{
    class GenerateSecretaryReport : IPDFReport<TimeInterval>
    {
        public App app;
        private string _path;

        public GenerateSecretaryReport(string path)
        {
            app = Application.Current as App;
            _path = path;
        }

        public List<MedicalAppointmentDTO> GetAvailableMedicalAppointments(TimeInterval timeInterval)
        {
            List<MedicalAppointmentDTO> list = app.MedicalAppointments;
            List<MedicalAppointmentDTO> returnList = new List<MedicalAppointmentDTO>();
            foreach (MedicalAppointmentDTO item in list)
            {
                if (
                    item.Beginning.CompareTo(timeInterval.Start) <= 0 &&
                    item.End.CompareTo(timeInterval.End) >= 0
                    )
                {
                    returnList.Add(item);

                }

            }
            return returnList;

        }


        public Report GenerateReport(TimeInterval interval)
        {
            Report report = new Report(_path, new DateTime(), "Appointment");
            report.Path = _path + $@"\AppointmentReport{report.Id}";

            Document doc = new Document(PageSize.A4, 10, 10, 40, 35);

            PdfWriter writer = PdfWriter.GetInstance(
                doc, new FileStream(report.Path, FileMode.Create));

            Font font = FontFactory.GetFont(FontFactory.HELVETICA, 5);

            List<MedicalAppointmentDTO> list = GetAvailableMedicalAppointments(interval);

            doc.Open();
            doc.AddTitle("Something");
            doc.Add(new Paragraph("Something"));

            if (list.Count > 0)
            {
                PdfPTable table = new PdfPTable(list.Count);
                table.WidthPercentage = 60;

                table.AddCell(new Phrase("Id", font));
                table.AddCell(new Phrase("Tip", font));
                table.AddCell(new Phrase("Lekar", font));
                table.AddCell(new Phrase("Pacijent", font));
                table.AddCell(new Phrase("Ocena", font));

                for (int i = 0; i < list.Count; i++)
                {
                    var item = list.ElementAt(i);
                    table.AddCell(new Phrase(item.Id));
                    table.AddCell(new Phrase(item.Type.ToString()));
                    table.AddCell(new Phrase(item.Doctors.ElementAt(0).FirstName + " " + item.Doctors.ElementAt(0).LastName));
                    table.AddCell(new Phrase(item.Patient.FirstName + " " + item.Patient.LastName + " " + item.Patient.Jmbg));
                    table.AddCell(new Phrase(item.Review.Rating));
                }
                doc.Add(table);
            }
            else
            {
                PdfPTable table = new PdfPTable(1);
                table.WidthPercentage = 60;

                table.AddCell(new Phrase("Id", font));
                table.AddCell(new Phrase("Tip", font));
                table.AddCell(new Phrase("Lekar", font));
                table.AddCell(new Phrase("Pacijent", font));
                table.AddCell(new Phrase("Ocena", font));

                doc.Add(table);
            }

            doc.Close();


            return report;
        }
    }
}
