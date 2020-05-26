// File:    User.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:12:43 PM
// Purpose: Definition of Class User

using System;
using System.Collections.Generic;

namespace Project.Model
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Jmbg { get; set; }
        public string TelephoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Feedback[] Feedbacks;
        public Address Address;
        public List<Report> Reports;

        public User(long id, Address address,string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth)
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

        public User()
        {
        }
    }

}