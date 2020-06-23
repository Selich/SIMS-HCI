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
        private IConverter<Patient, PatientDTO> _converter;

        public PatientController(IService<Patient, long> service, IConverter<Patient, PatientDTO> converter)
        {
            _service = service;
            _converter = converter;

        }
        public PatientDTO GetById(long id) 
            => _converter.ConvertEntityToDTO(_service.GetById(id));

        public IEnumerable<PatientDTO> GetAll() 
            => _converter.ConvertListEntityToListDTO((List<Patient>)_service.GetAll());

        public PatientDTO Remove(PatientDTO entity)
            => _converter.ConvertEntityToDTO(_service.Remove(_converter.ConvertDTOToEntity(entity)));

        public PatientDTO Save(PatientDTO entity)
            => _converter.ConvertEntityToDTO(_service.Save(_converter.ConvertDTOToEntity(entity)));

        public PatientDTO Update(PatientDTO entity)
            => _converter.ConvertEntityToDTO(_service.Update(_converter.ConvertDTOToEntity(entity)));

    }
}