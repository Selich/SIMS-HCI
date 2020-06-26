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
        private readonly IRepository<Patient, long> _patientRepository;
        private readonly IRepository<Doctor, long> _doctorRepository;

        public MedicalAppointmentRepository(
            ICSVStream<MedicalAppointment> stream,
            IMedicalAppointmentToDoctorRepository  medicalAppointmentToDoctorRepository,
            IRepository<Patient, long> patientRepository,
            IRepository<Doctor, long> doctorRepository,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
            _medicalAppointmentToDoctorRepository = medicalAppointmentToDoctorRepository;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
        }

        private MedicalAppointment PopulateMedicalAppointment(MedicalAppointment appointment){
            appointment.Patient = _patientRepository.GetById(appointment.Patient.Id);
            var list =_medicalAppointmentToDoctorRepository.GetAllByMedicalAppointmentId(appointment.Id);
            appointment.Doctors = new List<Doctor>();
            return BindMedicalAppointmentToDoctors(appointment, list);
        }
        private MedicalAppointment BindMedicalAppointmentToDoctors(MedicalAppointment appointment, IEnumerable<MedicalAppointmentToDoctor> entities){
            foreach (MedicalAppointmentToDoctor pair in entities){
                appointment.Doctors.Add(_doctorRepository.GetById(pair.DoctorId));
            }
            return appointment;
        }

        public new MedicalAppointment GetById(long id)
            => GetEager(id);
        public MedicalAppointment GetEager(long id)
            => PopulateMedicalAppointment(base.GetById(id));

        public new IEnumerable<MedicalAppointment> GetAll()
            => GetAllEager();

        public IEnumerable<MedicalAppointment> GetAllEager()
        {
            var list = base.GetAll();
            var newList = new List<MedicalAppointment>();
            foreach (var item in list)
                newList.Add(PopulateMedicalAppointment(item));
            
            return newList;
        }

        public IEnumerable<MedicalAppointment> GetAllByPatientId(long id)
            => GetAllEager().Where(item => item.Patient.Id == id).ToList();
        public IEnumerable<MedicalAppointment> GetAllByDoctorId(long id)
            => GetAllEager().Where(item => item.Doctors.Select(doctor => doctor.Id == id).Any()).ToList();
        public IEnumerable<MedicalAppointment> GetAllByRoomId(long id)
            => GetAllEager().Where(item => item.Room.Id == id).ToList();

        public new MedicalAppointment Remove(MedicalAppointment entity)
        {
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
            return base.Update(entity);
        }

    }
}
