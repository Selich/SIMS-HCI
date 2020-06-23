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
    class PatientAppointmentReportGenerator : IPDFReport<TimeInterval>
    {     
        public App app;
        private string _path;

        public PatientAppointmentReportGenerator(string path)
        {
            app = Application.Current as App;
            _path = path;
        }


        public Report GenerateReport(TimeInterval interval)
        {
            Report report = new Report(_path, new DateTime(), "PatinetAppointment");
            report.Path = _path + $@"\PatientReport{report.Id}.pdf";

            Document doc = new Document(PageSize.A4, 10, 10, 40, 35);

            PdfWriter writer = PdfWriter.GetInstance(
                doc, new FileStream(report.Path, FileMode.Create));

            Font font = FontFactory.GetFont(FontFactory.HELVETICA, 9);


            List<MedicalAppointmentDTO> list = new List<MedicalAppointmentDTO>();

            //TEMP data need to fix
            RoomDTO tempRoom = new RoomDTO() { Floor = "First", Id = 101, Ward = "General Practice" };
            DoctorDTO tempDoctor = new DoctorDTO() { FirstName = "Filip", LastName="Petrovic", MedicalRole="General Practise" };
            List<DoctorDTO> tempDoctors = new List<DoctorDTO>();
            tempDoctors.Add(tempDoctor);
            ReviewDTO tempReview = new ReviewDTO(5, "Good idk");
            list.Add(new MedicalAppointmentDTO() { Id = 0, Room = tempRoom, Beginning = new DateTime(2020, 5, 10, 15, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 10, 15, 30, 0), Doctors = tempDoctors, Review = tempReview });
            list.Add(new MedicalAppointmentDTO() { Id = 1, Room = tempRoom, Beginning = new DateTime(2020, 5, 11, 18, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 11, 18, 30, 0), Doctors = tempDoctors, Review = tempReview });
            list.Add(new MedicalAppointmentDTO() { Id = 2, Room = tempRoom, Beginning = new DateTime(2020, 5, 12, 15, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 12, 15, 30, 0), Doctors = tempDoctors, Review = tempReview });
            list.Add(new MedicalAppointmentDTO() { Id = 3, Room = tempRoom, Beginning = new DateTime(2020, 5, 13, 15, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 13, 15, 30, 0), Doctors = tempDoctors, Review = tempReview });
            list.Add(new MedicalAppointmentDTO() { Id = 4, Room = tempRoom, Beginning = new DateTime(2020, 5, 14, 11, 0, 0), Type = MedicalAppointmentType.operation, End = new DateTime(2020, 5, 14, 11, 30, 0), Doctors = tempDoctors, Review = tempReview });
            list.Add(new MedicalAppointmentDTO() { Id = 5, Room = tempRoom, Beginning = new DateTime(2020, 5, 15, 14, 0, 0), Type = MedicalAppointmentType.operation, End = new DateTime(2020, 5, 15, 14, 30, 0), Doctors = tempDoctors, Review = tempReview });


            doc.Open();
            doc.AddTitle("Patient Appoitment Report");
            Paragraph par = new Paragraph($"Patient Appoitments from {interval.Start.ToShortDateString()} to {interval.End.ToShortDateString()}");
            par.Alignment = Element.ALIGN_CENTER;
            par.SetLeading(5, 5);
            par.SpacingAfter = 20;
            doc.Add(par);

            if (list.Count > 0)
            {
                PdfPTable table = new PdfPTable(5);
                table.WidthPercentage = 80;

                table.AddCell(new Phrase("Type", font));
                table.AddCell(new Phrase("Doctor", font));
                table.AddCell(new Phrase("Room", font));
                table.AddCell(new Phrase("Begining", font));
                table.AddCell(new Phrase("End", font));

                for (int i = 0; i < list.Count; i++)
                {
                    var item = list.ElementAt(i);
                    table.AddCell(new Phrase(item.Type.ToString()));
                    table.AddCell(new Phrase(item.Doctors.ElementAt(0).FirstName + " " + item.Doctors.ElementAt(0).LastName));
                    table.AddCell(new Phrase(item.Room.Floor + " " + item.Room.Id));
                    table.AddCell(new Phrase(item.Beginning.ToString()));
                    table.AddCell(new Phrase(item.End.ToString()));
                }
                doc.Add(table);
            }


            doc.Close();


            return report;
        }
    }
}
