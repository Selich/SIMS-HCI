using System;
using Project.Model;

namespace Project.Repositories.Abstract
{
    public interface IDoctorRepository : IRepository<Doctor, long>
    {
        Doctor GetByEmail(string email);
    }
}
