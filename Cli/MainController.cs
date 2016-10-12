using System;
using Domain;
using Interfaces;
using log4net;

namespace Cli
{
    public class MainController
    {
        private readonly ILog _log;
        private readonly IAppContext _appContext;
        private readonly IRepository<Person> _personRepository;

        public MainController(ILog log, IAppContext appContext, IRepository<Person> personRepository )
        {
            _log = log;
            _appContext = appContext;
            _personRepository = personRepository;
        }

        public void Init()
        {
            _log.Info("Initializing main controller");
        }

        public void StartApp()
        {
            _log.Info("Starting application");
            Console.WriteLine($"Starting app with user: {_appContext.CurrentUsername}");
            Console.WriteLine($"Starting app with InCloud: {_appContext.IsInCloud}");
            Console.WriteLine();

            var userResponse = "go";

            while (userResponse != "q")
            {
                Console.WriteLine("Press q to quit");
                userResponse = Console.ReadLine();
                ProcessUserResponse(userResponse);
            }
        }

        private void ProcessUserResponse(string userResponse)
        {
            _log.Info($"Processing user response: {userResponse}");

            if (userResponse == "data")
            {
                _personRepository.Get(Guid.NewGuid());
            }
        }
    }
}
