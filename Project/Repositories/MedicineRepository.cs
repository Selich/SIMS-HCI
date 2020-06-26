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

        public new IEnumerable<Medicine> Find(Func<Medicine, bool> predicate) => GetAll().Where(predicate);
        public IEnumerable<Medicine> GetAllLazy() {
            List<Medicine> list = new List<Medicine>();
            foreach(Medicine medicine in base.GetAll()){
                medicine.Alternatives.Select(item => item.Alternatives = null);
                list.Add(medicine);
            }
            return list;
        }
        public new Medicine GetById(long id) 
            => GetLazy(id);
        public Medicine GetEager(long id) 
            => GetById(id);
        public Medicine GetByName(string name) 
            => GetByName(name);
        public Medicine GetLazy(long id)
        {
            var medicine = GetById(id);
            medicine.Alternatives.Select(item => item.Alternatives = null);
            return medicine;
        }
        public new IEnumerable<Medicine> GetAll()
        {
            var list =  base.GetAll();
            list.Select(item => item.Alternatives.Select(med => med.Alternatives = null));
            return list;

        }

        public IEnumerable<Medicine> GetAllEager()
        {
            throw new NotImplementedException();
        }
    }
}