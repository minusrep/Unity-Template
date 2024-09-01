using Root.Services;

namespace Root.Core
{
    public interface IGame
    {
        ILocator<IService> ServiceLocator { get; }
    }
}
