﻿using Project.Model;
using Project.Repositories.ManyToMany.Model;
using Project.Repositories.Abstract;
using Project.Repositories.ManyToMany.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    class MedicalAppointmentService : IMedicalAppointmentService
    {
        private readonly IMedicalAppointmentRepository _medicalAppointmentRepository;

        public MedicalAppointmentService(
            IMedicalAppointmentRepository medicalAppointmentRepository
        )
        {
            _medicalAppointmentRepository = medicalAppointmentRepository;
        }
        public IEnumerable<MedicalAppointment> GetAll()
            => _medicalAppointmentRepository.GetAll();

        public IEnumerable<MedicalAppointment> GetAllByPatientId(long id)
            => _medicalAppointmentRepository.GetAllByPatientId(id);

        public MedicalAppointment GetById(long id)
            => _medicalAppointmentRepository.GetById(id);

        public MedicalAppointment Remove(MedicalAppointment entity)
            => _medicalAppointmentRepository.Remove(entity);

        public MedicalAppointment Save(MedicalAppointment entity)
            => _medicalAppointmentRepository.Save(entity);

        public MedicalAppointment Update(MedicalAppointment entity)
            => _medicalAppointmentRepository.Update(entity);

        public IEnumerable<MedicalAppointment> GetAllByDoctorID(long id)
            => _medicalAppointmentRepository.GetAllByDoctorId(id);

        public bool IsAvailableAtTimeInterval(MedicalAppointment medicalAppointment, TimeInterval timeInterval)
            => medicalAppointment.Beginning >= timeInterval.Start && medicalAppointment.End <= timeInterval.End;

        private IEnumerable<MedicalAppointment> GenerateAppointments(TimeInterval interval)
        {
            List<MedicalAppointment> list = new List<MedicalAppointment>();
            for(DateTime iter = interval.Start; iter <= interval.End; iter.AddMinutes(30))
                list.Add(new MedicalAppointment(iter, iter.AddMinutes(30), null, MedicalAppointmentType.examination ,null));
            return list;
        }

        public IEnumerable<MedicalAppointment> GetAvailableAppoitments(Doctor doctor, Room room, TimeInterval timeInterval)
        {
            var dif = (timeInterval.End  - timeInterval.Start).TotalDays;
            var workHours = doctor.WorkingHours;

            // Doctor working hours
            List<MedicalAppointment> listFreeApp = new List<MedicalAppointment>();
            for(int i = 0; i < dif; i++){
                // var day = doctor.WorkingHours.Start.AddDays(i);
                var startHours = doctor.WorkingHours.Start.Hour;
                var startMinutes = doctor.WorkingHours.Start.Minute;
                var endHours = doctor.WorkingHours.Start.Hour;
                var endMinutes = doctor.WorkingHours.Start.Minute;
                var currDay = timeInterval.Start.AddDays(i);
                DateTime startWH = new DateTime(currDay.Year, currDay.Month, currDay.Day, startHours, startMinutes, 0);
                DateTime endWH = new DateTime(currDay.Year, currDay.Month, currDay.Day, endHours, endMinutes, 0);
                listFreeApp.AddRange(GenerateAppointments(new TimeInterval(startWH, endWH)));
            }


            // Filter free by doctorsApp
            if(doctor != null){
                doctor.Appointments.ForEach(app => listFreeApp.Remove(listFreeApp.Where(item => item.Beginning == app.Beginning && item.End == app.End).SingleOrDefault())); 
            }

            if(room != null) 
                listFreeApp = listFreeApp.Where(item => item.Room == room).ToList();



            return listFreeApp;

        }

        private IEnumerable<MedicalAppointment> GetAvailableAppoitmentsByDoctor(Doctor doctor)
        {     
            return new List<MedicalAppointment>();
        }

        private IEnumerable<MedicalAppointment> GetAvailableAppoitmentsByTimeInterval(TimeInterval timeinterval)
        {
            return new List<MedicalAppointment>();
        }

    }

}

