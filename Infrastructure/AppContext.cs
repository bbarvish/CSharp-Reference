using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using log4net;

namespace Infrastructure
{
    public class AppContext : IAppContext
    {
        private readonly ILog _log;

        public AppContext(ILog log, bool isInCloud)
        {
            _log = log;
            IsInCloud = isInCloud;
        }

        public bool IsInCloud { get; }

        public string CurrentUsername => Environment.UserName;
    }
}
