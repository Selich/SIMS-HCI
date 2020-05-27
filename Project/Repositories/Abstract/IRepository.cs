using System;
using System.Collections.Generic;

namespace Project.Repositories.Abstract
{
    public interface IRepository<E, ID>
        where E : IIdentifiable<ID>
        where ID : IComparable
    {
        E Get(ID id);
        IEnumerable<E> GetAll();
        E Create(E entity);
        E Update(E entity);
        E Delete(E entity);
        IEnumerable<E> Find(Func<E, bool> predicate);
    }
}
