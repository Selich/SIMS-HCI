using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project.Model;
using Project.Repositories;
using Project.Repositories.Abstract;

namespace Project.Services
{
    class DoctorService : IService<Doctor, long>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly AddressService _addressService;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public IEnumerable<Doctor> GetAll() => _doctorRepository.GetAll();

        public Doctor GetById(long id) => _doctorRepository.GetById(id);

        public Doctor Save(Doctor patient)
        {
            patient.Address = _addressService.Save(patient.Address);
            return _doctorRepository.Save(patient);
        }

        public Doctor Update(Doctor doctor)
        {
            doctor.Address = _addressService.Save(doctor.Address);
            return _doctorRepository.Update(doctor);
        }

        public Doctor Remove(Doctor client) => _doctorRepository.Remove(client);

        public bool IsDoctorAvailable(int doctorID) => throw new NotImplementedException();

        public List<Doctor> GetAailableDoctors(Array doctorsID) => throw new NotImplementedException();

        public List<Doctor> GetAailableDoctors(TimeInterval timeInterval) => throw new NotImplementedException();

        public List<Doctor> GetAvailableDoctorsTimeInterval(MedicalAppointment medicalAppointment) => throw new NotImplementedException();

        public Doctor GetByEmail(string email) => throw new NotImplementedException();

        public List<Doctor> GetAllDoctorsBySpecialization() => throw new NotImplementedException();
    }
}
