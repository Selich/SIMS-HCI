using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Model;


namespace Project.Repositories
{
    public class PatientRepository
    {
        public AddressRepository addressRepository;
        private string fileName;

        public PatientRepository(){
             fileName = "../../Data/patients.csv";
             addressRepository = new AddressRepository();

        }

        public Patient convertFromCSVToPatient(string line){
            Patient patient = null;
            try
            {
                string[] data = line.Split(Util.Environment.delimiter);
                patient = new Patient();
                patient.id = Int32.Parse(data[0]);
                patient.firstName = data[1];
                patient.lastName = data[2];
                patient.jmbg = data[3];
                patient.gender = (Sex) Enum.Parse(typeof(Sex),data[4]);
                patient.telephoneNumber = data[5];
                patient.email = data[6];
                patient.address = addressRepository.GetAddressById(Util.HelperFunctions.ConvertIDToInt(data[7]));
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return patient;

        }

        // TODO: Sredi
        public IEnumerable<Patient> ReadCSV(string fileName){
            string[] lines = File.ReadAllLines(System.IO.Path.ChangeExtension(fileName, ".csv"));

            return lines.Select(line =>
                {
                    string[] data = line.Split(';');

                    Patient patient = new Patient();
                    patient.firstName = data[1];
                    patient.lastName = data[2];
                    patient.jmbg = data[3];
                    patient.telephoneNumber = data[4];
                    patient.email = data[5];
                    return patient;

                });


        }
        public Patient Save(Patient patient){
            Patient patient;
            return patient;

        }
        public Patient GetPatientById(int patientID)
        {
            string[] items = Util.HelperFunctions.ReadFile(fileName);
            Patient patient = null;
            foreach(string item in items)
            {
                patient = convertFromCSVToPatient(item);
                if (patient.id == patientID){
                    return patient;
                }

            }
            return patient;
        }

        public Patient GetPatientByEmail(string patientEmail){
            string[] items = Util.HelperFunctions.ReadFile(fileName);
            Patient patient = null;
            foreach(string item in items)
            {
                patient = convertFromCSVToPatient(item);
                if (patient.email == patientEmail){
                    return patient;
                }

            }
            return patient;

        }
        
    }
}