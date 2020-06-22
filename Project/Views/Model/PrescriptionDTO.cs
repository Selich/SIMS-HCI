using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    public class PrescriptionDTO
    {
        public long Id { get; set; }
        public int Dosage { get; set; }
        public string Usage { get; set; }
        public string Period { get; set; }
        public DateTime Date { get; set; }
        public PatientDTO Patient { get; set; }


        public PrescriptionDTO(int dosage, string usage, string period, DateTime date, PatientDTO patient)
        {
            Dosage = dosage;
            Usage = usage;
            Period = period;
            Date = date;
            Patient = patient;
        }

        public PrescriptionDTO(long id, int dosage, string usage, string period, DateTime date, Patient patient)
        {
            Id = id;
            Dosage = dosage;
            Usage = usage;
            Period = period;
            Date = date;
            Patient = patient;
        }
    }
}
