﻿using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Converters
{
    public class ApprovalConverter : IConverter<Approval, ApprovalDTO>
    {
        private DoctorConverter _doctorConverter;
        private PropositionConverter _propositionConverter;

        public ApprovalConverter(DoctorConverter doctorConverter, PropositionConverter propositionConverter)
        {
            _doctorConverter = doctorConverter;
            _propositionConverter = propositionConverter;
        }
        public Approval ConvertDTOToEntity(ApprovalDTO dto)
            => new Approval(
                dto.Description,
                dto.IsApproved,
                _doctorConverter.ConvertDTOToEntity(dto.Doctor),
                _propositionConverter.ConvertDTOToEntity(dto.Proposition)

            );

        public ApprovalDTO ConvertEntityToDTO(Approval entity)
            => new ApprovalDTO(
                entity.Description,
                entity.IsApproved,
                _doctorConverter.ConvertEntityToDTO(entity.Doctor),
                _propositionConverter.ConvertEntityToDTO(entity.Proposition)
                );

        public List<Approval> ConvertListDTOToListEntity(IEnumerable<ApprovalDTO> dtos)
            => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<ApprovalDTO> ConvertListEntityToListDTO(List<Approval> entities)
            => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
