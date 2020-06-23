using Project.Model;
using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project.Repositories.CSV.Converter
{
    class PrescriptionCSVConverter : ICSVConverter<Prescription>
    {
        private readonly string _delimiter;
        private readonly string _datetimeFormat;

        public PrescriptionCSVConverter(string delimiter, string datetimeFormat)
        {
            _delimiter = delimiter;
            _datetimeFormat = datetimeFormat;


        }

        public string ConvertEntityToCSVFormat(Prescription prescription)
           => string.Join(_delimiter,
               prescription.Id,
               prescription.Dosage,
               prescription.Usage,
               prescription.Period,
               prescription.Medicine.Id,
               prescription.Date,
               prescription.Patient.Id
               );

        public Prescription ConvertCSVFormatToEntity(string prescriptionCSVFormat)
        {
            string[] tokens = prescriptionCSVFormat.Split(_delimiter.ToCharArray());
            /*Prescription prescription = new Prescription(
                long.Parse(tokens[0]),
                int.Parse(tokens[1]),
                tokens[2],
                tokens[3],
                new Medicine("1","1",true,1,"n","d","d"),
                DateTime.Parse(tokens[5]),
                new Patient()
            );
            return prescription;*/

            return new Prescription(
                long.Parse(tokens[0]),
                int.Parse(tokens[1]),
                tokens[2],
                tokens[3],
                new Medicine(),
                DateTime.Parse(tokens[5]),
                new Patient()
            );
        }
        /*
        Prescription ICSVConverter<Prescription>.ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            throw new NotImplementedException();
        }*/
    }
}
