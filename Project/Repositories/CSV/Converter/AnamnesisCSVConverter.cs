using Project.Model;
using System;

namespace Project.Repositories.CSV.Converter
{
    public class AnamnesisCSVConverter : ICSVConverter<Anamnesis>
    {
        private readonly string _delimiter;
        private readonly string _datetimeFormat;

        public AnamnesisCSVConverter(string delimiter, string datetimeFormat)
        {
            _delimiter = delimiter;
            _datetimeFormat = datetimeFormat;
        }

        public string ConvertEntityToCSVFormat(Anamnesis anamnesis)
            => string.Join(_delimiter, anamnesis.Id, anamnesis.Name, anamnesis.Type, anamnesis.Id);


        public Anamnesis ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            return new Anamnesis(
                long.Parse(tokens[0]),
                tokens[1],
                tokens[2],
                tokens[3]
                );
        }
          
    }
}
