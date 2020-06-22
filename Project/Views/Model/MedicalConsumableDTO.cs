using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    public class MedicalConsumableDTO : ConsumablesDTO
    {

        public List<MedicalAppointmentDTO> Appointments { get; set; }
        public MedicalConsumableDTO() { }

        public MedicalConsumableDTO(string name, string type, string description, int quantitiy)
            : base(name, type, description, quantitiy)
        {

        }
    }
}
