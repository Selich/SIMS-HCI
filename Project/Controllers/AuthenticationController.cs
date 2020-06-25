using System;
using Project.Services;
using Project.Model;
using System.Collections.Generic;
using Project.Views.Model;
using System.Windows;

namespace Project.Controllers
{
    public class AuthenticationController
    {
        App app;
        public AuthenticationController()
        {
            app = Application.Current as App;


        }
        public System.Tuple<UserDTO, string> Login(string email, string password)
        {
            PatientDTO patient = app.PatientController.GetByEmail(email);
            SecretaryDTO secretary = app.SecretaryController.GetByEmail(email);
            DoctorDTO doctor = app.DoctorController.GetByEmail(email);
            DirectorDTO director = app.director;
            if(patient.Email == email && patient.Password == password) return Tuple.Create(patient as UserDTO, "Patient");
            if(secretary.Email == email && secretary.Password == password) return Tuple.Create(secretary as UserDTO, "Secretary");
            if(doctor.Email == email && doctor.Password == password) return Tuple.Create(doctor as UserDTO, "Doctor");
            if(director.Email == email && director.Password == password) return Tuple.Create(director as UserDTO, "Director");
            return null;
        }
    }
}