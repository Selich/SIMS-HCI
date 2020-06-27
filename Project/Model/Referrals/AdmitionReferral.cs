using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Repositories.Abstract;

namespace Project.Model.Referrals
{
    public class AdmitionReferral : IIdentifiable<long>
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public MedicalAppointment MedicalAppointment { get; set; }

        public AdmitionReferral() { }

        public AdmitionReferral(long id, DateTime date, MedicalAppointment medicalAppointment)
        {
            Id = id;
            Date = date;
            MedicalAppointment = medicalAppointment;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}
