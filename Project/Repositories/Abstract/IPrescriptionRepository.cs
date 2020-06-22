using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;

namespace Project.Repositories.Abstract
{
    public interface IPrescriptionRepository : IRepository<Prescription, long>
    {
    }
}
