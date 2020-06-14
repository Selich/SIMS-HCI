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
            if(app.patients.Find(user => user.Email == email && user.Password == pass) != null) return "Patient";
            if(app.secretaries.Find(user => user.Email == email && user.Password == pass) != null) return "Secretary";
            if(app.directors.Find(user => user.Email == email && user.Password == pass) != null) return "Director";
            if(app.doctors.Find(user => user.Email == email && user.Password == pass) != null) return "Doctor";

            return "None";
        }
    }
}