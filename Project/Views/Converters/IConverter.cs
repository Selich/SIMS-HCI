using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Converters
{
    public interface IConverter<E, DTO> 
        where E : class 
        where DTO : class
    {
        DTO ConvertEntityToDTO(E entity);

        E ConvertDTOToEntity(DTO dto);
        IEnumerable<E> ConvertListDTOToListEntity(IEnumerable<DTO> dtos);
        IEnumerable<DTO> ConvertListEntityToListDTO(IEnumerable<E> entities);
    }
}
