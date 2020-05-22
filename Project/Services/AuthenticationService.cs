using Project.Repositories;

namespace Project.Services
{
    public class AuthenticationService
    {
        PatientRepository patientRepo;
        DoctorRepository doctorRepo;
        SecretaryRepository secretaryRepo;
        DirectorRepository directorRepo;

        public AuthenticationService(){
             patientRepo = new PatientRepository();
             doctorRepo = new DoctorRepository();
             secretaryRepo = new SecretaryRepository();
             directorRepo = new DirectorRepository();

        }

        public Model.User loginUser(string email, string password){

            Model.User user = null;
            user = patientRepo.GetPatientByEmail(email);


            

            return user;
            

        }

        
    }
}