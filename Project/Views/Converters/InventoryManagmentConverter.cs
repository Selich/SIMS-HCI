using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Converters
{
    public class InventoryManagmentConverter : IConverter<InventoryManagment, InventoryManagmentDTO>
    {
        private EquipmentConverter _equipmentConverter;
        private RoomConverter _roomConverter;

        public InventoryManagmentConverter(EquipmentConverter equipmentConverter
            , RoomConverter roomConverter)
        {
            _equipmentConverter = equipmentConverter;
            _roomConverter = roomConverter;
        }

        public InventoryManagment ConvertDTOToEntity(InventoryManagmentDTO dto)
        {
            Room room = _roomConverter.ConvertDTOToEntity(dto.Room);
            List<Equipment> equipment = dto.Equipment.Select(eq => _equipmentConverter.ConvertDTOToEntity(eq)).ToList();

            return new InventoryManagment(dto.Id, dto.Beginning, dto.End, room, equipment);
        }

        public InventoryManagmentDTO ConvertEntityToDTO(InventoryManagment entity)
        {
            RoomDTO room = _roomConverter.ConvertEntityToDTO(entity.Room);
            List<EquipmentDTO> equipment = entity.Equipment.Select(eq => _equipmentConverter.ConvertEntityToDTO(eq)).ToList();

            return new InventoryManagmentDTO(entity.Id, entity.Beginning, entity.End, room, equipment);
        }

        public List<InventoryManagment> ConvertListDTOToListEntity(IEnumerable<InventoryManagmentDTO> dtos)
        => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<InventoryManagmentDTO> ConvertListEntityToListDTO(List<InventoryManagment> entities)
        => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
