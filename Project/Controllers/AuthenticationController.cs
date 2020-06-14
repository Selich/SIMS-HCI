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
        public UserDTO Login(string email, string pass)
        {
            UserDTO returnUser = null;
            returnUser = app.patients.Find(patient => patient.Email == email && patient.Password == pass);
            if(returnUser == null)
                returnUser = app.patients.Find(patient => patient.Email == email && patient.Password == pass);


            return returnUser;
        }
    }
}