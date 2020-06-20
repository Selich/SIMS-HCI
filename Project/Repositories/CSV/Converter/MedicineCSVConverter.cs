using Project.Model;
using Project.Repositories.Abstract;

namespace Project.Repositories.CSV.Converter
{
    public class MedicineCSVConverter : ICSVConverter<Medicine>
    {
        private readonly string _delimiter;
        private readonly string _datetimeFormat;
        private IRepository<Medicine, long> _medicineRepository;
        public MedicineCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }
        public string ConvertEntityToCSVFormat(Medicine medicine)
           => string.Join(_delimiter,
               medicine.Id,
               medicine.Purpose,
               medicine.Administration,
               (medicine.Approved) ? 1 : 0
               );

        public Medicine ConvertCSVFormatToEntity(string medicineCSVFormat)
        {
            string[] tokens = medicineCSVFormat.Split(_delimiter.ToCharArray());
            return new Medicine(
                long.Parse(tokens[0]),
                tokens[1],
                tokens[2],
                (long.Parse(tokens[3]) == 1)
            );
        }

    }
}