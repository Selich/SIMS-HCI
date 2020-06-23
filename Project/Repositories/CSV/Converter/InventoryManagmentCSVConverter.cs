using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.CSV.Converter
{
    class InventoryManagmentCSVConverter : ICSVConverter<InventoryManagment>
    {
        private readonly string _delimiter;
        private readonly string _datetimeFormat;

        public InventoryManagmentCSVConverter(string delimiter, string datetimeFormat)
        {
            _delimiter = delimiter;
            _datetimeFormat = datetimeFormat;
        }

        public InventoryManagment ConvertCSVFormatToEntity(string inventoryCSVFormat)
        {
            string[] tokens = inventoryCSVFormat.Split(_delimiter.ToCharArray());
            return new InventoryManagment(
                long.Parse(tokens[0]),
                DateTime.Parse(tokens[1]),
                DateTime.Parse(tokens[2]),
                new Room(long.Parse(tokens[3])),
                new List<Equipment>()
            );
        }

        public string ConvertEntityToCSVFormat(InventoryManagment inventory)
        {
            string EquipmentIDs ="";

            foreach (Equipment eq in inventory.Equipment)
                EquipmentIDs += eq.Id +_delimiter;

            return string.Join(_delimiter,
                inventory.Id,
                inventory.Beginning.ToString(_datetimeFormat),
                inventory.End.ToString(_datetimeFormat),
                inventory.Room.Id,
                EquipmentIDs
                );
        }
    }
}
