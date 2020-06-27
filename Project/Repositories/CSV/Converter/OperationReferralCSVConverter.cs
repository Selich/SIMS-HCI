using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;
using Project.Model.Referrals;

namespace Project.Repositories.CSV.Converter
{
    public class OperationReferralCSVConventer : ICSVConverter<OperationReferral>
    {
        private readonly string _delimiter;
        private readonly string _datetimeFormat;

        public OperationReferralCSVConventer(string delimiter, string datetimeFormat)
        {
            _delimiter = delimiter;
            _datetimeFormat = datetimeFormat;
        }

        public string ConvertEntityToCSVFormat(OperationReferral referral)
           => string.Join(_delimiter,
               referral.Id,
               referral.Date.ToString(_datetimeFormat),
               referral.MedicalAppointment.Id
               );

        public OperationReferral ConvertCSVFormatToEntity(string referralCSVFormat)
        {
            string[] tokens = referralCSVFormat.Split(_delimiter.ToCharArray());
            return new OperationReferral(
                long.Parse(tokens[0]),
                DateTime.Parse(tokens[1]),
                new MedicalAppointment(long.Parse(tokens[2]))
            );
        }

    }
}
