using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity
{
    public class EmplyeeDTO : UserDTO
    {
        public double Salary { get; set; }
        private Model.TimeInterval AnnualLeave { get; set; }
        private Model.TimeInterval WorkingHours { get; set; }
        public string Email { get; set; }
        private string Password { get; set; }

        public EmplyeeDTO() { }
        public EmplyeeDTO(long id, AddressDTO address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, double salary, Model.TimeInterval annualLeave, Model.TimeInterval workingHours, string email, string password) :
              base(id, address, firstName, lastName, jmbg, telephoneNumber, gender, dateOfBirth)
        {
            Salary = salary;
            AnnualLeave = annualLeave;
            WorkingHours = workingHours;
            Email = email;
            Password = password;
        }
    }
}
