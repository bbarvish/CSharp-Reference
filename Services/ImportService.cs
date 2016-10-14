using Domain;
using Interfaces.Data;
using Interfaces.Infrastructure;
using log4net;

namespace Services
{
    public class ImportService : IImportService
    {
        private readonly ILog _log;
        private readonly ICsvReader _csvReader;
        private readonly IRepository<Person> _personRepository;

        public ImportService(ILog log, ICsvReader csvReader, IRepository<Person> personRepository)
        {
            _log = log;
            _csvReader = csvReader;
            _personRepository = personRepository;
        }

        public int ImportPersons()
        {
            var importData = _csvReader.ImportPersons();
            var importItemCount = 0;

            foreach (var person in importData)
            {
                _personRepository.Add(person);
                importItemCount++;
            }

            return importItemCount;
        }

    }
}
