using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Spring.Context.Support;

namespace Cli
{
    class Program
    {
        private static ILog _logger;

        static void Main(string[] args)
        {
            var startTimer = Environment.TickCount;

            var containerCtx = BootstrapContainer();
            _logger = containerCtx.GetObject<ILog>();

            _logger.Info($"Application is starting after: {Environment.TickCount - startTimer}ms");

            var mainController = containerCtx.GetObject<MainController>("MainController");

            mainController.StartApp();

            _logger.Info("Application is exiting");
        }

        static CodeConfigApplicationContext BootstrapContainer()
        {
            var ctx = new CodeConfigApplicationContext();

            try
            {
                ctx.ScanWithAssemblyFilter(assy => assy.FullName.StartsWith("Cli"));
                ctx.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to start the application with error: " + GetFullExceptionMessage(ex), "Currency ELS");
                _logger.Error("Unable to start the application with error.", ex);
            }

            return ctx;
        }

        static string GetFullExceptionMessage(Exception ex)
        {
            if (ex.InnerException != null)
            {
                return ex.Message + Environment.NewLine + GetFullExceptionMessage(ex.InnerException);
            }

            return ex.Message;
        }

    }
}
