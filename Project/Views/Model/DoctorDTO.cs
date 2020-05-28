using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    class DoctorDTO : EmployeeDTO
    {
      public string MedicalRole { get; set; }

        public DoctorDTO(long id, AddressDTO address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, double salary, TimeInterval annualLeave, TimeInterval workingHours, string email, string password, string medicalRole):
            base( id,  address,  firstName,  lastName,  jmbg,  telephoneNumber,  gender,  dateOfBirth,  salary,  annualLeave,  workingHours,  email,  password)
        {
            MedicalRole = medicalRole;
        }
        public DoctorDTO(AddressDTO address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, double salary, TimeInterval annualLeave, TimeInterval workingHours, string email, string password, string medicalRole):
            base(address,  firstName,  lastName,  jmbg,  telephoneNumber,  gender,  dateOfBirth,  salary,  annualLeave,  workingHours,  email,  password)
        {
            MedicalRole = medicalRole;
        }
        public DoctorDTO() { }
    }
}
