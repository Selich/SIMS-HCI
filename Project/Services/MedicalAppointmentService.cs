using Project.Model;
using Project.Repositories.ManyToMany.Model;
using Project.Repositories.Abstract;
using Project.Repositories.ManyToMany.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    class MedicalAppointmentService : IMedicalAppointmentService
    {
        private readonly IMedicalAppointmentRepository _medicalAppointmentRepository;
        private readonly IMedicalAppointmentToDoctorRepository _medicalAppointmentToDoctorRepository;

        public MedicalAppointmentService(
            IMedicalAppointmentRepository medicalAppointmentRepository,
            IMedicalAppointmentToDoctorRepository medicalAppointmentToDoctorRepository
        )
        {
            _medicalAppointmentRepository = medicalAppointmentRepository;
            _medicalAppointmentToDoctorRepository = medicalAppointmentToDoctorRepository;
        }
        public IEnumerable<MedicalAppointment> GetAll()
            => _medicalAppointmentRepository.GetAll();

        public IEnumerable<MedicalAppointment> GetAllByPatientId(long id)
            => _medicalAppointmentRepository.GetAllByPatientId(id);

        public bool IsAvailableAtTimeInterval(MedicalAppointment medicalAppointment, TimeInterval timeInterval)
            => medicalAppointment.Beginning >= timeInterval.Start && medicalAppointment.End <= timeInterval.End;


        // TODO: Needs Doctor Repository getById call
        public MedicalAppointment GetById(long id)
        {
            MedicalAppointment medicalAppointment =_medicalAppointmentRepository.GetById(id);
            return medicalAppointment;
            // medicalAppointment.Doctors = _medicalAppointmentToDoctorRepository.GetAllByMedicalAppointmentId(medicalAppointment.Id).Select(item => item.DoctorId)
        }

        public MedicalAppointment Remove(MedicalAppointment entity)
        {
            foreach (Doctor item in entity.Doctors)
                _medicalAppointmentToDoctorRepository.Remove(new MedicalAppointmentToDoctor(item.Id, entity.Id));

            return _medicalAppointmentRepository.Remove(entity);

        }

        public MedicalAppointment Save(MedicalAppointment entity)
        {
            foreach (Doctor item in entity.Doctors)
                _medicalAppointmentToDoctorRepository.Save(new MedicalAppointmentToDoctor(item.Id, entity.Id));

            return _medicalAppointmentRepository.Save(entity);
        }

        public MedicalAppointment Update(MedicalAppointment entity)
        {
            foreach (Doctor item in entity.Doctors)
                _medicalAppointmentToDoctorRepository.Update(new MedicalAppointmentToDoctor(item.Id, entity.Id));

            return _medicalAppointmentRepository.Update(entity);
        }
    }
}
