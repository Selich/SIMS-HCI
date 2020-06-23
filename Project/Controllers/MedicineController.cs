// File:    MedicineController.cs
// Author:  Lenovo_NB
// Created: Friday, May 8, 2020 12:06:44 AM
// Purpose: Definition of Class MedicineController

using System;
using Project.Model;
using System.Collections.Generic;
using Project.Controllers;
using Project.Services;
using Project.Views.Converters;
using Project.Views.Model;
using Project;

namespace Controller
{
    public class MedicineController : IController<MedicineDTO, long>
    {
        private IService<Medicine, long> _service;
        private IConverter<Medicine, MedicineDTO> _medicineConverter;
        public MedicineController(
            IService<Medicine, long> service,
            IConverter<Medicine, MedicineDTO> medicineConverter
            )
        {
            _service = service;
            _medicineConverter = medicineConverter;
            
        }
        public MedicineDTO GetById(long id)
            => _medicineConverter.ConvertEntityToDTO(_service.GetById(id));

        public IEnumerable<MedicineDTO> GetAll()
            => _medicineConverter.ConvertListEntityToListDTO((List<Medicine>)_service.GetAll());

        public MedicineDTO Remove(MedicineDTO entity)
            => _medicineConverter.ConvertEntityToDTO(_service.Remove(_medicineConverter.ConvertDTOToEntity(entity)));

        public MedicineDTO Save(MedicineDTO entity)
            => _medicineConverter.ConvertEntityToDTO(_service.Save(_medicineConverter.ConvertDTOToEntity(entity)));

        public MedicineDTO Update(MedicineDTO entity)
            => _medicineConverter.ConvertEntityToDTO(_service.Update(_medicineConverter.ConvertDTOToEntity(entity)));

        /*
        public  MedicineDTO GetByName(string name)
            => _medicineConverter.ConvertEntityToDTO(_service.GetByName(name));*/
    }
}