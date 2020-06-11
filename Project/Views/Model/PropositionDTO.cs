using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Project.Views.Model
{
    public class PropositionDTO
    {
        int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Description { get; set; }

        public List<ApprovalDTO> Approvals { get; set; }

        public DirectorDTO Director { get; set; }

        public PropositionDTO() {  }

        public PropositionDTO(string name,string description, string state) {
            Name = name;
            State = state;
            Description = description;
        }

        public PropositionDTO(int id,string name, string description, string state)
        {
            Id = id;
            Name = name;
            State = state;
            Description = description;
        }
    }
}
