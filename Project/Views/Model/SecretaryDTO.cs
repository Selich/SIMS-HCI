using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Project.Views.Model
{
   public class SecretaryDTO : EmployeeDTO
   {
        public List<QuestionDTO> Questions { get; set; }
   }
}
