using Data.Cloud;
using Data.Desktop;
using Domain;
using Interfaces;
using Interfaces.Data;
using Interfaces.Shared;
using log4net;
using Spring.Context;
using Spring.Context.Attributes;

namespace Data.SpringFiles
{
    [Configuration]
    [Import(typeof(SpringAopConfig))]
    public class SpringConfig : IApplicationContextAware
    {
        private IApplicationContext _context;
        public IApplicationContext ApplicationContext { set { _context = value; } }

        [ObjectDef]
        public virtual IRepository<Person> PersonRepository()
        {
            var isInCloud = _context.GetObject<IAppContext>().IsInCloud;

            if (isInCloud)
            {
                return new CloudRepository<Person>(_context.GetObject<ILog>());
            }

            return new DesktopRepository<Person>(_context.GetObject<ILog>());
        }
    }
};
