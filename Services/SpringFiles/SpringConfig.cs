using Domain;
using Interfaces.Data;
using Interfaces.Infrastructure;
using log4net;
using Spring.Context;
using Spring.Context.Attributes;

namespace Services.SpringFiles
{
    [Configuration]
    public class SpringConfig : IApplicationContextAware
    {
        private IApplicationContext _context;
        public IApplicationContext ApplicationContext { set { _context = value; } }

        [ObjectDef]
        public virtual IImportService ImportService()
        {
            return new ImportService(_context.GetObject<ILog>(), 
                _context.GetObject<ICsvReader>(), 
                _context.GetObject<IRepository<Person>>());
        }
    }
};
