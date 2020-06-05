using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Views.Model;
using Project.Model;

namespace Project.Views.Converters
{
    public class PatientConverter : IConverter<Project.Model.Patient, PatientDTO>
    {
        public Project.Model.Patient ConvertDTOToEntity(PatientDTO dto)
            => new Project.Model.Patient(
                dto.Id,
                new Address(),
                dto.FirstName,
                dto.LastName,
                dto.Jmbg,
                dto.TelephoneNumber,
                dto.Gender,
                dto.DateOfBirth,
                dto.InsurenceNumber,
                dto.Profession,
                dto.BloodType,
                dto.Height,
                dto.Weight,
                dto.Email,
                dto.Password
            );

        public PatientDTO ConvertEntityToDTO(Project.Model.Patient entity)
                => new PatientDTO(
                entity.Id,
                new AddressDTO(
                    //entity.Address.Id,
                    //entity.Address.Number,
                    //entity.Address.Street,
                    //entity.Address.City,
                    //entity.Address.Country,
                    //entity.Address.PostCode
                ),
                entity.FirstName,
                entity.LastName,
                entity.Jmbg,
                entity.TelephoneNumber,
                entity.Gender,
                entity.DateOfBirth,
                entity.InsurenceNumber,
                entity.Profession,
                entity.BloodType,
                entity.Height,
                entity.Weight,
                entity.Email,
                entity.Password);

        public List<Project.Model.Patient> ConvertListDTOToListEntity(IEnumerable<PatientDTO> dtos)
            => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<PatientDTO> ConvertListEntityToListDTO(List<Project.Model.Patient> entities)
            => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
