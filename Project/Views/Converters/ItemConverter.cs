using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Converters
{
    public class ItemConverter : IConverter<Item, ItemDTO>
    {
        public Item ConvertDTOToEntity(ItemDTO dto)
            => new Item(
                dto.Id,
                dto.Quantity,
                dto.Name,
                dto.Type,
                dto.Description
            );

        public ItemDTO ConvertEntityToDTO(Item entity)
        {
            try
            {
                return new ItemDTO(
                    entity.Id,
                    entity.Quantity,
                    entity.Name,
                    entity.Type,
                    entity.Description
                );
            }
            catch (System.Exception)
            {
                return new ItemDTO();
            }
        }

        public List<Item> ConvertListDTOToListEntity(IEnumerable<ItemDTO> dtos)
            => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<ItemDTO> ConvertListEntityToListDTO(List<Item> entities)
            => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
