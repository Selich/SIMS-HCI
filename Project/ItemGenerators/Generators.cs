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
        public List<Room> GetRooms(int count)
        {
            List<Room> list = new List<Room>();
            for(int i = 1 ; i < count; i++){
                Room room = new Room();
                room.id = i;
                room.type = RoomType.hospitalRoom;
                room.ward = "ward";
                room.floor = "3";
                list.Add(room);

            }
            return list;

        }


        public Patient GeneratePatient(){
            var random = new Random();
            Patient patient = new Patient(
                firstNames[random.Next(firstNames.Length)], 
                lastNames[random.Next(lastNames.Length)]
                );

            patient.address = new Address("12", "Bulevar despota Stefana", "Novi Sad", "Republika Srbija", "21000");
            return patient;
            
                
        }
        public Doctor GenerateDoctor(){
            var random = new Random();
            return new Doctor( firstNames[random.Next(firstNames.Length)], lastNames[random.Next(lastNames.Length)]);
        }
        public List<Doctor> GenerateDoctors(int count){
            List<Doctor> list = new List<Doctor>();
            for(int i = 0; i < count; i++)
            {
                list.Add(GenerateDoctor());
            }
            return list;
        }

    }
}
