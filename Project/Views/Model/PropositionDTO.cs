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
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Description { get; set; }

        public int Positive { get; set; }

        public int Negative { get; set; }

        public List<ApprovalDTO> Approvals { get; set; }

        public PropositionDTO() {  }

        public PropositionDTO(string name,string description, string state) {
            Name = name;
            State = state;
            Description = description;
        }

        public PropositionDTO(int id, string name, string description, string state, int positive, int negative)
        {
            Id = id;
            Name = name;
            State = state;
            Description = description;
            Positive = positive;
            Negative = negative;
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
