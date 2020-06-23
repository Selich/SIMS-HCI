using Project.Model;
using Project.Services;
using Project.Views.Converters;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class InventoryManagmentController : IController<InventoryManagmentDTO, long>
    {
        private IService<InventoryManagment, long> _service;
        private IConverter<InventoryManagment, InventoryManagmentDTO> _inventoryConverter;

        public InventoryManagmentController(
            IService<InventoryManagment, long> service,
            IConverter<InventoryManagment, InventoryManagmentDTO> inventoryConverter
            )

        {
            _service = service;
            _inventoryConverter = inventoryConverter;
        }

        public IEnumerable<InventoryManagmentDTO> GetAll()
        => _inventoryConverter.ConvertListEntityToListDTO((List<InventoryManagment>)_service.GetAll());

        public InventoryManagmentDTO GetById(long id)
         => _inventoryConverter.ConvertEntityToDTO(_service.GetById(id));

        public InventoryManagmentDTO Remove(InventoryManagmentDTO entity)
        => _inventoryConverter.ConvertEntityToDTO(_service.Remove(_inventoryConverter.ConvertDTOToEntity(entity)));

        public InventoryManagmentDTO Save(InventoryManagmentDTO entity)
         => _inventoryConverter.ConvertEntityToDTO(_service.Save(_inventoryConverter.ConvertDTOToEntity(entity)));

        public InventoryManagmentDTO Update(InventoryManagmentDTO entity)
        => _inventoryConverter.ConvertEntityToDTO(_service.Update(_inventoryConverter.ConvertDTOToEntity(entity)));
    }
}
