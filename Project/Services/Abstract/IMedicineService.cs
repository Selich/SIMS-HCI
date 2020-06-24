using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;

namespace Project.Services.Abstract
{
    public interface IMedicineService : IService<Medicine, long>
    {
        Medicine GetByName(string name);
    }
}
