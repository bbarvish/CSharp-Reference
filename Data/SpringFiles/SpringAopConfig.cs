using System.Collections.Generic;
using Spring.Aop.Framework.AutoProxy;
using Spring.Aspects;
using Spring.Context;
using Spring.Context.Attributes;

namespace Data.SpringFiles
{
    [Configuration]
    public class SpringAopConfig : IApplicationContextAware
    {
        private IApplicationContext _context;
        public IApplicationContext ApplicationContext { set { _context = value; } }

        [ObjectDef]
        public virtual RetryAdvice BasicRetry()
        {
            return new RetryAdvice {RetryExpression = "on exception (#e is T(System.ApplicationException)) retry 3x delay 1s" };
        }

        [ObjectDef]
        public virtual ObjectNameAutoProxyCreator ControllerProxy()
        {
            var proxy = new ObjectNameAutoProxyCreator
            {
                ObjectNames = new List<string> {"*Repository"},
                InterceptorNames = new[] {"BasicRetry", "SimpleLoggingAdvice"}
            };

            return proxy;
        }
    }
}