using Org.BouncyCastle.Asn1.Cms;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.CSV.Converter
{
    class SecretaryCSVConverter: ICSVConverter<Secretary>
    {
        private readonly string _delimiter;
        private readonly string _datetimeFormat;
     
        public SecretaryCSVConverter(string delimiter, string datetimeFormat)
        {
            _delimiter = delimiter;
            _datetimeFormat = datetimeFormat;
        }

        public string ConvertEntityToCSVFormat(Secretary secretary)
           => string.Join(_delimiter,
               secretary.Id,
               secretary.Address.Id,
               secretary.FirstName,
               secretary.LastName,
               secretary.Jmbg,
               secretary.TelephoneNumber,
               secretary.Gender,
               secretary.DateOfBirth.ToString(_datetimeFormat),
               secretary.Salary,
               secretary.AnnualLeave.Start.ToString(_datetimeFormat),
               secretary.AnnualLeave.End.ToString(_datetimeFormat),
               secretary.WorkingHours.Start.ToString(_datetimeFormat),
               secretary.WorkingHours.End.ToString(_datetimeFormat),
               secretary.Email,
               secretary.Password
               );

        public Secretary ConvertCSVFormatToEntity(string secretaryCSVFormat)
        {
            string[] tokens = secretaryCSVFormat.Split(_delimiter.ToCharArray());
            return new Secretary(
                long.Parse(tokens[0]),
                new Address(long.Parse(tokens[1])),
                tokens[2],
                tokens[3],
                tokens[4],
                tokens[5],
                tokens[6],
                DateTime.Parse(tokens[7]),
                int.Parse(tokens[8]),
                new TimeInterval(DateTime.Parse(tokens[9]), DateTime.Parse(tokens[10])),
                new TimeInterval(DateTime.Parse(tokens[11]), DateTime.Parse(tokens[12])),
                tokens[13],
                tokens[14],
                new List<Question>()
            );
        }
    }
}
