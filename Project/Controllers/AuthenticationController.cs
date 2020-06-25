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
        public string Login(string email, string pass)
        {
            var patients = app.PatientController.GetAll();
            // if(app.PatientController.GetAll().Where(user => user.Email == email && user.Password == pass) != null) return "Patient";
            if(app.secretaries.Find(user => user.Email == email && user.Password == pass) != null) return "Secretary";

            return "Director";
        }
    }
}