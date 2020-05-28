// File:    Address.cs
// Author:  Selic
// Created: Tuesday, April 14, 2020 5:08:10 PM
// Purpose: Definition of Class Address

using System;

namespace Project.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }

        public User[] User;

        public Address()
        {

        }

        public Address(int id, string number, string street, string city, string country, string postCode)
        {
            Id = id;
            Number = number;
            Street = street;
            City = city;
            Country = country;
            PostCode = postCode;
        }

    }
}