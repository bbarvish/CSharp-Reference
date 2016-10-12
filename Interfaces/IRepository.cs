using System;
using System.Collections;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IRepository<T>
    {
        T Get(Guid id);
        IEnumerable<T> GetAll();
        void Delete(Guid id);
        void Add(T item);
    }
}