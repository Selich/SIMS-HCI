using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    public class PropositionDTO
    {
        public string Name { get; set; }
        public string State { get; set; }
        public string Description { get; set; }

        public PropositionDTO() {  }

        public PropositionDTO(string name,string description, string state) {
            Name = name;
            State = state;
            Description = description;
        }
    }
}
