using Project.Model;

namespace Project.Repositories.CSV.Converter
{
    public class ItemCSVConverter : ICSVConverter<Item>
    {
        private readonly string _delimiter;

        public ItemCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(Item item)
          => string.Join(_delimiter,
              item.Id,
              item.Quantity,
              item.Name,
              item.Type,
              item.Description);

        public Item ConvertCSVFormatToEntity(string addressCSVFormat)
        {
            string[] tokens = addressCSVFormat.Split(_delimiter.ToCharArray());
            return new Item(
                long.Parse(tokens[0]),
                int.Parse(tokens[1]),
                tokens[2],
                tokens[3],
                tokens[4]);
        }
    }
}
