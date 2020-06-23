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
        public Project.Model.Doctor ConvertDTOToEntity(DoctorDTO dto)
        {
            => new Project.Model.Doctor(
            )
        }

        public DoctorDTO ConvertEntityToDTO(Project.Model.Doctor entity)
        {
            throw new NotImplementedException();
        }

        public List<Project.Model.Doctor> ConvertListDTOToListEntity(IEnumerable<DoctorDTO> dtos)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DoctorDTO> ConvertListEntityToListDTO(List<Project.Model.Doctor> entities)
        {
            throw new NotImplementedException();
        }
    }
}
