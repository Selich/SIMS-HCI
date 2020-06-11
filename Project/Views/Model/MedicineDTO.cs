using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    public class MedicineDTO:ConsumabelsDTO
    {
        
        public string Purpose { get; set; }
        public string Administration { get; set; }
        public bool Approved { get; set; }

        //public PrescriptionDTO prescription { get; set; }
        
        public List<MedicineDTO> Alternatives { get; set; }

        public MedicineDTO() { }

        public MedicineDTO(int id, string name, string type, string description, int quantitiy,string purpose,string administration, bool approved)
            : base(id,name, type, description, quantitiy)
        {
     
            this.Purpose = purpose;
            this.Administration = administration;
            this.Approved = approved;
        }

        public MedicineDTO(string name, string type, string description, int quantitiy, string purpose, string administration, bool approved)
            : base(name, type, description, quantitiy)
        {
            
            this.Purpose = purpose;
            this.Administration = administration;
            this.Approved = approved;
        }

    }
}
