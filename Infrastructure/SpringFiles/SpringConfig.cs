using Common.Logging;
using Microsoft.Azure;
using Spring.Context;
using Spring.Context.Attributes;
using Interfaces;
using Spring.Aspects.Logging;
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
        //        <object name = "loggingAdvice" type="Spring.Aspects.Logging.SimpleLoggingAdvice, Spring.Aop">
        //  <property name = "LogUniqueIdentifier" value="true"/>               
        //  <property name = "LogExecutionTime"    value="true"/>               
        //  <property name = "LogMethodArguments"  value="true"/>
        //  <property name = "LogReturnValue"      value="true"/>

        //  <property name = "Separator"           value=";"/>
        //  <property name = "LogLevel"            value="Info"/>


        //  <property name = "HideProxyTypeNames"  value="true"/>
        //  <property name = "UseDynamicLogger"    value="true"/>
        //</object>
    }
};
