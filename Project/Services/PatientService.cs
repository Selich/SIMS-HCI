using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;
using Project.Repositories;
using Project.Repositories.Abstract;

namespace Project.Services
{
    public class PatientService : IService<Patient, long>
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public IEnumerable<Patient> GetAll() => _patientRepository.GetAll();

        public Patient Get(long id) => _patientRepository.Get(id);

        public Patient Create(Patient patient) => _patientRepository.Create(patient);

        public Patient Update(Patient patient) => _patientRepository.Update(patient);

        public Patient Delete(Patient client) => _patientRepository.Delete(client);

    }
}
