using Project.Model;
using System;

namespace Project.Repositories.CSV.Converter
{
    public class PatientCSVConverter : ICSVConverter<Patient>
    {
        private readonly string _delimiter;
        private readonly string _datetimeFormat;

        public PatientCSVConverter(string delimiter, string datetimeFormat)
        {
            _delimiter = delimiter;
            _datetimeFormat = datetimeFormat;
        }

        public string ConvertEntityToCSVFormat(Patient patient)
           => string.Join(_delimiter,
               patient.Id,
               patient.Address.Id,
               patient.FirstName,
               patient.LastName,
               patient.Jmbg,
               patient.TelephoneNumber,
               patient.Gender,
               patient.DateOfBirth.ToString(_datetimeFormat),
               patient.InsurenceNumber,
               patient.Profession,
               patient.BloodType,
               patient.Height,
               patient.Weight,
               patient.Email,
               patient.Password
               );

        public Patient ConvertCSVFormatToEntity(string patientCSVFormat)
        {
            string[] tokens = patientCSVFormat.Split(_delimiter.ToCharArray());
            return new Patient(
                long.Parse(tokens[0]),
                new Address(), 
                tokens[1],
                tokens[2],
                tokens[3],
                tokens[4],
                tokens[5],
                DateTime.Parse(tokens[6]),
                tokens[7],
                tokens[8],
                tokens[9],
                float.Parse(tokens[10]),
                float.Parse(tokens[11]),
                tokens[12],
                tokens[13]
            );
        }
    }
}
