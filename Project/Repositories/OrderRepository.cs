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
    public class OrderRepository:
        CSVRepository<Order, long>,
        IOrderRepository,
        IEagerCSVRepository<Order, long>
    {
        private const string ENTITY_NAME = "Order";

        public OrderRepository(
            ICSVStream<Order> stream,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
        }

        public new IEnumerable<Order> Find(Func<Order, bool> predicate) => GetAllEager().Where(predicate);
        public IEnumerable<Order> GetAllEager() => GetAll();
        public Order GetEager(long id) => GetById(id);
    }
}
