using System;
using System.Collections.Generic;
using Interfaces;
using Interfaces.Data;
using log4net;

namespace Data.Desktop
{
    public class DesktopRepository<T> : IRepository<T> where T:new()
    {
        private readonly ILog _log;
        private int _retryCount = 0;

        public DesktopRepository(ILog log)
        {
            _log = log;
        }

        public T Get(Guid id)
        {
            var currentTicks = Environment.TickCount;

            _log.Info($"Attempting DesktopRepository Get at: {currentTicks} with retry count of: {_retryCount}");

            if (currentTicks % 2 == 0)
            {
                _log.Error("Even tick in DesktopRepository so fail for retry purposes");
                throw new ApplicationException($"Sorry, that was an even tick at retry {++_retryCount}");
            }

            _log.Info($"Completing DesktopRepository Get at: {currentTicks} with retry count: {_retryCount}");
            _retryCount = 0;

            return new T();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }
    }
}
