// File:    PatientCotroller.cs
// Author:  Uros
// Created: Monday, May 4, 2020 8:27:25 PM
// Purpose: Definition of Class PatientCotroller

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Project.Controllers;
using Project.Views.Model;
using Project.Model;
using Project.Services;
using Project.Views.Converters;

namespace Project.Controllers
{
    public class PatientController : IController<PatientDTO, long>
    {
        private IService<Patient, long> _service;
        PatientConverter converter;

        public PatientController(IService<Patient, long> service)
        {
            _service = service;
            converter = new PatientConverter();

        }
        public PatientDTO Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PatientDTO> GetAll()
        {
            //List<Patient> patients = _service.GetAll();
            return null;
        }

        public PatientDTO Remove(PatientDTO entity)
        {
            Patient patient = _service.Remove(converter.ConvertDTOToEntity(entity));
            return converter.ConvertEntityToDTO(patient);
        }

        public PatientDTO Save(PatientDTO entity)
        {
            Patient patient = _service.Save(converter.ConvertDTOToEntity(entity));
            return converter.ConvertEntityToDTO(patient);
        }

        public PatientDTO Update(PatientDTO entity)
        {
            Patient patient = _service.Update(converter.ConvertDTOToEntity(entity));
            return converter.ConvertEntityToDTO(patient);
        }

    }
}