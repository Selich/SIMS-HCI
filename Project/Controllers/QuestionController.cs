// File:    QuestionController.cs
// Author:  Uros
// Created: Monday, May 4, 2020 8:43:25 PM
// Purpose: Definition of Class QuestionController

using System;
using System.Collections.Generic;
using Project.Controllers;
using Project.Model;
using Project.Services;
using Project.Views.Converters;
using Project.Views.Model;

namespace Controller
{
    public class QuestionController : IController<QuestionDTO, long>
    {
        private IService<Question, long> _service;
        private IConverter<Patient, PatientDTO> _patientConverter;
        private IConverter<Question, QuestionDTO> _questionConverter;


        public QuestionController(
            IService<Question, long> service,
            IConverter<Question, QuestionDTO> questionConverter,
            IConverter<Patient, PatientDTO> patientConverter
            )
        {
            _service = service;
            _patientConverter = patientConverter;
            _questionConverter = questionConverter;
        }

        public QuestionDTO Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<QuestionDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public QuestionDTO Remove(QuestionDTO entity)
        {
            throw new NotImplementedException();
        }

        public QuestionDTO Save(QuestionDTO entity)
        {
            throw new NotImplementedException();
        }

        public QuestionDTO Update(QuestionDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}