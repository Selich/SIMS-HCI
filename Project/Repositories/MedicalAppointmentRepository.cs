using Project.Model;
using Project.Repositories.Abstract;
using Project.Repositories.CSV;
using Project.Repositories.CSV.Stream;
using Project.Repositories.ManyToMany.Model;
using Project.Repositories.ManyToMany.Repositories.Abstract;
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
        private readonly IMedicalAppointmentToDoctorRepository _medicalAppointmentToDoctorRepository;

        public MedicalAppointmentRepository(
            ICSVStream<MedicalAppointment> stream,
            IMedicalAppointmentToDoctorRepository  medicalAppointmentToDoctorRepository,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
            _medicalAppointmentToDoctorRepository = medicalAppointmentToDoctorRepository;
        }
        public MedicalAppointment GetEager(long id)
            => GetById(id);
        public IEnumerable<MedicalAppointment> GetAllEager()
            => GetAll();
        public IEnumerable<MedicalAppointment> GetAllByPatientId(long id)
            => GetAll().Where(item => item.Patient.Id == id).ToList();
        public IEnumerable<MedicalAppointment> GetAllByDoctorId(long id)
            => GetAll().Where(item => item.Doctors.Select(doctor => doctor.Id == id).Any()).ToList();
        public IEnumerable<MedicalAppointment> GetAllByRoomId(long id)
            => GetAll().Where(item => item.Room.Id == id).ToList();

        public MedicalAppointment Remove(MedicalAppointment entity){
            foreach (Doctor item in entity.Doctors)
                _medicalAppointmentToDoctorRepository.Remove(new MedicalAppointmentToDoctor(item.Id, entity.Id));
            return Remove(entity);

        }
        public new MedicalAppointment Save(MedicalAppointment entity)
        {
            foreach (Doctor item in entity.Doctors)
                _medicalAppointmentToDoctorRepository.Save(new MedicalAppointmentToDoctor(item.Id, entity.Id));
            return base.Save(entity);
        }
        public MedicalAppointment Update(MedicalAppointment entity)
        {
            foreach (Doctor item in entity.Doctors)
                _medicalAppointmentToDoctorRepository.Update(new MedicalAppointmentToDoctor(item.Id, entity.Id));
            return Update(entity);
        }

    }
}
