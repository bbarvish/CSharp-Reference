using Common.Logging;
using Infrastructure.Csv;
using Microsoft.Azure;
using Spring.Context;
using Spring.Context.Attributes;
using Interfaces;
using Interfaces.Infrastructure;
using Interfaces.Shared;
using Spring.Aspects.Logging;
using TinyMessenger;
using ILog = log4net.ILog;

namespace Infrastructure.SpringFiles
{
    [Configuration]
    public class SpringConfig : IApplicationContextAware
    {
        private IApplicationContext _context;
        public IApplicationContext ApplicationContext { set { _context = value; } }

        [ObjectDef]
        public virtual IAppContext AppContext()
        {
            return new AppContext(_context.GetObject<ILog>(), 
                CloudConfigurationManager.GetSetting("IsInCloud").ToBoolean());
        }

        [ObjectDef]
        public virtual AbstractLoggingAdvice SimpleLoggingAdvice()
        {
            return new SimpleLoggingAdvice(true)
            {
                LogExecutionTime = true,
                LogLevel = LogLevel.Info
            };
        }

        [ObjectDef]
        public virtual ITinyMessengerHub TinyMessengerHub()
        {
            return new TinyMessengerHub();
        }

        [ObjectDef]
        public virtual ICsvReader CsvReader()
        {
            return new CsvReader(_context.GetObject<ILog>());
        }
    }
};
