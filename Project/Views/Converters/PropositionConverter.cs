using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Converters
{
    public class PropositionConverter : IConverter<Proposition, PropositionDTO>
    {
        private DirectionConverter _directionConverter;
        private MedicineConverter _medicineConverter;
        private ApprovalConverter _approvalConverter;

        public PropositionConverter(MedicineConverter medicineConverter, DirectionConverter directionConverter, ApprovalConverter approvalConverter)
        {
            _medicineConverter = medicineConverter;
            _directionConverter = directionConverter;
            _approvalConverter = approvalConverter;
        }
        public Proposition ConvertDTOToEntity(PropositionDTO dto)
            => new Proposition(
                dto.Id,
                dto.State,
                dto.AnswerText,
                _patientConverter.ConvertListDTOToListEntity(dto.Approval),
                _medicineConverter.ConvertDTOToEntity(dto.Medicine),
                _directionConverter.ConvertDTOToEntity(dto.Director)
                
            );

        public PropositionDTO ConvertEntityToDTO(Proposition entity)
                => new PropositionDTO(
                entity.Id,
                entity.State,
                entity.AnswerText,
                _patientConverter.ConvertListEntityToListDTO(entity.Approval),
                _medicineConverter.ConvertEntityToDTO(entity.Medicine),
                _directionConverter.ConvertEntityToDTO(entity.Director)
                
                    );

        public List<Proposition> ConvertListDTOToListEntity(IEnumerable<PropositionDTO> dtos)
            => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<PropositionDTO> ConvertListEntityToListDTO(List<Proposition> entities)
            => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
