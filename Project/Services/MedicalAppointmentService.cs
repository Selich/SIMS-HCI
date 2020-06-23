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
    class MedicalAppointmentService : IMedicalAppointmentService<MedicalAppointment, long>
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
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MedicalAppointment> GetAllByPatientId(long id)
        {
            throw new NotImplementedException();
        }

        public MedicalAppointment GetById(long id)
        {
            throw new NotImplementedException();
        }

        public MedicalAppointment Remove(MedicalAppointment entity)
        {
            throw new NotImplementedException();
        }

        public MedicalAppointment Save(MedicalAppointment entity){
            var list = entity.Doctors;
            foreach (var item in list)
                _medicalAppointmentToDoctorRepository.Save(
                    new MedicalAppointmentToDoctor(item.Id, entity.Id));

            return _medicalAppointmentRepository.Save(entity);
        }

        public MedicalAppointment Update(MedicalAppointment entity)
        {
            throw new NotImplementedException();
        }
    }
}
