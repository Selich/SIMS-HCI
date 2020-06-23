using Project.Model;
using Project.Repositories.Abstract;
using Project.Repositories.CSV;
using Project.Repositories.CSV.Stream;
using Project.Repositories.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public class EquipmentRepository: CSVRepository<Equipment,long>,
        IEquipmentRepository,
        IEagerCSVRepository<Equipment,long>
    {
        private const string ENTITY_NAME = "Equipment";

        public EquipmentRepository(
            ICSVStream<Equipment> stream,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
        }

        public new IEnumerable<Equipment> Find(Func<Equipment, bool> predicate) => GetAllEager().Where(predicate);


        public IEnumerable<Equipment> GetAllEager() => GetAll();
        public Equipment GetEager(long id) => GetById(id);
    }
}
