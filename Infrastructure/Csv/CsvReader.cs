using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Interfaces.Infrastructure;
using log4net;

namespace Infrastructure.Csv
{
    public class CsvReader : ICsvReader
    {
        private readonly ILog _log;

        public CsvReader(ILog log)
        {
            _log = log;
        }

        public IEnumerable<Person> ImportPersons()
        {
            return null;
        }
    }
}
