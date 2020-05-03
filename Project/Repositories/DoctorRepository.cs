using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Model;

namespace Project.Repositories
{
    public class DoctorRepository
    {

        public IEnumerable<Doctor> ReadCSV(string fileName){
            string[] lines = File.ReadAllLines(System.IO.Path.ChangeExtension(fileName, ".csv"));


            return lines.Select(line =>
                {
                    string[] data = line.Split(';');

                    Doctor user = new Doctor();
                    user.firstName = data[1];
                    user.lastName = data[2];
                    user.jmbg = data[3];
                    return user;

                });


        }
        
    }
}