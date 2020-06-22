using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;

namespace Project.Views.Model
{
    public class PrescriptionDTO
    {
        private Medicine medicine;
        private Project.Model.Patient patient;

        public long Id { get; set; }
        public int Dosage { get; set; }
        public string Usage { get; set; }
        public string Period { get; set; }
        public DateTime Date { get; set; }
        public PatientDTO Patient { get; set; }
        public MedicineDTO Medicine { get; set; }


        public PrescriptionDTO(int dosage, string usage, string period, MedicineDTO medicine, DateTime date, PatientDTO patient)
        {
            Dosage = dosage;
            Usage = usage;
            Period = period;
            Date = date;
            Patient = patient;
            Medicine = medicine;
        }

        public PrescriptionDTO(long id, int dosage, string usage, string period, MedicineDTO medicine, DateTime date, PatientDTO patient)
        {
            Id = id;
            Dosage = dosage;
            Usage = usage;
            Period = period;
            Date = date;
            Patient = patient;
        }

        public PrescriptionDTO(long id, int dosage, string usage, string period, Medicine medicine, DateTime date, Project.Model.Patient patient)
        {
            Id = id;
            Dosage = dosage;
            Usage = usage;
            Period = period;
            this.medicine = medicine;
            Date = date;
            this.patient = patient;
        }
    }
}
