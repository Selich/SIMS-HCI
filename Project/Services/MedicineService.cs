using Project.Model;
using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    public class MedicineService : IService<Medicine, long>
    {
        private readonly IMedicineRepository _medicineRepository;
        public MedicineService(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }
        public IEnumerable<Medicine> GetAll()
            => _medicineRepository.GetAll();

        public Medicine GetById(long id)
            => _medicineRepository.GetById(id);

        public Medicine Save(Medicine medicine)
            => _medicineRepository.Save(medicine);

        public Medicine Update(Medicine medicine)
            => _medicineRepository.Update(medicine);

        public Medicine Remove(Medicine medicine)
            => _medicineRepository.Remove(medicine);

        public  Medicine GetByName(string name)
            => _medicineRepository.GetByName(name);

        public Medicine RegisterMedicine(string name, string purpose, string administration, string type, string description)
            => _medicineRepository.RegisterMedicine(name, purpose, administration, type, description);

    }
}