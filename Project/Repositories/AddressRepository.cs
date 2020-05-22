using Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace Project.Repositories
{
    public class AddressRepository
    {
        private string fileName;
        public AddressRepository()
        {
            // TODO: Maybe add ReadFile here
            fileName = "../../Data/address.csv";

        }
        public Address ConvertFromCSVToAddress(string line)
        {
            Address address = null;
            try
            {
                string[] data = line.Split(Util.Environment.delimiter);
                address = new Address(
                    Int32.Parse(data[0]), data[1], data[2],
                    data[3], data[4], data[5]
                );
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return address;
        }

        public Address GetAddressById(int addressID)
        {
            string[] items = Util.HelperFunctions.ReadFile(fileName);
            Address address = null;
            foreach (string item in items)
            {
                    address = ConvertFromCSVToAddress(item);
                    if (address.id == addressID)
                    {
                        return address;
                    }

            }
            return null;
        }
        public List<Address> GetAllAddress()
        {
            string[] items = Util.HelperFunctions.ReadFile(fileName);
            List<Address> addresses = new List<Address>();
            foreach (string item in items)
            {
                addresses.Add(ConvertFromCSVToAddress(item));
            }
            return addresses;
        }



    }
}