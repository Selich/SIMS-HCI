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
    public class PatientRepository : CSVRepository<Patient, long>, IPatientRepository, IEagerCSVRepository<Patient, long>
    {
        private const string ENTITY_NAME = "Patient";

        public PatientRepository(ICSVStream<Patient> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer)
        {
        }
        public new IEnumerable<Patient> Find(Func<Patient, bool> predicate) => GetAllEager().Where(predicate);

        public IEnumerable<Patient> GetAllEager() => GetAll();
        public Patient GetEager(long id) => Get(id);

        public new Patient Save(Patient patient)
        {
            if (IsEmailUnique(patient.Email))
                return base.Save(patient);
            else
                throw new Exception();
        }
        private bool IsEmailUnique(string email)
         => GetPatientByEmail(email) == null;

        private Patient GetPatientByEmail(string email)
    => _stream.ReadAll().SingleOrDefault(patient => patient.Email.Equals(email));

    }
}