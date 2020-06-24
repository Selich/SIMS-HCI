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
    public class MedicineRepository :
        CSVRepository<Medicine, long>,
        IMedicineRepository,
        IEagerCSVRepository<Medicine, long>
    {
        private const string ENTITY_NAME = "Medicine";
        public MedicineRepository(
            ICSVStream<Medicine> stream,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        { }

        public new IEnumerable<Medicine> Find(Func<Medicine, bool> predicate) => GetAllEager().Where(predicate);
        public IEnumerable<Medicine> GetAllEager() => GetAll();
        public Medicine GetEager(long id) => GetById(id);
        public Medicine GetByName(string name) => GetByName(name);

        public Medicine RegisterMedicine(string name, string purpose, string administration, string type, string description)
        {
            throw new NotImplementedException();
        }
    }
}