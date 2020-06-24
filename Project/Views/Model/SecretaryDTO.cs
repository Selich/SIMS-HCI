using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Project.Model;
using System.Web.UI.WebControls;

namespace Project.Views.Model
{
   public class SecretaryDTO : EmployeeDTO
   {
        public List<QuestionDTO> Questions { get; set; }

        public SecretaryDTO() { }

        public SecretaryDTO(AddressDTO address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, double salary, TimeInterval annualLeave, TimeInterval workingHours, string email, string password, List<QuestionDTO> questions) :
              base(address, firstName, lastName, jmbg, telephoneNumber, gender, dateOfBirth, salary, annualLeave, workingHours, email, password)
        {
            Questions = questions;
        }
        public SecretaryDTO(long id, AddressDTO address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, double salary, TimeInterval annualLeave, TimeInterval workingHours, string email, string password, List<QuestionDTO> questions) :
              base(id, address, firstName, lastName, jmbg, telephoneNumber, gender, dateOfBirth, salary, annualLeave, workingHours, email, password)
        {
            Questions = questions;
        }

        public SecretaryDTO(long id, AddressDTO address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, double salary, TimeInterval annualLeave, TimeInterval workingHours, string email, string password) :
              base(id, address, firstName, lastName, jmbg, telephoneNumber, gender, dateOfBirth, salary, annualLeave, workingHours, email, password)
        {
            Questions = new List<QuestionDTO>();
        }

        public SecretaryDTO(AddressDTO address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, double salary, TimeInterval annualLeave, TimeInterval workingHours, string email, string password, string hospital) :
              base(address, firstName, lastName, jmbg, telephoneNumber, gender, dateOfBirth,salary,annualLeave,workingHours,email,password,hospital)
        {
            Questions = new List<QuestionDTO>();
        }
        public SecretaryDTO(long id,AddressDTO address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, double salary, TimeInterval annualLeave, TimeInterval workingHours, string email, string password, string hospital) :
              base(id,address, firstName, lastName, jmbg, telephoneNumber, gender, dateOfBirth, salary, annualLeave, workingHours, email, password, hospital)
        {
            Questions = new List<QuestionDTO>();
        }

        
    }
}
