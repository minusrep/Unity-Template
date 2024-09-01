using Root.Core;

namespace Root.Services
{
    public interface IServiceViewer
    {
        void Init(ILocator<IService> services);
    }
}
