# CSharp-Reference
## Purpose
I created this project to demonstrate how **I personally choose** to utilize C# to create project structures that I have been successful with.  The purpose is to find implemenations in other languages that mimic the function, but not necessary the form.

## Noteworthy Items
### Spring Framework
Spring Framework for .Net has been used to provide basic IoC services as well as AOP services.  Basic retry and logging aspects are used to demonstrate how I choose to accomplish some of these tasks.

#### Spring Files
Having spent many years utilizing the Spring Framework, there is absolutely a "right" place for spring files.  For all projects that contribute objects, the spring configuration files are in a \SpringGFiles folder.  Since there is usually good reason to break them up into logical areas, when more than just a single file exists in a project, I have been using the following:  SpringConfig.cs, SpringAopConfig.cs, SpringServicesConfig, etc...

#### Init and Destroy
Since I do a lot of work with application-level and distributed systems messaging (eventing if you will), there are classes that subscribe to events.  I have found that the best place to keep the event subscriptions are in a void Init method for the handler.  This way, that event subscriptions are kept out of the constructor and the injected dependencies are always obvious and clean.  Furthermore, I hate when an object fails at construction time, so I'd rather have it fail at Init time.  The stack trace is much easier to see and is much more obvious.  Likewise, the Destroy method provides a good place to drop subscriptions and perform other cleanup way before the instnace is garbage collected.  Other containers, such as AutoFac, also support this type of functionality call it IStartable and the OnRelease event.

## Projects
The project stucture is pretty close wo the [http://jeffreypalermo.com/blog/the-onion-architecture-part-1/](Onion Architecture) but is a little ligher.

### Cli
This is simply intended to provide the entry point to the application domain.  I can be a desktop app, a web app or a command line interface (cli) designed to run in the background or a windows service.  You can also easily convert the CLI to a WindowsService using [TopShelf](http://topshelf-project.com/).
