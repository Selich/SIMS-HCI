using Project.Model;
using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    class InventoryManagmentService:IService<InventoryManagment,long>
    {
        private readonly IInventoryManagmentRepository _invenotryRepository;

        public InventoryManagmentService(IInventoryManagmentRepository invenotryRepository)
        {
            _invenotryRepository = invenotryRepository;
        }

        public IEnumerable<InventoryManagment> GetAll()
         => _invenotryRepository.GetAll();

        public InventoryManagment GetById(long id)
         => _invenotryRepository.GetById(id);

        public InventoryManagment Remove(InventoryManagment entity)
        => _invenotryRepository.Remove(entity);

        public InventoryManagment Save(InventoryManagment entity)
         => _invenotryRepository.Save(entity);

        public InventoryManagment Update(InventoryManagment entity)
           => _invenotryRepository.Update(entity);
    }
}
