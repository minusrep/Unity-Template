using Root.Core;
using Root.Services.UI.Elements.Windows;

namespace Root.Services
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
