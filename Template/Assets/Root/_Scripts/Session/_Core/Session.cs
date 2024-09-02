using Root.Core;
using Root.Services;
using System.Collections;

namespace Root
{
    public class Session : IServiceUser
    {
        private Locator<IController> _controllers;

        private ILocator<IService> _services;

        private ISceneLoader _sceneLoader;

        public void Init(ILocator<IService> services)
        {
            _services = services;

            _controllers = new Locator<IController>();

            _sceneLoader = _services.Get<ISceneLoader>();
        }

        public IEnumerator Run()
        {
            yield return _sceneLoader.LoadSceneAsync(SceneType.Game);
        }

        private void RegisterController<T>(T controller) where T : IController
        {
            if (controller is IControllerUser)
                InitControllerUser(controller as IControllerUser);

            _controllers.Register<T>(controller);
        }

        private void InitControllerUser<T>(T controller) where T : IControllerUser
            => controller.Init(_controllers);
    }
}
