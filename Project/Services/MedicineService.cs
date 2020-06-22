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

        public Medicine Save(Medicine question)
            => _medicineRepository.Save(question);

        public Medicine Update(Medicine question)
            => _medicineRepository.Update(question);

        public Medicine Remove(Medicine question)
            => _medicineRepository.Remove(question);


    }
}