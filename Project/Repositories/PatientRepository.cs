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
        private LongSequencer longSequencer;

        public PatientRepository(CSVStream<Patient> stream, LongSequencer sequencer) : base(ENTITY_NAME, stream, sequencer)
        {
        }


        public new IEnumerable<Patient> Find(Func<Patient, bool> predicate) => GetAllEager().Where(predicate);

        public IEnumerable<Patient> GetAllEager() => GetAll();
        public Patient GetEager(long id) => Get(id);

    }
}