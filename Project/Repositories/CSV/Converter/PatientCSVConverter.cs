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
               patient.FirstName,
               patient.LastName,
               patient.DateOfBirth.ToString(_datetimeFormat),
               patient.Address.Id);

        public Patient ConvertCSVFormatToEntity(string clientCSVFormat)
        {
            string[] tokens = clientCSVFormat.Split(_delimiter.ToCharArray());
            return new Patient(
                long.Parse(tokens[0]),
                new Address(long.Parse(tokens[1])), 
                tokens[2],
                tokens[3],
                tokens[4],
                tokens[5],
                tokens[6],
                DateTime.Parse(tokens[7]),
                tokens[8],
                tokens[9],
                tokens[10],
                float.Parse(tokens[11]),
                float.Parse(tokens[12]),
                tokens[13],
                tokens[14]
            );
        }
    }
}
