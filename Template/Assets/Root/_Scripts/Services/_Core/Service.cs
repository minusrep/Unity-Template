using Root.Core;

namespace Root.Services
{
    public abstract class Service
    {
        public abstract void Init(ILocator<IService> services);
    }
}
