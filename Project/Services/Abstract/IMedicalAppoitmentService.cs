using System.Collections.Generic;
using Project.Model;

namespace Project.Services
{
    public interface IMedicalAppointmentService : IService<MedicalAppointment,long>
    {
        bool IsAvailableAtTimeInterval(MedicalAppointment medicalAppointment, TimeInterval timeInterval);
    }
}
