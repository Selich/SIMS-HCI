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
            string delimiter,
            IRepository<Room, long> roomRepository,
            IRepository<Guest, long> guestRepository,
            IRepository<MedicalAppointmentToDoctor, long> medicalAppointmentToDoctorRepository
            )
        {
            _delimiter = delimiter;
            _roomRepository = roomRepository;
            _guestRepository = guestRepository;
            _medicalAppointmentToDoctorRepository = medicalAppointmentToDoctorRepository;
        }

        public string ConvertEntityToCSVFormat(MedicalAppointment medicalAppointment)
           => string.Join(_delimiter,
               medicalAppointment.Id,
               medicalAppointment.Beginning,
               medicalAppointment.End,
               medicalAppointment.Room.Id,
               medicalAppointment.Type,
               medicalAppointment.Patient.Id,
               _medicalAppointmentToDoctorRepository.Save(

               );

        public MedicalAppointment ConvertCSVFormatToEntity(string questionCSVFormat)
        {
            string[] tokens = questionCSVFormat.Split(_delimiter.ToCharArray());
            return new MedicalAppointment(
                long.Parse(tokens[0]),
                tokens[1],
                tokens[2],
                new Patient(),
                new Secretary(),
                DateTime.Parse(tokens[5])
            );
        }
    }
}
