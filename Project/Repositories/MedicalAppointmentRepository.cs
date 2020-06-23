using Project.Model;
using Project.Repositories.Abstract;
using Project.Repositories.CSV;
using Project.Repositories.CSV.Stream;
using Project.Repositories.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public class MedicalAppointmentRepository : CSVRepository<MedicalAppointment, long>, IMedicalAppointmentRepository, IEagerCSVRepository<MedicalAppointment, long>
    {
        private const string ENTITY_NAME = "MedicalAppointment";

        public MedicalAppointmentRepository(
            ICSVStream<MedicalAppointment> stream,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
        }
        // TODO: Implement N to N 
        public new MedicalAppointment Save(MedicalAppointment medicalAppointment){
            var list = medicalAppointment.Doctors;
            foreach(var doc in list){
                

            }


            return base.Save(medicalAppointment);
        }


        IEnumerable<MedicalAppointment> IEagerCSVRepository<MedicalAppointment, long>.GetAllEager()
        {
            throw new NotImplementedException();
        }

        MedicalAppointment IEagerCSVRepository<MedicalAppointment, long>.GetEager(long id)
        {
            throw new NotImplementedException();
        }
    }
}
