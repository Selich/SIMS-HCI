using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    public class FeedbackDTO
    {
        public String Type { get; set; }
        public String Description { get; set; }

        public FeedbackDTO() { }

        public FeedbackDTO(String type,String desc)
        {
            this.Type = type;
            this.Description = desc;
        }
    }
}
