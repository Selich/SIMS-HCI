﻿using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    public class DirectorDTO:EmployeeDTO
    {
        public DirectorDTO(long id, AddressDTO address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, double salary, TimeInterval annualLeave, TimeInterval workingHours, string email, string password) :
              base(id, address, firstName, lastName, jmbg, telephoneNumber, gender, dateOfBirth,salary,annualLeave,workingHours,email,password)
        {
            
        }
        public DirectorDTO(AddressDTO address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, double salary, TimeInterval annualLeave, TimeInterval workingHours, string email, string password) :
               base(address, firstName, lastName, jmbg, telephoneNumber, gender, dateOfBirth, salary, annualLeave, workingHours, email, password)
        {

        }
    }
}