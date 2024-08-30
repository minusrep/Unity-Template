using Root._Core._Locator;

namespace Root._Services._Core
{
    public abstract class Service
    {
        public abstract void Init(ILocator<IService> services);
    }
}
