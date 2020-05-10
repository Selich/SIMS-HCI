using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories
{
    class MedicalAppointmentRepository
    { 
        public IEnumerable<MedicalAppointment> ReadCSV(){
            string fileName = "../../Data/medicalAppointments.csv";
            string[] lines = File.ReadAllLines(System.IO.Path.ChangeExtension(fileName, ".csv"));
            PatientRepository pr = new PatientRepository();
            DoctorRepository dr = new DoctorRepository();



            return lines.Select(line =>
                {
                    string[] data = line.Split(';');

                    MedicalAppointment appointment= new MedicalAppointment();
                    appointment.id= Int32.Parse(data[0]);
                    appointment.begining= DateTime.Parse(data[1]);
                    appointment.end = DateTime.Parse(data[2]);
                    appointment.type = (MedicalAppointmentType)Enum.Parse(typeof(MedicalAppointmentType), data[3]);
                    appointment.patient = pr.getPatientById(Int32.Parse(data[3]));
                    List<Doctor> doctors = new List<Doctor>();
                    int i = 4;
                    while(data[i] != null)
                    {
                        Doctor doctor = new Doctor();
                        doctor = dr.getDoctorsById(Int32.Parse(data[i]));
                        doctors.Add(doctor);

                    }
                    appointment.doctors = doctors;
                    return appointment;

                });


        }

    }
}
