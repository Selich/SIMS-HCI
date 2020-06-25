using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Project.Model;
using Project.Repositories.Abstract;
using Project.Repositories.CSV;
using Project.Repositories.CSV.Stream;
using Project.Repositories.Sequencer;

namespace Project.Repositories
{
    public class PatientRepository :
        UserCSVRepository<Patient, User, long>,
        IPatientRepository,
        IEagerCSVRepository<Patient, long>
    {
        private const string ENTITY_NAME = "Patient";
        private readonly IAddressRepository _addressRepository;

        public PatientRepository(
            ICSVStream<Patient> stream,
            ICSVStream<Patient> patientStream,
            ICSVStream<Doctor> doctorStream,
            ICSVStream<Secretary> secretaryStream,
            IAddressRepository addressRepository,
            ISequencer<long> sequencer
            ) : base(stream, patientStream, doctorStream, secretaryStream, sequencer)
        {
            _addressRepository = addressRepository;
        }
        public new IEnumerable<Patient> Find(Func<Patient, bool> predicate) 
            => GetAllEager().Where(predicate);
        public IEnumerable<Patient> GetAllEager() 
            => GetAll();

        public Patient GetEager(long id)
        {
            Patient patient = GetById(id);
            patient.Address = _addressRepository.GetById(patient.Address.Id);
            return patient;
        } 

        public new Patient Save(Patient patient)
        {
            if (IsEmailUnique(patient.Email)){
                patient.Address = _addressRepository.Save(patient.Address);
                return base.Save(patient);
            }
            else
                throw new Exception();
        }
        private bool IsEmailUnique(string email)
            => GetByEmail(email) == null;

        public Patient GetByEmail(string email)
            => _stream.ReadAll().SingleOrDefault(patient => patient.Email.Equals(email));

    }
}