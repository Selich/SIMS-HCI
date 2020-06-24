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
        CSVRepository<Doctor, long>,
        IDoctorRepository,
        IEagerCSVRepository<Doctor, long>

    {
        private const string ENTITY_NAME = "Doctor";

        public DoctorRepository(
            ICSVStream<Doctor> stream,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
        }
        public new IEnumerable<Doctor> Find(Func<Doctor, bool> predicate) => GetAllEager().Where(predicate);

        public IEnumerable<Doctor> GetAllEager() => GetAll();
        public Doctor GetEager(long id) => GetById(id);

        public new Doctor Save(Doctor doctor)
        {
            if (IsEmailUnique(doctor.Email))
                return base.Save(doctor);
            else
                throw new Exception();
        }
        private bool IsEmailUnique(string email)
         => GetPatientByEmail(email) == null;

        private Doctor GetPatientByEmail(string email)
         => _stream.ReadAll().SingleOrDefault(doctor => doctor.Email.Equals(email));

    }
}

