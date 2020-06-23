using Project.Model;
using Project.Repositories.Abstract;
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
        private IRepository<Room, long> _roomRepository;
        private IRepository<Guest, long> _guestRepository;
        private IRepository<MedicalAppointmentToDoctor, long> _medicalAppointmentToDoctorRepository;

        public MedicalAppointmentCSVConverter(
            string delimiter
            )
        {
            _delimiter = delimiter;
            //_roomRepository = roomRepository;
            //_guestRepository = guestRepository;
            //_medicalAppointmentToDoctorRepository = medicalAppointmentToDoctorRepository;
        }

        public string ConvertEntityToCSVFormat(MedicalAppointment medicalAppointment)
           => string.Join(_delimiter,
               medicalAppointment.Id,
               medicalAppointment.Beginning,
               medicalAppointment.End,
               medicalAppointment.Room.Id,
               medicalAppointment.Type,
               medicalAppointment.Patient.Id,
               " "// doctors
               );

        public MedicalAppointment ConvertCSVFormatToEntity(string medicalAppointmentCSVFormat)
        {
            string[] tokens = medicalAppointmentCSVFormat.Split(_delimiter.ToCharArray());
            return new MedicalAppointment(
                long.Parse(tokens[0]),
                DateTime.Parse(tokens[1]),
                DateTime.Parse(tokens[2]),
                new Room(long.Parse(tokens[3])),
                (MedicalAppointmentType)int.Parse(tokens[4]),
                new Patient(long.Parse(tokens[5])),
                null //doctors
                );
        }
    }
}
