using Org.BouncyCastle.Asn1.Cms;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.CSV.Converter
{
    class DoctorCSVConverter: ICSVConverter<Doctor>
    {
        private readonly string _delimiter;
        private readonly string _datetimeFormat;
     
        public DoctorCSVConverter(string delimiter, string datetimeFormat)
        {
            _delimiter = delimiter;
            _datetimeFormat = datetimeFormat;
        }

        public string ConvertEntityToCSVFormat(Doctor doctor)
           => string.Join(_delimiter,
               doctor.Id,
               doctor.Address.Id,
               doctor.FirstName,
               doctor.LastName,
               doctor.Jmbg,
               doctor.TelephoneNumber,
               doctor.Gender,
               doctor.DateOfBirth.ToString(_datetimeFormat),
               doctor.Salary,
               doctor.AnnualLeave.Start.ToString(_datetimeFormat),
               doctor.AnnualLeave.End.ToString(_datetimeFormat),
               doctor.WorkingHours.Start.ToString(_datetimeFormat),
               doctor.WorkingHours.End.ToString(_datetimeFormat),
               doctor.Email,
               doctor.Password,
               doctor.MedicalRole
               );

        public Doctor ConvertCSVFormatToEntity(string secretaryCSVFormat)
        {
            string[] tokens = secretaryCSVFormat.Split(_delimiter.ToCharArray());
            return new Doctor(
                long.Parse(tokens[0]),
                new Address(long.Parse(tokens[1])),
                tokens[2],
                tokens[3],
                tokens[4],
                tokens[5],
                tokens[6],
                DateTime.Parse(tokens[7]),
                double.Parse(tokens[8]),
                new TimeInterval(DateTime.Parse(tokens[9]), DateTime.Parse(tokens[10])),
                new TimeInterval(DateTime.Parse(tokens[11]), DateTime.Parse(tokens[12])),
                tokens[13],
                tokens[14],
                tokens[15]
            );
        }
    }
}
