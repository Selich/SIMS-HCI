using Model;
using Project.ItemGenerators;
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
        public IEnumerable<MedicalAppointment> ReadCSV(string fileName)
        {
            string[] lines = File.ReadAllLines(System.IO.Path.ChangeExtension(fileName, ".csv"));
            PatientRepository pr = new PatientRepository();
            DoctorRepository dr = new DoctorRepository();
            Generators g = new Generators();



            return lines.Select(line =>
                {
                    string[] data = line.Split(';');

                    MedicalAppointment appointment = new MedicalAppointment();
                    appointment.id = Int32.Parse(data[0]);
                    appointment.beginning = DateTime.Parse(data[1]);
                    appointment.end = DateTime.Parse(data[2]);
                    appointment.type = (MedicalAppointmentType)Enum.Parse(typeof(MedicalAppointmentType), data[3]);
                    appointment.patient = g.GeneratePatient();
                    //appointment.patient = pr.getPatientById(Int32.Parse(data[4]));
                    //List<Doctor> doctors = new List<Doctor>();
                    //int i = 4;
                    //while (data[i] != null)
                    //{
                    //    Doctor doctor = new Doctor();
                    //    doctor = dr.getDoctorsById(Int32.Parse(data[i]));
                    //    doctors.Add(doctor);

                    //}
                    //appointment.doctors = doctors;
                    return appointment;

                });

        }
        public List<MedicalAppointment> GetMedicalAppointmentsByDoctorId(int doctorId)
        {
            string fileName = "../../Data/medicalAppointments.csv";
            string[] lines = File.ReadAllLines(System.IO.Path.ChangeExtension(fileName, ".csv"));
            PatientRepository pr = new PatientRepository();
            DoctorRepository dr = new DoctorRepository();
            List<MedicalAppointment> list = new List<MedicalAppointment>();



            foreach (var line in lines)
            {
                string[] data = line.Split(';');

                if (Int32.Parse(data[5]) == doctorId)
                {
                    MedicalAppointment appointment = new MedicalAppointment();

                    appointment.id = Int32.Parse(data[0]);
                    appointment.beginning = DateTime.Parse(data[1]);
                    appointment.end = DateTime.Parse(data[2]);
                    appointment.type = (MedicalAppointmentType)Enum.Parse(typeof(MedicalAppointmentType), data[3]);
                    appointment.patient = pr.getPatientById(Int32.Parse(data[4]));
                    List<Doctor> doctors = new List<Doctor>();
                    int i = 4;
                    while (data[i] != null)
                    {
                        Doctor doctor = new Doctor();
                        doctor = dr.getDoctorsById(Int32.Parse(data[i]));
                        doctors.Add(doctor);

                    }
                    appointment.doctors = doctors;
                    list.Add(appointment);
                }
            }
            return list;
        }

    }
}
