using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Converters
{
    public class DoctorConverter : IConverter<Project.Model.Doctor, DoctorDTO>
    {
        private HospitalConverter _hospitalCnverter;

        public DoctorConverter(HospitalConverter hospitalCnverter)
        {
            _hospitalCnverter = hospitalCnverter;
        }

        public Project.Model.Doctor ConvertDTOToEntity(DoctorDTO dto)
            => new Project.Model.Doctor(dto.Id, new Address(), dto.FirstName, dto.LastName, dto.Jmbg, dto.TelephoneNumber, dto.Gender, dto.DateOfBirth, dto.Salary, dto.AnnualLeave, dto.WorkingHours, dto.Email, dto.Password,  dto.MedicalRole, _hospitalCnverter.ConvertDTOToEntity(dto.Hospital));


        public DoctorDTO ConvertEntityToDTO(Project.Model.Doctor entity)
            => new DoctorDTO(entity.Id, new AddressDTO(), entity.FirstName, entity.LastName, entity.Jmbg, entity.TelephoneNumber, entity.Gender, entity.DateOfBirth, entity.Salary, entity.AnnualLeave, entity.WorkingHours, entity.Email, entity.Password, _hospitalCnverter.ConvertEntityToDTO(entity.Hospital), entity.MedicalRole);

        public List<Project.Model.Doctor> ConvertListDTOToListEntity(IEnumerable<DoctorDTO> dtos)
            => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<DoctorDTO> ConvertListEntityToListDTO(List<Project.Model.Doctor> entities)
            => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
