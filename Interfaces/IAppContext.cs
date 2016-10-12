namespace Interfaces
{
    public interface IAppContext
    {
        bool IsInCloud { get; }
        string CurrentUsername { get;}
    }
}
