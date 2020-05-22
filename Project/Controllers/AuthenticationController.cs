using Project.Services;

namespace Project.Controllers
{
    public class AuthenticationController
    {
        AuthenticationService authService = new AuthenticationService();
        

        public Model.User loginUser(string email, string password){

            Model.User user = authService.loginUser(email, password);

            return user;



            

        }
        
    }
}