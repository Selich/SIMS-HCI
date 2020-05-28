using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Converters
{
    class AddressConverter : IConverter<Address, AddressDTO>
    {
        public Address ConvertDTOToEntity(AddressDTO dto)
            => new Address(
                dto.Id,
                dto.Number,
                dto.Street,
                dto.City,
                dto.Country,
                dto.PostCode
            );

        public AddressDTO ConvertEntityToDTO(Address entity)
            => new AddressDTO(
                entity.Id,
                entity.Number,
                entity.Street,
                entity.City,
                entity.Country,
                entity.PostCode
            );

        public List<Address> ConvertListDTOToListEntity(List<AddressDTO> dtos)
            => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public List<AddressDTO> ConvertListEntityToListDTO(List<Address> entities)
            => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
