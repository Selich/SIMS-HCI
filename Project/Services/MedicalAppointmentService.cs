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

        public MedicalAppointmentService(
            IMedicalAppointmentRepository medicalAppointmentRepository
        )
        {
            _medicalAppointmentRepository = medicalAppointmentRepository;
        }
        public IEnumerable<MedicalAppointment> GetAll()
            => _medicalAppointmentRepository.GetAll();

        public IEnumerable<MedicalAppointment> GetAllByPatientId(long id)
            => _medicalAppointmentRepository.GetAllByPatientId(id);

        public MedicalAppointment GetById(long id)
            => _medicalAppointmentRepository.GetById(id);

        public MedicalAppointment Remove(MedicalAppointment entity)
            => _medicalAppointmentRepository.Remove(entity);

        public MedicalAppointment Save(MedicalAppointment entity)
            => _medicalAppointmentRepository.Save(entity);

        public MedicalAppointment Update(MedicalAppointment entity)
            => _medicalAppointmentRepository.Update(entity);

        public IEnumerable<MedicalAppointment> GetAllByDoctorID(long id)
            => _medicalAppointmentRepository.GetAllByDoctorId(id);

        public bool IsAvailableAtTimeInterval(MedicalAppointment medicalAppointment, TimeInterval timeInterval)
            => medicalAppointment.Beginning >= timeInterval.Start && medicalAppointment.End <= timeInterval.End;

        public IEnumerable<MedicalAppointment> GetlAvailableAppoitments(Doctor doctor, Room room, TimeInterval timeInterval)
        {
            return new List<MedicalAppointment>();
        }

        private IEnumerable<MedicalAppointment> GetlAvailableAppoitmentsByDoctor(Doctor doctor)
        {     
            return new List<MedicalAppointment>();
        }

        private IEnumerable<MedicalAppointment> GetlAvailableAppoitmentsByTimeInterval(TimeInterval timeinterval)
        {
            return new List<MedicalAppointment>();
        }
        
    }

}

