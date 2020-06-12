using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    public class RenovationDTO:AppointmentDTO
    {
        public string Type { get; set; }

        public RenovationDTO() { }

        public RenovationDTO(long id, DateTime beginning, DateTime end, RoomDTO room,string type):
           base(id, beginning, end, room)
        {
            this.Type = type;
        }

        public RenovationDTO(DateTime beginning, DateTime end, RoomDTO room, string type) :
           base(beginning, end, room)
        {
            this.Type = type;
        }
    }
}
