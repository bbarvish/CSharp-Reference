namespace Interfaces.Shared
{
    public interface IAppContext
    {
        bool IsInCloud { get; }
        string CurrentUsername { get;}
    }
}
