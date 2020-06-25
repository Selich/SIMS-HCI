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
        public string Login(string email, string password)
        {
            var patient = app.PatientController.GetByEmail(email);
            if(patient.Password == password) return "Patient";
            else return "Director";
        }
    }
}