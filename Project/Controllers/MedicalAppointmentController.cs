// File:    MedicalAppointmentController.cs
// Author:  Selic
// Created: Thursday, May 7, 2020 7:52:18 PM
// Purpose: Definition of Class MedicalAppointmentController

using System;
using System.Collections.Generic;
using Project.Controllers;
using Project.Model;
using Project.Services;
using Project.Views.Converters;
using Project.Views.Model;

namespace Controller
{
    public class MedicalAppointmentController : IController<MedicalAppointmentDTO, long>
    {
        private IService<MedicalAppointment, long> _service;
        private IConverter<MedicalAppointment, MedicalAppointmentDTO> _medicalAppointmentConverter;
        public MedicalAppointmentController( 
            IService<MedicalAppointment, long> service ,
            IConverter<MedicalAppointment, MedicalAppointmentDTO> medicalAppointmentConverter
            )
        {
            _service = service;
            _medicalAppointmentConverter = medicalAppointmentConverter;
        }
        public IEnumerable<MedicalAppointmentDTO> GetAll()
            => _medicalAppointmentConverter.ConvertListEntityToListDTO((List<MedicalAppointment>)_service.GetAll());

        public MedicalAppointmentDTO GetById(long id)
            => _medicalAppointmentConverter.ConvertEntityToDTO(_service.GetById(id));

        public MedicalAppointmentDTO Remove(MedicalAppointmentDTO entity)
            => _medicalAppointmentConverter.ConvertEntityToDTO(_service.Remove(_medicalAppointmentConverter.ConvertDTOToEntity(entity)));

        public MedicalAppointmentDTO Save(MedicalAppointmentDTO entity)
            => _medicalAppointmentConverter.ConvertEntityToDTO(_service.Save(_medicalAppointmentConverter.ConvertDTOToEntity(entity)));

        public MedicalAppointmentDTO Update(MedicalAppointmentDTO entity)
            => _medicalAppointmentConverter.ConvertEntityToDTO(_service.Update(_medicalAppointmentConverter.ConvertDTOToEntity(entity)));

    }
}