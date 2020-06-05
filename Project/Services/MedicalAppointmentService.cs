using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    class MedicalAppointmentService : IService<MedicalAppointment, long>
    {
        private readonly IMedicalAppointmentRepository _medicalAppointmentRepository;

        public QuestionService(IMedicalAppointmentRepository medicalAppointmentRepository)
        {
            _medicalAppointmentRepository = medicalAppointmentRepository;
        }
        public IEnumerable<MedicalAppointment> GetAll()
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

        public MedicalAppointment Save(MedicalAppointment entity)
        {
            throw new NotImplementedException();
        }

        public MedicalAppointment Update(MedicalAppointment entity)
        {
            throw new NotImplementedException();
        }
    }
}
