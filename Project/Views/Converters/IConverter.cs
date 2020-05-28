using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Converters
{
    interface IConverter<E, DTO> 
        where E : class 
        where DTO : class
    {
        DTO ConvertEntityToDTO(E entity);

        E ConvertDTOToEntity(DTO dto);
        List<DTO> ConvertListEntityToListDTO(List<E> entities);

        List<E> ConvertListDTOToListEntity(List<DTO> dtos);

    }
}
