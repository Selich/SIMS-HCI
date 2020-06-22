using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;
using Project.Views.Model;

namespace Project.Views.Converters
{
    public class EquipmentConverter : IConverter<Equipment, EquipmentDTO>
    {
        public Equipment ConvertDTOToEntity(EquipmentDTO dto)
        {
            throw new NotImplementedException();
        }

        public EquipmentDTO ConvertEntityToDTO(Equipment entity)
        {
            throw new NotImplementedException();
        }

        public List<Equipment> ConvertListDTOToListEntity(IEnumerable<EquipmentDTO> dtos)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EquipmentDTO> ConvertListEntityToListDTO(List<Equipment> entities)
        {
            throw new NotImplementedException();
        }
    }
}
