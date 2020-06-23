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
        // TODO: Refactor this
        public IEnumerable<Prescription> GetAll() {
            IEnumerable<Prescription> list = _prescriptionRepository.GetAll();
            foreach (Prescription prescription in list)
            { 
                prescription.Medicine = _medicineService.GetById(prescription.Medicine.Id);
            }
            foreach (Prescription prescription in list)
            {
                prescription.Patient = _patientService.GetById(prescription.Patient.Id);
            }
            return list;
        }


        public Prescription GetById(long id){
            Prescription prescription = _prescriptionRepository.GetById(id);
            prescription.Medicine =_medicineService.GetById(prescription.Medicine.Id);
            prescription.Patient =_patientService.GetById(prescription.Patient.Id);
            return prescription;
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
