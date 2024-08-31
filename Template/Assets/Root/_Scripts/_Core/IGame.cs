using Root._Core._Locator;
using Root._Services._Core;

namespace Root._Core
{
    public interface IGame
    {
        ILocator<IService> ServiceLocator { get; }
    }
}
