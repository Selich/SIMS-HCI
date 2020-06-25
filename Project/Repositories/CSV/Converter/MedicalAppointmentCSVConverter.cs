﻿using Project.Model;
using Project.Repositories.Abstract;
using Project.Repositories.ManyToMany.Model;
using Project.Repositories.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.CSV.Converter
{
    class MedicalAppointmentCSVConverter : ICSVConverter<MedicalAppointment>
    {
        private readonly string _delimiter;
        private readonly string _datetimeFormat;

        public MedicalAppointmentCSVConverter(
            string delimiter,
            string datetimeFormat
            )
        {
            _delimiter = delimiter;
            _datetimeFormat = datetimeFormat;
        }

        public string ConvertEntityToCSVFormat(MedicalAppointment medicalAppointment)
           => string.Join(_delimiter,
               medicalAppointment.Id,
               medicalAppointment.Beginning,
               medicalAppointment.End,
               medicalAppointment.Room.Id,
               medicalAppointment.Type,
               medicalAppointment.Patient.Id
               );

        public MedicalAppointment ConvertCSVFormatToEntity(string medicalAppointmentCSVFormat)
        {
            string[] tokens = medicalAppointmentCSVFormat.Split(_delimiter.ToCharArray());
            Guest guest = new Guest(long.Parse(tokens[5]));

            return new MedicalAppointment(
                long.Parse(tokens[0]),
                DateTime.Parse(tokens[1]),
                DateTime.Parse(tokens[2]),
                new Room(long.Parse(tokens[3])),
                (MedicalAppointmentType)Enum.Parse(typeof(MedicalAppointmentType),tokens[4]),
                new Guest(long.Parse(tokens[5])),
                new List<Doctor>() //doctors
                );
        }
    }
}
