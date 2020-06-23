using Project.Model;
using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    class OrderService: IService<Order,long>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IService<Medicine,long> _medicineService;
        private readonly IService<Equipment, long> _equipmentService;
        private readonly IService<MedicalConsumables, long> _consumablesService;

        public OrderService(IOrderRepository orderRepository,
         IService<Medicine, long> medicineService,
         IService<Equipment, long> equipmentService,
         IService<MedicalConsumables, long> consumablesService
        )
        {
            _orderRepository = orderRepository;
            _medicineService = medicineService;
            _equipmentService = equipmentService;
            _consumablesService = consumablesService;
        }

        public IEnumerable<Order> GetAll()
            => _orderRepository.GetAll();

        public Order GetById(long id)
            => _orderRepository.GetById(id);

        public Order Remove(Order entity)
            => _orderRepository.Remove(entity);

        public Order Save(Order entity) 
        {
            foreach (MedicalConsumables cons in entity.Consumebles)
                _consumablesService.Update(cons); 

            foreach (Medicine med in entity.Medicine)
                _medicineService.Update(med);   

            foreach (Equipment eq in entity.Equipments)
                _equipmentService.Save(eq);

            return _orderRepository.Save(entity);
        }
        public Order Update(Order entity)
            => _orderRepository.Update(entity);
    }
}
