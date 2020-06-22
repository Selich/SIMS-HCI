using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class InventoryReplacement : Appointment
    {

        public List<Equipment> Equipment { get; set; }
        public InventoryReplacement(long id, DateTime beginning, DateTime end, Room room)
            : base(id, beginning, end, room)
        { }
        public InventoryReplacement(DateTime beginning, DateTime end, Room room)
            : base(beginning, end, room)
        { }

    }
}
