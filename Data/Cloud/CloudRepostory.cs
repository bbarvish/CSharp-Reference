using System;
using System.Collections.Generic;
using Interfaces;
using log4net;

namespace Data.Cloud
{
    public class CloudRepostory<T> : IRepository<T>
    {
        private readonly ILog _log;

        public CloudRepostory(ILog log)
        {
            _log = log;
        }

        public T Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Add(T missing_name)
        {
            throw new NotImplementedException();
        }
    }
}
