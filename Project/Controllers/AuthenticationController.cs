using Project.Services;
using Project.Model;
using System.Collections.Generic;

namespace Project.Controllers
{
    public class AuthenticationController : IController<User, long>
    {
        public User Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public User Remove(User entity)
        {
            throw new System.NotImplementedException();
        }

        public User Save(User entity)
        {
            throw new System.NotImplementedException();
        }

        public User Update(User entity)
        {
            throw new System.NotImplementedException();
        }
    }
}