using Project.Model;
using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    class PrescriptionService : IService<Prescription, long>
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IService<Medicine, long> _medicineService;
        private readonly IService<Patient, long> _patientService;

        public PrescriptionService(
            IPrescriptionRepository prescriptionRepository,
            IService<Medicine, long> medicineService,
            IService<Patient, long> patientService
            )
        {
            _prescriptionRepository = prescriptionRepository;
            _medicineService = medicineService;
            _patientService = patientService;
        }
        public IEnumerable<Prescription> GetAll() {
            IEnumerable<Prescription> list = _prescriptionRepository.GetAll();
            list.Select(item => item.Patient = _patientService.GetById(item.Patient.Id));
            list.Select(item => item.Medicine = _medicineService.GetById(item.Medicine.Id));
            return list;
        }


        public Prescription GetById(long id){
            Prescription p = _prescriptionRepository.GetById(id);
            p.Medicine =_medicineService.GetById(p.Medicine.Id);
            p.Patient =_patientService.GetById(p.Patient.Id);
            return p;
        }

        public Prescription Save(Prescription prescription)
            => _prescriptionRepository.Save(prescription);

        public Prescription Update(Prescription prescription)
            => _prescriptionRepository.Update(prescription);

        public Prescription Remove(Prescription prescription)
            => _prescriptionRepository.Remove(prescription);

        public Prescription GetAllPrescriptionsByPatientsId(long id)
            => _prescriptionRepository.GetAllPrescriptionsByPatientsId(id);

    }
}
