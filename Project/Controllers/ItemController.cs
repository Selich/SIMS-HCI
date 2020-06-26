using System.Collections.Generic;
using Project.Controllers;
using Project.Model;
using Project.Services;
using Project.Views.Converters;
using Project.Views.Model;

namespace Project.Controllers
{
    class ItemController : IController<ItemDTO, long>
    {
        private IService<Item, long> _service;
        private IConverter<Item, ItemDTO> _itemConverter;


        public ItemController(
            IService<Item, long> service,
            IConverter<Item, ItemDTO> itemConverter
            )
        {
            _service = service;
            _itemConverter = itemConverter;
        }

        public ItemDTO GetById(long id)
            => _itemConverter.ConvertEntityToDTO(_service.GetById(id));

        public IEnumerable<ItemDTO> GetAll()
            => _itemConverter.ConvertListEntityToListDTO((List<Item>)_service.GetAll());

        public ItemDTO Remove(ItemDTO entity)
            => _itemConverter.ConvertEntityToDTO(_service.Remove(_itemConverter.ConvertDTOToEntity(entity)));

        public ItemDTO Save(ItemDTO entity)
            => _itemConverter.ConvertEntityToDTO(_service.Save(_itemConverter.ConvertDTOToEntity(entity)));

        public ItemDTO Update(ItemDTO entity)
            => _itemConverter.ConvertEntityToDTO(_service.Update(_itemConverter.ConvertDTOToEntity(entity)));
    }
}
