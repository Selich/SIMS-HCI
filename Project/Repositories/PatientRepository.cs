using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Model;

namespace Project.Repositories
{
    public class PatientRepository
    {

        public IEnumerable<Patient> ReadCSV(string fileName){
            string[] lines = File.ReadAllLines(System.IO.Path.ChangeExtension(fileName, ".csv"));


            return lines.Select(line =>
                {
                    string[] data = line.Split(';');

                    Patient patient = new Patient();
                    patient.firstName = data[1];
                    patient.lastName = data[2];
                    patient.jmbg = data[3];
                    return patient;

                });


        }
        
    }
}