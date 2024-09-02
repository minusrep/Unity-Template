using Root.Core;
using Root.Services.UI.Elements.Windows;

namespace Root.Services
{
    public class GUI : IGUI, IServiceUser
    {
        private UILoadingScreenWindow _loadingScreen;

        public void Init(ILocator<IService> services)
        {
            _loadingScreen = new UILoadingScreenWindow();

            _loadingScreen.Init(services);
        }
    }
}
