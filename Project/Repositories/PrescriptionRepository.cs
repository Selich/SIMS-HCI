using Project.Model;
using Project.Repositories.Abstract;
using Project.Repositories.CSV;
using Project.Repositories.CSV.Stream;
using Project.Repositories.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Repositories
{
    public class PrescriptionRepository : CSVRepository<Prescription, long>, IPrescriptionRepository, IEagerCSVRepository<Prescription, long>
    {
        private const string ENTITY_NAME = "Prescription";

        public PrescriptionRepository(
            ICSVStream<Prescription> stream,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
        }

        public new IEnumerable<Prescription> Find(Func<Prescription, bool> predicate) => GetAllEager().Where(predicate);


        public IEnumerable<Prescription> GetAllEager() => GetAll();
        public Prescription GetEager(long id) => GetById(id);

        public Prescription Remove(Prescription entity)
        {
            throw new NotImplementedException();
        }

        public Prescription Update(Prescription entity)
        {
            throw new NotImplementedException();
        }
    }
}
