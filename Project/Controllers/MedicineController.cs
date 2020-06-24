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
using Project.Services;

namespace Controller
{
    public class MedicineController : IController<MedicineDTO, long>
    {
        private IService<Medicine,long> _medicineService;
        private IConverter<Medicine, MedicineDTO> _medicineConverter;


        public MedicineController(
            IService<Medicine, long> medicineService,
            IConverter<Medicine, MedicineDTO> medicineConverter
            )
        {
            _medicineService = medicineService;
            _medicineConverter = medicineConverter;
            
        }
        

        public MedicineDTO GetById(long id)
            => _medicineConverter.ConvertEntityToDTO(_medicineService.GetById(id));

        public IEnumerable<MedicineDTO> GetAll()
            => _medicineConverter.ConvertListEntityToListDTO((List<Medicine>)_medicineService.GetAll());

        public MedicineDTO Remove(MedicineDTO entity)
            => _medicineConverter.ConvertEntityToDTO(_medicineService.Remove(_medicineConverter.ConvertDTOToEntity(entity)));

        public MedicineDTO Save(MedicineDTO entity)
            => _medicineConverter.ConvertEntityToDTO(_medicineService.Save(_medicineConverter.ConvertDTOToEntity(entity)));

        public MedicineDTO Update(MedicineDTO entity)
            => _medicineConverter.ConvertEntityToDTO(_medicineService.Update(_medicineConverter.ConvertDTOToEntity(entity)));
        
        /*
        public  MedicineDTO GetByName(string name)
            => _medicineConverter.ConvertEntityToDTO(_medicineService.GetByName(name));

        public MedicineDTO RegisternMedicine(string name, string type, string administration, string purpose, string description)
           => _medicineConverter.ConvertEntityToDTO(_medicineService.RegisternMedicine(name, type, administration, purpose, description));*/

    }
}