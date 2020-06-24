using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;
using System.Web.UI.WebControls;

namespace Project.Views.Converters
{
    public class SecretaryConverter : IConverter<Project.Model.Secretary, SecretaryDTO>
    {
        private QuestionConverter _questionConverter;
        private AddressConverter _addressConverter;

        public SecretaryConverter(QuestionConverter questionConverter,AddressConverter addressConverter)
        {
            _questionConverter = questionConverter;
            _addressConverter = addressConverter;
        }

        public Project.Model.Secretary ConvertDTOToEntity(SecretaryDTO dto)
        {
            List<Question> questions = dto.Questions.Select(qu => _questionConverter.ConvertDTOToEntity(qu)).ToList();

            return new Project.Model.Secretary(
                    dto.Id,
                    _addressConverter.ConvertDTOToEntity(dto.Address),
                    dto.FirstName,
                    dto.LastName,
                    dto.Jmbg,
                    dto.TelephoneNumber,
                    dto.Gender,
                    dto.DateOfBirth,
                    dto.Salary,
                    dto.AnnualLeave,
                    dto.WorkingHours,
                    dto.Email,
                    dto.Password,
                    questions
                    );
        }

        public SecretaryDTO ConvertEntityToDTO(Project.Model.Secretary entity)
        {

            List<QuestionDTO> questions = entity.Questions.Select(qu => _questionConverter.ConvertEntityToDTO(qu)).ToList();

            return new SecretaryDTO(
                    entity.Id,
                    _addressConverter.ConvertEntityToDTO(entity.Address),
                    entity.FirstName,
                    entity.LastName,
                    entity.Jmbg,
                    entity.TelephoneNumber,
                    entity.Gender,
                    entity.DateOfBirth,
                    entity.Salary,
                    entity.AnnualLeave,
                    entity.WorkingHours,
                    entity.Email,
                    entity.Password,
                    questions
                    );
        }
        public List<Project.Model.Secretary> ConvertListDTOToListEntity(IEnumerable<SecretaryDTO> dtos)
        => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<SecretaryDTO> ConvertListEntityToListDTO(List<Project.Model.Secretary> entities)
        => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
