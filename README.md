# CSharp-Reference
## Purpose
I created this project to demonstrate how **I personally choose** to utilize C# to create project structures that I have been successful with.  The purpose is to find implemenations in other languages that mimic the function, but not necessary the form.

## Noteworthy Items
### Spring Framework
Spring Framework for .Net has been used to provide basic IoC services as well as AOP services.  Basic retry and logging aspects are used to demonstrate how I choose to accomplish some of these tasks.

#### Configuration Files
Having spent many years utilizing the Spring Framework, there is absolutely a "right" place for spring files.  For all projects that contribute objects, the spring configuration files are in a \SpringGFiles folder.  Since there is usually good reason to break them up into logical areas, when more than just a single file exists in a project, I have been using the following:  SpringConfig.cs, SpringAopConfig.cs, SpringServicesConfig, etc...

#### Init and Destroy
Since I do a lot of work with application-level and distributed systems messaging (eventing if you will), there are classes that subscribe to events.  I have found that the best place to keep the event subscriptions are in a void Init method for the handler.  This way, that event subscriptions are kept out of the constructor and the injected dependencies are always obvious and clean.  Furthermore, I hate when an object fails at construction time, so I'd rather have it fail at Init time.  The stack trace is much easier to see and is much more obvious.  Likewise, the Destroy method provides a good place to drop subscriptions and perform other cleanup way before the instnace is garbage collected.  Other containers, such as AutoFac, also support this type of functionality call it IStartable and the OnRelease event.

## Projects
The project stucture is pretty close to the [Onion Architecture](http://jeffreypalermo.com/blog/the-onion-architecture-part-1/) but is a little ligher.

### Cli
This is simply intended to provide the entry point to the application domain.  I can be a desktop app, a web app or a command line interface (cli) designed to run in the background or a windows service.  You can also easily convert the CLI to a WindowsService using [TopShelf](http://topshelf-project.com/).

For this solution the Cli simply presents the user with a menu and allows them to trigger different examples of behavior.
### Domain
This project has no references to any other projects in the soution and simply contains the classes which form the domain that the target solution operates on.  Very little emphasis is placed on this project as it is in the very middle of the onion.

### Interfaces
Following the Inteface Segregation principle all intefaces that are shared by the member  projects are placed into this project.  Eventhough tools like resharper offer a very convenient to find code in a solution I prefer to have folders inside this project that mimic the solution layout making things easier to find on the file system.  The interface project directly references the domain project as some interfaces will likely accept or return a class from the domain.
### Infrastructure
As the name implies this project provides infrastructure and is referenced and used by other projects which form the application business operations.  This is an excellent place to put your event aggregator [Tiny Messenger](https://github.com/grumpydev/TinyMessenger/wiki) and other objects such as an AppContext that are likely shared across many projects.  I also find myself placing extension classes here for the same reason.
