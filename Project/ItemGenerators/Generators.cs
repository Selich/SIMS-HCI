using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ItemGenerators
{
    class Generators
    {

        public string[] firstNames = {"Nikola", "Dusan", "Uros", "Filip"};
        public string[] lastNames = {"Selic", "Urosevic", "Zdelar", "Milovanovic"};
        public List<MedicalAppointment> GetMedicalAppointments(int count)
        {
            List<MedicalAppointment> list = new List<MedicalAppointment>();
            for(int i = 0 ; i < count + 1; i++){
                List<Doctor> doctors = new List<Doctor>();
                doctors.Add(GenerateDoctor());
                MedicalAppointment ap = new MedicalAppointment(
                    i,
                    new DateTime(2020, 8, 18,8,00,0),
                    new DateTime(2020, 8, 18,8,30,0),
                    new Room(1,RoomType.hospitalRoom,"ward", "floor"),
                    MedicalAppointmentType.examination,
                    GeneratePatient(),
                    doctors
                );
                list.Add(ap);


            }
            return list;

        }


        public Patient GeneratePatient(){
            var random = new Random();
            return new Patient(
                firstNames[random.Next(firstNames.Length)], 
                lastNames[random.Next(lastNames.Length)]
                );
                
        }
        public Doctor GenerateDoctor(){
            var random = new Random();
            return new Doctor( firstNames[random.Next(firstNames.Length)], lastNames[random.Next(lastNames.Length)]);
        }
    }
}
