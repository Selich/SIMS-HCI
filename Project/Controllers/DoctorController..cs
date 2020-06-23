﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Project.Controllers;
using Project.Views.Model;
using Project.Model;
using Project.Services;
using Project.Views.Converters;

namespace Project.Controllers
{
    /// <summary>
    /// Interaction logic for DoctorController.xaml
    /// </summary>
    public partial class DoctorController : IController<DoctorDTO, long>
    {
        private IService<Doctor, long> _service;
        private IConverter<Doctor, DoctorDTO> _converter;

        public DoctorController(IService<Doctor, long> service, IConverter<Doctor, DoctorDTO> converter)
        {
            _service = service;
            _converter = converter;
        }

        public DoctorDTO GetById(long id) 
            => _converter.ConvertEntityToDTO(_service.GetById(id));

        public IEnumerable<DoctorDTO> GetAll() 
            => _converter.ConvertListEntityToListDTO((List<Doctor>)_service.GetAll());

        public DoctorDTO Remove(DoctorDTO entity)
            => _converter.ConvertEntityToDTO(_service.Remove(_converter.ConvertDTOToEntity(entity)));

        public DoctorDTO Save(DoctorDTO entity)
            => _converter.ConvertEntityToDTO(_service.Save(_converter.ConvertDTOToEntity(entity)));

        public DoctorDTO Update(DoctorDTO entity)
            => _converter.ConvertEntityToDTO(_service.Update(_converter.ConvertDTOToEntity(entity)));
    }
}
