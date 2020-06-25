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
        private MedicineConverter _medicineConverter;
        private ApprovalConverter _approvalConverter;

        public PropositionConverter(MedicineConverter medicineConverter, ApprovalConverter approvalConverter)
        {
            _medicineConverter = medicineConverter;
            _approvalConverter = approvalConverter;
        }
        public Proposition ConvertDTOToEntity(PropositionDTO dto)
            => new Proposition(
                dto.State,
                _approvalConverter.ConvertListDTOToListEntity(dto.Approvals),
                _medicineConverter.ConvertDTOToEntity(dto.Medicine)
            );

        public PropositionDTO ConvertEntityToDTO(Proposition entity)
                => new PropositionDTO(
                entity.Id,
                entity.State,
                _medicineConverter.ConvertEntityToDTO(entity.Medicine)
                );

        public List<Proposition> ConvertListDTOToListEntity(IEnumerable<PropositionDTO> dtos)
            => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<PropositionDTO> ConvertListEntityToListDTO(List<Proposition> entities)
            => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
