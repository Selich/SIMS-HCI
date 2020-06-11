using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    public class MedicalConsumableDTO:ConsumabelsDTO
    {

        public List<MedicalAppointmentDTO> Appointments { get; set; }
        public MedicalConsumableDTO() { }

        public MedicalConsumableDTO(int id,string name, string type, string description, int quantitiy)
            :base(id,name,type,description,quantitiy) 
        {
            
        }
        public MedicalConsumableDTO(string name, string type, string description, int quantitiy)
            : base(name, type, description, quantitiy)
        {

        }
    }
}
