using Root._Core._Locator;
using Root._Services._Core;
using Root._UI._Elements._LoadingScreen;

namespace Root._UI._Core
{
    public class UserInterface : Service, IUserInterface
    {
        private UILoadingScreenWindow _loadingScreen;

        public override void Init(ILocator<IService> services)
        {
            _loadingScreen = new UILoadingScreenWindow();

            _loadingScreen.Init(services);
        }
    }
}
