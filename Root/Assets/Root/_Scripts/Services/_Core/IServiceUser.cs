using Root.Core;

namespace Root.Services
{
    public interface IServiceUser
    {
        void Init(ILocator<IService> services);
    }
}
