using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    public class EquipmentDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public RoomDTO Room { get; set; }

        public EquipmentDTO() { }

        public EquipmentDTO(int id, string name,string type, string description,RoomDTO room)  
        {
            this.Id = id;
            this.Type = type;
            this.Description = description;
            this.Name = name;
            this.Room = room;
        }

        public EquipmentDTO(string name, string type, string description,RoomDTO room)
        {
            this.Type = type;
            this.Description = description;
            this.Name = name; 
            this.Room = room;
        }

    }
}
