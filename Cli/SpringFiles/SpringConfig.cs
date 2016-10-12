using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Interfaces;
using log4net;
using Spring.Context;
using Spring.Context.Attributes;

namespace Cli.SpringFiles
{
    [Configuration]
    [Import(typeof(Infrastructure.SpringFiles.SpringConfig))]
    [Import(typeof(Data.SpringFiles.SpringConfig))]
    public class SpringConfig : IApplicationContextAware
    {
        private IApplicationContext _context;
        public IApplicationContext ApplicationContext { set { _context = value; } }

        [ObjectDef]
        public virtual ILog Log()
        {
            var log = LogManager.GetLogger(typeof(Program));
            return log;
        }

        [ObjectDef(InitMethod = "Init")]
        public virtual MainController MainController()
        {
            return new MainController(_context.GetObject<ILog>(), _context.GetObject<IAppContext>(), _context.GetObject<IRepository<Person>>());
        }
    }
};
