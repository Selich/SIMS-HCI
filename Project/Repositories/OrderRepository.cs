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
        private readonly IRepository<Medicine,long> _medicineRepository;
        private readonly IRepository<Equipment, long> _equipmentRepository;
        private readonly IRepository<MedicalConsumables, long> _consumablesRepository;

        public OrderRepository(
            ICSVStream<Order> stream,
            IRepository<Medicine, long> medicineRepository,
            IRepository<Equipment, long> equipmentRepository,
            IRepository<MedicalConsumables, long> consumablesRepository,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
            _medicineRepository = medicineRepository;
            _equipmentRepository = equipmentRepository;
            _consumablesRepository = consumablesRepository;
        }

        public new IEnumerable<Order> Find(Func<Order, bool> predicate) => GetAllEager().Where(predicate);
        public IEnumerable<Order> GetAllEager() => GetAll();
        public Order GetEager(long id) => GetById(id);
        public new Order Save(Order entity)
        {
            foreach (MedicalConsumables cons in entity.Consumebles)
                _consumablesRepository.Update(cons); 

            foreach (Medicine med in entity.Medicine)
                _medicineRepository.Update(med);   

            foreach (Equipment eq in entity.Equipments)
                _equipmentRepository.Save(eq);

            return base.Save(entity);
        }
    }
}
