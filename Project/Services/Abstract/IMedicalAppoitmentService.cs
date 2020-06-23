using System.Collections.Generic;
namespace Project.Services
{
    public interface IMedicalAppointmentService<E, ID> where E : class
    {
        E GetById(ID id);
        IEnumerable<E> GetAll();
        IEnumerable<E> GetAllByPatientId(ID id);
        E Save(E entity);
        E Update(E entity);
        E Remove(E entity);
    }
}
