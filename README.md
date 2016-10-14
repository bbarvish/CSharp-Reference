# Purpose
I created this project to demonstrate how **I personally choose** to utilize C# to create project structures that I have been successful with.  The purpose is to find implemenations in other languages that mimic the function, but not necessary the form.

# Noteworthy Items
## Spring Framework
Spring Framework for .Net has been used to provide basic IoC services as well as AOP services.  Basic retry and logging aspects are used to demonstrate how I choose to accomplish some of these tasks.

### Configuration Files
Having spent many years utilizing the Spring Framework, there is absolutely a "right" place for spring files.  For all projects that contribute objects, the spring configuration files are in a \SpringFiles folder.  Since there is usually good reason to break them up into logical areas, when more than just a single file exists in a project, I have been using the following:  SpringConfig.cs, SpringAopConfig.cs, SpringServicesConfig, etc...

### Init and Destroy
Since I do a lot of work with application-level and distributed systems messaging (eventing if you will), there are classes that subscribe to events.  I have found that the best place to keep the event subscriptions are in a void Init method for the handler.  This way, that event subscriptions are kept out of the constructor and the injected dependencies are always obvious and clean.  Furthermore, I hate when an object fails at construction time, so I'd rather have it fail at Init time.  The stack trace is much easier to see and is much more obvious.  Likewise, the Destroy method provides a good place to drop subscriptions and perform other cleanup way before the instnace is garbage collected.  Other containers, such as AutoFac, also support this type of functionality call it IStartable and the OnRelease event.

## Assembly Info Data
Something I have been doing for a while is sharing the information inside the AssemblyInfo.cs file across all the projects in the solution.  I break up the default AssemblyInfo.cs file from the projects into Company and Version info as those appear to be the logical parts.  These files will then become AssemblyInfoVersionShared.cs and AssemblyInfoCompanyShared.cs and are placed in the root of the solution on the file system.

The attribues in the Company shared file as follows:

`[assembly: AssemblyCompany("Boris Barvish")]`

`[assembly: AssemblyProduct("CSharp-Reference")]`

`[assembly: AssemblyCopyright("Copyright ©  2016")]`

`[assembly: AssemblyTrademark("My TM goes here")]`

And the Version:

`[assembly: AssemblyVersion("1.0.0.1")]`

`[assembly: AssemblyFileVersion("1.0.0.1")]`

I then modify each projects' AssemblyInfo.cs file and remove these lines leaving behing information that only pertains each of the final assemblies.  Once that's done, I add the shared files into each solution by adding **existing items** at the project level.  Visual Studio does not allow you to add the files to the Properties folder directly so they are added **as a link** to the root of the project and then dragged into the Properties folder.  Check out the solution to it in action.

# Projects
The project stucture is pretty close to the [Onion Architecture](http://jeffreypalermo.com/blog/the-onion-architecture-part-1/) but is a little ligher.

## Cli
This is simply intended to provide the entry point to the application domain.  I can be a desktop app, a web app or a command line interface (cli) designed to run in the background or a windows service.  You can also easily convert the CLI to a WindowsService using [TopShelf](http://topshelf-project.com/).

For this solution the Cli simply presents the user with a menu and allows them to trigger different examples of behavior.
## Domain
This project has no references to any other projects in the soution and simply contains the classes which form the domain that the target solution operates on.  Very little emphasis is placed on this project as it is in the very middle of the onion.

## Interfaces
Following the Inteface Segregation principle all intefaces that are shared by the member  projects are placed into this project.  Eventhough tools like resharper offer a very convenient to find code in a solution I prefer to have folders inside this project that mimic the solution layout making things easier to find on the file system.  The interface project directly references the domain project as some interfaces will likely accept or return a class from the domain.
## Infrastructure
As the name implies this project provides infrastructure and is referenced and used by other projects which form the application business operations.  This is an excellent place to put your event aggregator [Tiny Messenger](https://github.com/grumpydev/TinyMessenger/wiki) and other objects such as an AppContext that are likely shared across many projects.  I also find myself placing extension classes here for the same reason.
## Data
The Data project can be somewhat fluid at times.  Depending on the target back end and the purpose/lifespan/complexity of the effort, most data abstractions will be here.  I have found, in certain cases, that say if I want to target multiple very differen back ends, like an AWS storage model and an Azure storage model, I will indeed create Data.Amazon and Data.Azure.  In that case the Data project tends to delegate calls to those projects and offers the flexibility of the abstraction.  There is no right answer obviously and usage should always be consisted with both technical and business considerations.

## Services
The Services project may likely follow the approach of the data project, depending on the complexity of the overall effort.  In a simple, and even medium complexity effort, most services can easily be places here.  However, in a larger system, or one that logicially divides the services into smaller, often deployed units such as microservices, this may simply become a solution level folder with the actual services project below it such as \Services\AuthenticationService and \Services\CommerceService.  As I mentioned before, I prefer to keep the project structure consistent with the file system and Visual Studio solution folders offer an clean approach to that.  Just be careful when you first create the project and make doubly sure that Visual Studio puts it where you expect it to be.
