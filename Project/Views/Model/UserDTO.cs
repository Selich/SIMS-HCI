using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Jmbg { get; set; }
        public string TelephoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public AddressDTO Address;
        public UserDTO() { }

        public UserDTO(long id, AddressDTO address,string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth)
        {
            Id = id;
            Address = address;
            FirstName = firstName;
            LastName = lastName;
            Jmbg = jmbg;
            TelephoneNumber = telephoneNumber;
            Gender = gender;
            DateOfBirth = dateOfBirth;
        }
        public UserDTO(AddressDTO address,string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth)
        {
            Address = address;
            FirstName = firstName;
            LastName = lastName;
            Jmbg = jmbg;
            TelephoneNumber = telephoneNumber;
            Gender = gender;
            DateOfBirth = dateOfBirth;
        }

    }
}
