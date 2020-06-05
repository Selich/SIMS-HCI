using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Converters
{
    public class GuestConverter : IConverter<Guest, GuestDTO>
    {
        public Guest ConvertDTOToEntity(GuestDTO dto)
        {
            throw new NotImplementedException();
        }

        public GuestDTO ConvertEntityToDTO(Guest entity)
        {
            throw new NotImplementedException();
        }

        public List<Guest> ConvertListDTOToListEntity(IEnumerable<GuestDTO> dtos)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GuestDTO> ConvertListEntityToListDTO(List<Guest> entities)
        {
            throw new NotImplementedException();
        }
    }
}
