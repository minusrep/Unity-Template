using Root.Core;

namespace Root
{
    public interface IControllerUser
    {
        void Init(ILocator<IController> controllers);
    }
}
