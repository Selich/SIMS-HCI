using System.Collections.Generic;
namespace Project.Services
{
    public interface IService<E, ID> where E : class
    {
        E Get(ID id);
        IEnumerable<E> GetAll();
        E Create(E entity);
        void Update(E entity);
        void Delete(E entity);
    }
}