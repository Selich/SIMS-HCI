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
    public class DoctorRepository :
        UserCSVRepository<Doctor, User, long>,
        IDoctorRepository,
        IEagerCSVRepository<Doctor, long>

    {
        private const string ENTITY_NAME = "Doctor";
        private readonly IAddressRepository _addressRepository;


        public DoctorRepository(
            ICSVStream<Doctor> stream,
            ICSVStream<Patient> patientStream,
            ICSVStream<Doctor> doctorStream,
            ICSVStream<Secretary> secretaryStream,
            IAddressRepository addressRepository,
            LongSequencer sequencer
            ) : base(stream, patientStream, doctorStream, secretaryStream, sequencer)
        {
            _addressRepository = addressRepository;
        }
        public new IEnumerable<Doctor> Find(Func<Doctor, bool> predicate) => GetAllEager().Where(predicate);

        public IEnumerable<Doctor> GetAllEager() => GetAll();

        public Doctor GetEager(long id)
        {
            Doctor doctor = GetById(id);
            doctor.Address = _addressRepository.GetById(doctor.Address.Id);
            return doctor;
        }

        public new Doctor Save(Doctor doctor)
        {
            if (IsEmailUnique(doctor.Email))
            {
                doctor.Address = _addressRepository.Save(doctor.Address);
                return base.Save(doctor);
            }
            else
               throw new Exception();
        }
        
        private bool IsEmailUnique(string email)
            => GetByEmail(email) == null;

        public Doctor GetByEmail(string email)
            => _stream.ReadAll().SingleOrDefault(doctor => doctor.Email.Equals(email));

        public List<Doctor> GetBySpecialization(string specialization)
        {
            List<Doctor> doctors = (List<Doctor>) GetAll();
            doctors.Where(doctor => doctor.MedicalRole.Equals(specialization));
            return doctors;
           // => GetAll().Where(doctor => doctor.MedicalRole.Equals(specialization)).Any());
        } 
    }
}

