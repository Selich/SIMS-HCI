using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    public class ItemDTO
    {
        public long Id;
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public ItemDTO()
        {

        }

        public ItemDTO(long id, int quantity, string name, string type, string description)
        {
            Id = id;
            Quantity = quantity;
            Name = name;
            Type = type;
            Description = description;
        }
        public ItemDTO(int quantity, string name, string type, string description)
        {
            Quantity = quantity;
            Name = name;
            Type = type;
            Description = description;
        }


    }
}
