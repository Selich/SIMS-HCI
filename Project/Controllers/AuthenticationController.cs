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
            if (patient != null)
            {
                if (patient.Password == password)
                {
                    return Tuple.Create(patient as UserDTO, "Patient");
                }

            } 
            // else
            // if (secretary != null)
            // {
            //     if (secretary.Password == password)
            //     {
            //         return Tuple.Create(secretary as UserDTO, "Secretary");
            //     }

            // } else
            // if (doctor != null)
            // {
            //     if (doctor.Password == password)
            //     {
            //         return Tuple.Create(doctor as UserDTO, "Doctor");
            //     }
            // } else 
            // if (director.Email == email)
            // {
            //     if (director.Password == password)
            //     {
                    return Tuple.Create(director as UserDTO, "Director");
            //     }
            // }
            // return null;
        }
    }
}