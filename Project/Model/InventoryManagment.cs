using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class InventoryManagment : Appointment
    {

        public List<Equipment> Equipment { get; set; }

        public InventoryManagment(long id, DateTime beginning, DateTime end, Room room)
            : base(id, beginning, end, room)
        { }

        public InventoryManagment(long id, DateTime beginning, DateTime end, Room room, List<Equipment> equipment)
            : base(id, beginning, end, room)
        {
            Equipment = equipment;
        }
        public InventoryManagment(DateTime beginning, DateTime end, Room room)
            : base(beginning, end, room)
        { }

    }
}
