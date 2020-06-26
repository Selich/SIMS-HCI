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

        public MedicalAppointment GetEager(long id)
        {
            var medicalAppointment = GetById(id);
            medicalAppointment.Patient = _patientRepository.GetById(medicalAppointment.Patient.Id);
            var doctorAndMedicalAppList = _medicalAppointmentToDoctorRepository.GetAllByMedicalAppointmentId(medicalAppointment.Id);
            foreach (MedicalAppointmentToDoctor pair in doctorAndMedicalAppList)
            {
                medicalAppointment.Doctors.Add(_doctorRepository.GetById(pair.DoctorId));
            }
            return medicalAppointment;
        }

        public IEnumerable<MedicalAppointment> GetAllEager()
        {
            var list = GetAll();
            foreach (MedicalAppointment medicalAppointment in list)
            {
                medicalAppointment.Patient = _patientRepository.GetById(medicalAppointment.Patient.Id); ;
                var doctorAndMedicalAppList = _medicalAppointmentToDoctorRepository.GetAllByMedicalAppointmentId(medicalAppointment.Id);
                foreach (MedicalAppointmentToDoctor pair in doctorAndMedicalAppList)
                {
                    medicalAppointment.Doctors.Add(_doctorRepository.GetById(pair.DoctorId));
                }
            }
            return list;
        }

        public IEnumerable<MedicalAppointment> GetAllByPatientId(long id)
        {
            var list = GetAll().Where(item => item.Patient.Id == id).ToList();
            Patient patient = _patientRepository.GetById(id);
            foreach (MedicalAppointment medicalAppointment in list)
            {
                medicalAppointment.Patient = patient;
                var doctorAndMedicalAppList = _medicalAppointmentToDoctorRepository.GetAllByMedicalAppointmentId(medicalAppointment.Id);
                foreach (MedicalAppointmentToDoctor pair in doctorAndMedicalAppList)
                {
                    medicalAppointment.Doctors.Add(_doctorRepository.GetById(pair.DoctorId));
                }
            }
            return list;
        }

        //TODO
        public IEnumerable<MedicalAppointment> GetAllByDoctorId(long id)
            => GetAll().Where(item => item.Doctors.Select(doctor => doctor.Id == id).Any()).ToList();
        //TODO
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
            var entity = base.Remove(entity);
            entity.Doctors.Select(item => _medicalAppointmentToDoctorRepository.Update(
                new MedicalAppointmentToDoctor(entity.Id, item.Id))
                );

            return Save(entity);
        }

        List<MedicalAppointment> IMedicalAppointmentRepository.GetAllByDoctorId(long id)
        {

            IEnumerable<MedicalAppointment> listOfDoctorsWithAllIds = GetAll();

            
            foreach (MedicalAppointment medicalAppointment in listOfDoctorsWithAllIds)
            {
                medicalAppointment.Patient = _patientRepository.GetById(medicalAppointment.Patient.Id);
                var doctorAndMedicalAppList = _medicalAppointmentToDoctorRepository.GetAllByMedicalAppointmentId(medicalAppointment.Id);
                foreach (MedicalAppointmentToDoctor pair in doctorAndMedicalAppList)
                {
                    if ((pair.DoctorId == id) && (medicalAppointment.Id == pair.MedicalAppointmentId))
                    {
                        medicalAppointment.Doctors.Add(_doctorRepository.GetById(pair.DoctorId));
                    }
                }
            }


            List<MedicalAppointment> list = new List<MedicalAppointment>();

            foreach (MedicalAppointment medicalAppointment in listOfDoctorsWithAllIds)
            {
                foreach(Doctor doctor in medicalAppointment.Doctors)
                {
                    if (doctor != null)
                    {
                        doctor.Id = id;
                        list.Add(medicalAppointment);
                        break;
                    }
                }
            }
            

            foreach (MedicalAppointment medicalAppointment in list)
            {
                medicalAppointment.Patient = _patientRepository.GetById(medicalAppointment.Patient.Id);
                var doctorAndMedicalAppList = _medicalAppointmentToDoctorRepository.GetAllByMedicalAppointmentId(medicalAppointment.Id);
                foreach (MedicalAppointmentToDoctor pair in doctorAndMedicalAppList)
                {
                    medicalAppointment.Doctors.Add(_doctorRepository.GetById(pair.DoctorId));
                }
            }
            return list;
        }
    }
}
