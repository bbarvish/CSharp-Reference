using System;
using System.Collections.Generic;

namespace Interfaces.Data
{
    public interface IRepository<T>
    {
        T Get(Guid id);
        IEnumerable<T> GetAll();
        void Delete(Guid id);
        void Add(T item);
    }
}