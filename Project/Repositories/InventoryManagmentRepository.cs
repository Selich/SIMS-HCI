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
    public class InventoryManagmentRepository:
        CSVRepository<InventoryManagment,long>,
        IInventoryManagmentRepository,
        IEagerCSVRepository<InventoryManagment,long>
    {
        private const string ENTITY_NAME = "InventoryManagment";
        public InventoryManagmentRepository(
            ICSVStream<InventoryManagment> stream,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
        }

        public new IEnumerable<InventoryManagment> Find(Func<InventoryManagment, bool> predicate) => GetAllEager().Where(predicate);

        public IEnumerable<InventoryManagment> GetAllEager() => GetAll();
        public InventoryManagment GetEager(long id) => GetById(id);
    }
}
