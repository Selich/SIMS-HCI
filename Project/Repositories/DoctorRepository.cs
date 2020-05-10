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
        public Doctor getDoctorsById(int id)
        {
            string fileName = "../../Data/doctors.csv";
            Doctor doctor = new Doctor();
            string[] lines = File.ReadAllLines(System.IO.Path.ChangeExtension(fileName, ".csv"));
            foreach(string line in lines)
            {
                string[] data = line.Split(';');
                if(Int32.Parse(data[0]) == id)
                {
                    doctor.id = Int32.Parse(data[0]);
                    doctor.firstName = data[1];
                    doctor.lastName = data[2];
                    doctor.jmbg = data[3];
                    break;
                }

            }
            return doctor;

        }
        public List<String> getTypeOfDoctors(){
            string fileName = "../../Data/doctors.csv";
            string[] lines = File.ReadAllLines(System.IO.Path.ChangeExtension(fileName, ".csv"));
            List<String> types = new List<String>();

            foreach (var line in lines)
            { 
                    string[] data = line.Split(';');
                    if(!types.Contains(data[4])) types.Add(data[4]);
                
            }
            return types;

        }
        
    }
}